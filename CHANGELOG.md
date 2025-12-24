# Changelog

所有關於 Ozakboy.Mail 專案的重要更改都會記錄在此檔案中。

## [1.0.2] - 2025-12-24

### 修正
- 修正副本收件者 (CC) 錯誤使用 `Bcc` (密件副本) 的問題，現在正確使用 `MailMessage.CC`
- 修正 `VMailSettings` 和 `VSmtpMailConfig` 類別的存取修飾詞從 `internal` 改為 `public`，解決設定綁定失敗的問題
- 新增 SMTP 設定的 null 檢查，當設定未正確配置時會拋出 `InvalidOperationException`
- 新增附件 FileStream 的 null 檢查，避免 null 參考異常

### 改善
- 移除所有 C# nullable 警告
- 為所有 ViewModel 屬性添加預設值
- 更新 Gmail SMTP 設定範例，使用正確的 Port 587

### 文件
- 更新 README.md，包含更清楚的設定說明和 Gmail 專用設定範例
- 新增 CHANGELOG.md 記錄版本變更

## [1.0.1] - 先前版本

初始發布版本

## [1.0.0] - 初始版本

首次發布
