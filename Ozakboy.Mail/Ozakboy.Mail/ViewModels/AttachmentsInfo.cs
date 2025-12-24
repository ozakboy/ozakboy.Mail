using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozakboy.Mail
{  

    /// <summary>
    /// 附件內容
    /// </summary>
    public class AttachmentsInfo
    {
        /// <summary>
        /// 檔案內容
        /// </summary>
        public Stream? FileStream { get; set; }

        /// <summary>
        /// 檔案名稱
        /// </summary>
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// 檔案類型
        /// </summary>
        public string FileType { get; set; } = string.Empty;
    }
}
