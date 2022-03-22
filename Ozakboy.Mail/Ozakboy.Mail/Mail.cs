using Microsoft.Extensions.Configuration;
using Ozakboy.Mail.ViewModels;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Ozakboy.Mail
{
    public class Mail : IMail
    {
        private  VMailSettings _MailSettings;
        public Mail(IConfiguration _configuration)
        {
            _MailSettings = _configuration.Get<VMailSettings>();
        }
        /// <summary>
        /// 發送信件
        /// </summary>
        public void SendMail(List<MailInfo> ReceiveInfos, List<MailInfo> CCInfos, List<AttachmentsInfo> AttachmentsInfos, string MailSubject, string MailBody, bool IsBodyHtml = true)
        {
             var Smtp =  _MailSettings.SmtpMailConfig;

            using var SmtpClientInfo = new SmtpClient(Smtp.Host, Smtp.Port);
            var FromMailAddress = new MailAddress(Smtp.UserName, Smtp.Name);
            SmtpClientInfo.UseDefaultCredentials = false;
            SmtpClientInfo.Credentials = new NetworkCredential(Smtp.UserName, Smtp.Password);
            SmtpClientInfo.EnableSsl = true;
            SmtpClientInfo.DeliveryMethod = SmtpDeliveryMethod.Network;

            var MailMessage = new MailMessage
            {
                // 主旨
                Subject = MailSubject,
                // 計件者
                From = FromMailAddress,
                // 內容
                Body = MailBody,
                // 內容是否採用 Html 格式
                IsBodyHtml = IsBodyHtml
            };


            // 設定收件者
            if (ReceiveInfos != null)
            {
                foreach (var item in ReceiveInfos)
                {
                    MailMessage.To.Add(new MailAddress(item.Address, item.Name));
                }
            }

            // 設定副本收件者
            if (CCInfos != null)
            {
                foreach (var item in CCInfos)
                {
                    MailMessage.Bcc.Add(new MailAddress(item.Address, item.Name));
                }
            }

            // 附件
            if (AttachmentsInfos != null)
            {
                foreach (var item in AttachmentsInfos)
                {
                    MailMessage.Attachments.Add(new Attachment(item.FileStream, item.FileName, item.FileType));
                }
            }

            SmtpClientInfo.Send(MailMessage);

            if (MailMessage.Attachments != null)
            {
                foreach (var item in MailMessage.Attachments)
                {
                    item.Dispose();
                }
            }

        }

    }
}
