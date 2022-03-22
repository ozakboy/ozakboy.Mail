# ozakboy.Mail   

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

>Nuget 相依

Microsoft.Extensions.Configuration.Abstractions

Microsoft.Extensions.Configuration.Binder