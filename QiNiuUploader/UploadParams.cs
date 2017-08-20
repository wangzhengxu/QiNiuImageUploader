using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiNiuUploader
{
    public class UploadParams
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public bool FromClip { get; set; }
        public string Token { get; set; }
    }
}
