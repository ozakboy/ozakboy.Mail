# ozakboy.Mail   

> �H�H�\���X�A�ֳt�o�H(�t�����ɮ�)

�n�إ� appsettings.json  �ɮצb�ڥؿ�

�ó]�w �ݭn���o�H���T�w�\��

```
  "SmtpMailConfig": {
    "Port": 25,
    "Host": "�A��SMTP HOST",
    "UserName": "�b��",
    "Password": "�K�X",
    "Name": "�A���H�H�W��"
  }
```

WebApi ���U����覡

�b Program.cs �ɮפ�
```
builder.Services.AddScoped<IMail, Mail>();
```

��L�{�����U����覡
```
var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
var app = builder.Build();

IMail Mail = new Mail(app);
```

>�����w���t�~�w��

Microsoft.Extensions.Configuration

Microsoft.Extensions.Configuration.Binder

Microsoft.Extensions.Configuration.Json



>Nuget �ۨ�

Microsoft.Extensions.Configuration.Abstractions

Microsoft.Extensions.Configuration.Binder