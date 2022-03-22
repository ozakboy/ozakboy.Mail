using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Ozakboy.Mail.WebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private IMail _mail;
        public SendEmailController(IMail mail)
        {
            _mail = mail;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<MailInfo> mailInfos = new List<MailInfo>();
            List<MailInfo> CCInfos = new List<MailInfo>();
            List<AttachmentsInfo> AttachmentsInfos = new List<AttachmentsInfo>();
            mailInfos.Add(new MailInfo("你的信箱"));
            CCInfos.Add(new MailInfo("你的信箱"));

            FileStream fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "appsettings.json", FileMode.Open);
            AttachmentsInfos.Add(new AttachmentsInfo
            {
                FileName = "測試檔案.json",
                FileType = MediaTypeNames.Application.Json,
                FileStream = fileStream
            });
            _mail.SendMail(mailInfos, CCInfos, AttachmentsInfos, "測試寄信標題", "測試寄信功能", false);
            return Ok();
        }

    }
}
