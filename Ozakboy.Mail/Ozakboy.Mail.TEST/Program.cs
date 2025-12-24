
using Microsoft.Extensions.Configuration;
using Ozakboy.Mail;
using System.Net.Mime;

var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
var app = builder.Build();

IMail Mail = new Mail(app);
List<MailInfo> mailInfos = new List<MailInfo>();
List<MailInfo> CCInfos = new List<MailInfo>();
List<AttachmentsInfo> AttachmentsInfos = new List<AttachmentsInfo>();
mailInfos.Add(new MailInfo("awc0450056@gmail.com"));
CCInfos.Add(new MailInfo("awc0450056@gmail.com"));

FileStream fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "appsettings.json", FileMode.Open);
AttachmentsInfos.Add(new AttachmentsInfo
{
    FileName = "測試檔案.json",
    FileType = MediaTypeNames.Application.Json,
    FileStream = fileStream
});
Mail.SendMail(mailInfos, CCInfos, AttachmentsInfos, "測試寄信標題", "測試寄信功能", false);

Console.WriteLine("Hello, World!");
