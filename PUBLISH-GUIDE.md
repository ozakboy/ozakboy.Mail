# NuGet 發佈指南

## 準備工作

### 1. 檢查版本號

確認 `Ozakboy.Mail.csproj` 中的版本號已更新：
```xml
<Version>1.0.2</Version>
```

### 2. 建置 Release 版本

```bash
cd C:\Users\WIN\source\repos\Ozakboy\ozakboy.Mail\Ozakboy.Mail\Ozakboy.Mail
dotnet build -c Release
```

建置後會產生：
- `bin\Release\Ozakboy.Mail.1.0.2.nupkg` - NuGet 套件檔
- `bin\Release\net6.0\Ozakboy.Mail.dll` - 編譯後的 DLL
- `bin\Release\net6.0\Ozakboy.Mail.xml` - XML 文件檔

### 3. 測試套件

在發佈前先在本機測試套件：

```bash
# 建立本機 NuGet 來源（只需執行一次）
dotnet nuget add source "C:\Users\WIN\source\repos\Ozakboy\ozakboy.Mail\Ozakboy.Mail\Ozakboy.Mail\bin\Release" -n "Local"

# 在測試專案中安裝
cd <測試專案路徑>
dotnet add package Ozakboy.Mail -s Local
```

## 發佈到 NuGet.org

### 1. 取得 API Key

1. 前往 https://www.nuget.org/
2. 登入您的帳號
3. 點擊右上角頭像 → API Keys
4. 點擊 "Create" 建立新的 API Key
5. 設定：
   - Key Name: `Ozakboy.Mail`
   - Select Scopes: `Push` 和 `Push new packages and package versions`
   - Select Packages: `*` (或選擇 Ozakboy.Mail)
   - Expiration: 設定過期時間（建議 365 天）
6. 複製生成的 API Key（只會顯示一次！）

### 2. 發佈套件

```bash
cd C:\Users\WIN\source\repos\Ozakboy\ozakboy.Mail\Ozakboy.Mail\Ozakboy.Mail\bin\Release

# 發佈到 NuGet
dotnet nuget push Ozakboy.Mail.1.0.2.nupkg --api-key <您的API Key> --source https://api.nuget.org/v3/index.json
```

或使用完整指令：

```bash
dotnet nuget push Ozakboy.Mail.1.0.2.nupkg ^
  --api-key <您的API Key> ^
  --source https://api.nuget.org/v3/index.json ^
  --skip-duplicate
```

### 3. 驗證發佈

1. 前往 https://www.nuget.org/packages/Ozakboy.Mail/
2. 確認版本號已更新
3. 檢查 README 是否正確顯示
4. 確認相依套件是否正確

### 4. 測試安裝

```bash
# 在新專案中測試安裝
dotnet new console -n TestOzakboyMail
cd TestOzakboyMail
dotnet add package Ozakboy.Mail
```

## 更新套件版本

### 1. 更新版本號

修改 `Ozakboy.Mail.csproj`：
```xml
<Version>1.0.3</Version>
<AssemblyVersion>1.0.3.0</AssemblyVersion>
<FileVersion>1.0.3.0</FileVersion>
```

### 2. 更新 CHANGELOG.md

在 CHANGELOG.md 最上方加入新版本資訊。

### 3. 更新 PackageReleaseNotes

在 `Ozakboy.Mail.csproj` 中更新：
```xml
<PackageReleaseNotes>
v1.0.3 (2025-XX-XX)
- 新功能或修正...
</PackageReleaseNotes>
```

### 4. 重複發佈流程

重新建置並發佈新版本。

## 常見問題

### Q: 發佈後多久會在 NuGet.org 上看到？

A: 通常 5-10 分鐘內會索引完成，但有時可能需要 30 分鐘。

### Q: 如何刪除已發佈的版本？

A: NuGet 不允許刪除套件，只能 "unlist"（不列出）：
1. 登入 NuGet.org
2. 進入套件管理頁面
3. 選擇 "Unlist" 該版本

### Q: 如何更新套件的 README？

A: 只能透過發佈新版本來更新 README。建議使用 Patch 版本號（如 1.0.2.1）。

### Q: 發佈失敗顯示 409 Conflict？

A: 該版本號已存在，需要更新版本號後重新發佈。

## 檢查清單

發佈前請確認：

- [ ] 版本號已更新
- [ ] CHANGELOG.md 已更新
- [ ] README.md 內容正確
- [ ] 所有測試通過
- [ ] Release 模式建置成功
- [ ] API Key 已準備
- [ ] 確認要發佈的分支正確（通常是 main）

## 參考資源

- [NuGet 官方文件](https://learn.microsoft.com/zh-tw/nuget/)
- [建立 NuGet 套件](https://learn.microsoft.com/zh-tw/nuget/create-packages/creating-a-package)
- [發佈 NuGet 套件](https://learn.microsoft.com/zh-tw/nuget/nuget-org/publish-a-package)
