[![nuget](https://img.shields.io/badge/nuget-ozakboy.Mail-blue)](https://www.nuget.org/packages/Ozakboy.Mail/) [![github](https://img.shields.io/badge/github-ozakboy.Mail-blue)](https://github.com/ozakboy/ozakboy.Mail)

# Ozakboy.Mail

簡單易用的 .NET 郵件發送套件，支援 SMTP 協定發送郵件，包含附件功能。

## 版本

目前版本：**1.0.2**

[查看更新紀錄](CHANGELOG.md)

## 要求

- .NET 6.0 或更高版本

## 功能

- SMTP 郵件發送
- 支援多位收件者
- 支援副本 (CC) 收件者
- 支援附件檔案
- 支援 HTML 格式郵件內容
- 支援 SSL/TLS 加密連線

## 安裝

透過 NuGet 套件管理員安裝：

```bash
dotnet add package Ozakboy.Mail
```

## 設定

### 1. 建立 appsettings.json

在專案根目錄建立 `appsettings.json` 檔案並加入 SMTP 設定：

#### Gmail 設定範例

```json
{
  "SmtpMailConfig": {
    "Port": 587,
    "Host": "smtp.gmail.com",
    "UserName": "your-email@gmail.com",
    "Password": "your-app-password",
    "Name": "寄件者顯示名稱"
  }
}
```

**重要提醒：使用 Gmail 時請注意**
- Port 請使用 `587` (TLS)
- Password 需使用「應用程式密碼」而非 Gmail 帳號密碼
- 如何取得應用程式密碼：[Google 帳戶安全性設定](https://myaccount.google.com/security)

#### 其他 SMTP 伺服器設定範例

```json
{
  "SmtpMailConfig": {
    "Port": 25,
    "Host": "你的SMTP HOST",
    "UserName": "帳號",
    "Password": "密碼",
    "Name": "你的寄信名稱"
  }
}
```

### 2. 註冊服務

#### WebAPI 專案 (Program.cs)

```csharp
builder.Services.AddScoped<IMail, Mail>();
```

#### Console 或其他類型專案

```csharp
using Microsoft.Extensions.Configuration;
using Ozakboy.Mail;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json");
var app = builder.Build();

IMail Mail = new Mail(app);
```

**需要額外安裝的套件：**

```bash
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.Binder
dotnet add package Microsoft.Extensions.Configuration.Json
```

## 使用方法

### SendMail 方法

發送郵件的主要方法。

#### 參數說明

- `ReceiveInfos` (List&lt;MailInfo&gt;) - 收件人列表
- `CCInfos` (List&lt;MailInfo&gt;) - 副本收件人列表
- `AttachmentsInfos` (List&lt;AttachmentsInfo&gt;) - 附件列表
- `MailSubject` (string) - 郵件主旨
- `MailBody` (string) - 郵件內容
- `IsBodyHtml` (bool) - 內容是否為 HTML 格式，預設為 true

#### 基本範例

```csharp
using Ozakboy.Mail;

// 建立收件者
List<MailInfo> receivers = new List<MailInfo>
{
    new MailInfo("receiver@example.com", "收件者名稱")
};

// 發送純文字郵件
Mail.SendMail(receivers, null, null, "測試主旨", "測試內容", false);
```

#### 完整範例（包含副本和附件）

```csharp
using Ozakboy.Mail;
using System.Net.Mime;

// 收件者
List<MailInfo> receivers = new List<MailInfo>
{
    new MailInfo("receiver1@example.com", "收件者1"),
    new MailInfo("receiver2@example.com") // 可以不指定名稱
};

// 副本收件者
List<MailInfo> ccReceivers = new List<MailInfo>
{
    new MailInfo("cc@example.com", "副本收件者")
};

// 附件
List<AttachmentsInfo> attachments = new List<AttachmentsInfo>();
FileStream fileStream = new FileStream("document.pdf", FileMode.Open);
attachments.Add(new AttachmentsInfo
{
    FileName = "文件.pdf",
    FileType = MediaTypeNames.Application.Pdf,
    FileStream = fileStream
});

// 發送郵件
Mail.SendMail(
    receivers,
    ccReceivers,
    attachments,
    "重要通知",
    "<h1>這是 HTML 郵件</h1><p>內容...</p>",
    true
);
```

## 相依套件

本套件自動包含以下相依項目：

- Microsoft.Extensions.Configuration.Abstractions (6.0.0)
- Microsoft.Extensions.Configuration.Binder (6.0.0)

## 授權

本專案採用 MIT 授權條款。

## 問題回報

如有任何問題或建議，歡迎在 [GitHub Issues](https://github.com/ozakboy/ozakboy.Mail/issues) 提出。

## 貢獻

歡迎提交 Pull Request 來改善此專案！
