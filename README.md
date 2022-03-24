## 要求

ASP.net Core 6

## 部屬

> 寄信功能整合，快速發信(含附件檔案)

要建立 appsettings.json  檔案在根目錄

並設定 需要的發信的固定功能

```
  "SmtpMailConfig": {
    "Port": 25,
    "Host": "你的SMTP HOST",
    "UserName": "帳號",
    "Password": "密碼",
    "Name": "你的寄信名稱"
  }
```

WebApi 註冊元件方式

在 Program.cs 檔案內
```
builder.Services.AddScoped<IMail, Mail>();
```

其他程式註冊元件方式
```
var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
var app = builder.Build();

IMail Mail = new Mail(app);
```

>但須安狀另外安裝

Microsoft.Extensions.Configuration

Microsoft.Extensions.Configuration.Binder

Microsoft.Extensions.Configuration.Json



>Nuget 相依

Microsoft.Extensions.Configuration.Abstractions

Microsoft.Extensions.Configuration.Binder
