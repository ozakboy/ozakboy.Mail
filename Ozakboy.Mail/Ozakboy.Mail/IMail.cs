using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozakboy.Mail
{
    public interface IMail
    {
        /// <summary>
        /// 發送郵件
        /// </summary>
        /// <param name="ReceiveInfos">收件人</param>
        /// <param name="CCInfos">副本收件人</param>
        /// <param name="AttachmentsInfos">附件</param>
        /// <param name="MailSubject">標題</param>
        /// <param name="MailBody">內文</param>
        /// <param name="IsBodyHtml">內文是否是HTML 預設 =  true </param>
        void SendMail(List<MailInfo> ReceiveInfos, List<MailInfo> CCInfos, List<AttachmentsInfo> AttachmentsInfos, string MailSubject, string MailBody, bool IsBodyHtml = true);
    }
}
