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
            if (Smtp == null)
            {
                throw new InvalidOperationException("SMTP 設定未正確配置");
            }

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
                    MailMessage.CC.Add(new MailAddress(item.Address, item.Name));
                }
            }

            // 附件
            if (AttachmentsInfos != null)
            {
                foreach (var item in AttachmentsInfos)
                {
                    if (item.FileStream != null)
                    {
                        MailMessage.Attachments.Add(new Attachment(item.FileStream, item.FileName, item.FileType));
                    }
                }
            }

            try
            {
                SmtpClientInfo.Send(MailMessage);
            }
            catch (SmtpException ex)
            {
                throw new InvalidOperationException(
                    $"郵件發送失敗。請檢查：\n" +
                    $"1. 網路連線是否正常\n" +
                    $"2. SMTP 設定是否正確 (Host: {Smtp.Host}, Port: {Smtp.Port})\n" +
                    $"3. 防火牆是否允許 Port {Smtp.Port} 的對外連線\n" +
                    $"4. 帳號密碼是否正確\n" +
                    $"詳細錯誤：{ex.Message}",
                    ex);
            }

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
