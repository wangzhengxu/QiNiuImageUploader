using Qiniu.Http;
using Qiniu.IO;
using Qiniu.IO.Model;
using Qiniu.RS;
using Qiniu.RS.Model;
using Qiniu.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QiNiuUploader
{
    public partial class Form1 : Form
    {
        public readonly string Ak;
        public readonly string Sk;
        public readonly string DefaultDomain = "";
        public readonly string Bucket = "";
        public Form1()
        {
            InitializeComponent();
            Ak = "";
            Sk = "";
            Qiniu.JSON.JsonHelper.JsonSerializer = new AnotherJsonSerializer();
            Qiniu.JSON.JsonHelper.JsonDeserializer = new AnotherJsonDeserializer();
            Qiniu.Common.Config.AutoZone(Ak, Bucket, true);
            InitControl();
        }
        private void InitControl()
        {
            SetUploadButtonStatus(false);
            groupOut.Visible = false;

        }

        private void btnChoice_Click(object sender, EventArgs e)
        {
            openImgDialog.Filter = "*.jpg|*.jpg|*.png|*.png|*.gif|*.gif|*.bmp|*.bmp|*.tiff|*.tiff";//图片格式  
            if (openImgDialog.ShowDialog() == DialogResult.OK)
            {
                txtOut.Text = "";
                groupOut.Visible = false;
                imgLocation.Text = openImgDialog.FileName;//实际的文件路径+文件名  
                pbShow.Image = Image.FromFile(openImgDialog.FileName);//将图片显示在pitureBox控件中
                SetUploadButtonStatus(true);
            }

        }
        private void SetUploadButtonStatus(bool enabled)
        {
            btnUpload.Enabled = enabled;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(imgLocation.Text) && (pbShow == null || pbShow.Image == null))
            {
                MessageBox.Show("请选择图片", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var param = InitUploadParams();
                if (param==null)
                {
                    return;
                }
                var result = StartUploadWork(param);
                if (result.Code == 200)
                {
                    MessageBox.Show("上传成功", "提示信息", MessageBoxButtons.OK);
                    txtOut.Text = DefaultDomain + param.FileName;
                    groupOut.Visible = true;
                }
                else
                {
                    MessageBox.Show("上传出错", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("发生异常" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private UploadParams InitUploadParams()
        {
            var param = new UploadParams();
            if (!string.IsNullOrEmpty(imgLocation.Text))
            {
                param.FileName = Path.GetFileName(imgLocation.Text);
                param.FilePath = imgLocation.Text;
                param.FromClip = false;
            }
            else
            {
                param.FileName = GetImageMd5() + ".jpg";
                param.FromClip = true;
            }

            var fileInfo = GetFileInfo(param.FileName);
            if (fileInfo.Code == 200)
            {
                //file exist
                DialogResult dialogResult = MessageBox.Show("该文件已经存在，是否覆盖?", "提示信息", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return null;
                }
            }
            param.Token = GetToken(param.FileName);
            return param;
        }

        public StatResult GetFileInfo(string fileName)
        {
            Mac mac = new Mac(Ak, Sk);

            BucketManager bm = new BucketManager(mac);
            StatResult result = bm.Stat(Bucket, fileName);
            return result;
        }


        private string GetToken(string saveKey)
        {
            Mac mac = new Mac(Ak, Sk);
            PutPolicy putPolicy = new PutPolicy();
            putPolicy.Scope = Bucket + ":" + saveKey;
            // 上传策略有效期(对应于生成的凭证的有效期)          
            putPolicy.SetExpires(3600);
            string jstr = putPolicy.ToJsonString();
            string token = Auth.CreateUploadToken(mac, jstr);
            return token;
        }

        private HttpResult StartUploadWork(UploadParams param)
        {
            if (param.FromClip)
            {
                var data = ImageToByte(pbShow.Image);
                FormUploader fu = new FormUploader();
                return fu.UploadData(data, param.FileName, param.Token);
            }
            UploadManager um = new UploadManager();
            return um.UploadFile(param.FilePath, param.FileName, param.Token);
        }

        private void btnClip_Click(object sender, EventArgs e)
        {
            var image = Clipboard.GetImage();
            if (image != null)
            {
                pbShow.Image = image;
                SetUploadButtonStatus(true);
                imgLocation.Text = "";
            }
        }
        private static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private string GetImageMd5()
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = pbShow.Image.ToStream(ImageFormat.Jpeg))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "‌​").ToLower();
                }
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtOut.Text);
                MessageBox.Show("复制成功", "提示信息");
            }
            catch
            {
                MessageBox.Show("复制失败", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
