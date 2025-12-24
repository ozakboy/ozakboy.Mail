# Ozakboy.Mail 套件資訊

## 套件詳細資訊

### 基本資訊
- **套件名稱**: Ozakboy.Mail
- **目前版本**: 1.0.2
- **授權**: MIT License
- **作者**: ozakboy
- **目標框架**: .NET 6.0

### 套件檔案
```
Ozakboy.Mail.1.0.2.nupkg (10.4 KB)
├── lib/net6.0/
│   ├── Ozakboy.Mail.dll
│   └── Ozakboy.Mail.xml
├── README.md
└── .nuspec
```

### NuGet 頁面設定

#### 顯示資訊
- **標題**: Ozakboy.Mail - 簡易郵件發送套件
- **描述**: 簡單易用的 .NET 郵件發送套件，支援 SMTP 協定發送郵件，包含附件功能。支援多位收件者、副本收件者、HTML 格式郵件及 SSL/TLS 加密連線。
- **標籤**: email, mail, smtp, send-mail, email-sender, gmail, outlook, dotnet, csharp

#### 連結
- **專案網址**: https://github.com/ozakboy/ozakboy.Mail
- **儲存庫**: https://github.com/ozakboy/ozakboy.Mail (git)
- **授權**: MIT (https://licenses.nuget.org/MIT)

#### 相依套件
- Microsoft.Extensions.Configuration.Abstractions (6.0.0)
- Microsoft.Extensions.Configuration.Binder (6.0.0)

## 版本資訊

### v1.0.2 (2025-12-24) ✨ 最新版本
**重要修正**
- ✅ 修正副本收件者 (CC) 錯誤使用 Bcc 的問題
- ✅ 修正 VMailSettings 類別存取修飾詞問題
- ✅ 新增 SMTP 設定和附件的 null 檢查
- ✅ 改善錯誤訊息提示
- ✅ 移除所有 nullable 警告
- ✅ 更新文件說明

**技術改進**
- 新增完整的 XML 文件註解
- 改善錯誤處理機制
- 提供更詳細的除錯資訊

### v1.0.1
初始發布版本

### v1.0.0
首次發布

## 檔案說明

### 主要檔案
- `Ozakboy.Mail.csproj` - 專案設定檔（包含完整的 NuGet metadata）
- `README.md` - 套件說明文件（會包含在 NuGet 套件中）
- `CHANGELOG.md` - 版本變更記錄
- `LICENSE` - MIT 授權條款

### 程式碼檔案
- `Mail.cs` - 主要郵件發送類別
- `IMail.cs` - 郵件介面定義
- `ViewModels/VMailSettings.cs` - SMTP 設定模型
- `ViewModels/MailInfo.cs` - 收件者資訊模型
- `ViewModels/AttachmentsInfo.cs` - 附件資訊模型

### 輔助檔案
- `PUBLISH-GUIDE.md` - NuGet 發佈指南
- `PACKAGE-INFO.md` - 本檔案（套件資訊說明）
- `check-package.ps1` - PowerShell 檢查腳本
- `icon-readme.txt` - 圖示設定說明

## 套件特色

### ✨ 主要功能
1. **簡單易用**: 只需幾行程式碼即可發送郵件
2. **完整功能**: 支援多收件者、副本、附件、HTML 郵件
3. **安全連線**: 支援 SSL/TLS 加密
4. **良好文件**: 完整的 XML 文件註解和 README
5. **錯誤處理**: 清楚的錯誤訊息提示

### 📦 支援的郵件服務
- Gmail (Port 587)
- Outlook/Hotmail (Port 587)
- 其他標準 SMTP 服務

### 🔧 設定彈性
- 支援 appsettings.json 設定
- 支援依賴注入 (DI)
- 適用於 Console、WebAPI、MVC 等各種專案

## 技術規格

### 編譯輸出
- **Assembly Version**: 1.0.2.0
- **File Version**: 1.0.2.0
- **Target Framework**: net6.0
- **Language Version**: C# 10
- **Nullable**: 已啟用

### 建置設定
- **Configuration**: Release
- **Platform**: Any CPU
- **優化**: 已啟用
- **文件產生**: 已啟用 (Ozakboy.Mail.xml)

### 套件設定
- **Package On Build**: True
- **Include Symbols**: False
- **Include Source**: False
- **README**: 包含在套件中
- **License**: MIT (Expression)

## 品質保證

### ✅ 檢查項目
- [x] 無編譯警告
- [x] 無編譯錯誤
- [x] XML 文件完整
- [x] README 清楚易懂
- [x] CHANGELOG 已更新
- [x] 版本號正確
- [x] 相依套件版本明確
- [x] 授權檔案存在

### 📊 套件統計
- **總程式碼行數**: ~300 行
- **公開 API 數量**: 4 個類別
- **相依套件數量**: 2 個
- **套件大小**: ~10 KB

## 下載與安裝

### NuGet Package Manager
```
Install-Package Ozakboy.Mail
```

### .NET CLI
```bash
dotnet add package Ozakboy.Mail
```

### PackageReference
```xml
<PackageReference Include="Ozakboy.Mail" Version="1.0.2" />
```

## 支援與回饋

- **問題回報**: https://github.com/ozakboy/ozakboy.Mail/issues
- **功能建議**: https://github.com/ozakboy/ozakboy.Mail/issues
- **Pull Request**: https://github.com/ozakboy/ozakboy.Mail/pulls

## 授權

本專案採用 MIT 授權條款 - 詳見 [LICENSE](LICENSE) 檔案

Copyright © 2025 ozakboy

---

**最後更新**: 2025-12-24
**套件狀態**: ✅ 準備發佈
