# NuGet 套件檢查腳本
# 執行前請確保已安裝 NuGet CLI 工具

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Ozakboy.Mail 套件檢查工具" -ForegroundColor Cyan
Write-Host "========================================`n" -ForegroundColor Cyan

$projectPath = "Ozakboy.Mail\Ozakboy.Mail"
$releasePath = "$projectPath\bin\Release"

# 檢查專案檔案
Write-Host "1. 檢查專案檔案..." -ForegroundColor Yellow
if (Test-Path "$projectPath\Ozakboy.Mail.csproj") {
    Write-Host "   ✓ Ozakboy.Mail.csproj 存在" -ForegroundColor Green
} else {
    Write-Host "   ✗ Ozakboy.Mail.csproj 不存在" -ForegroundColor Red
    exit 1
}

# 檢查 README
Write-Host "`n2. 檢查 README.md..." -ForegroundColor Yellow
if (Test-Path "README.md") {
    Write-Host "   ✓ README.md 存在" -ForegroundColor Green
    $readmeSize = (Get-Item "README.md").Length
    Write-Host "   檔案大小: $readmeSize bytes" -ForegroundColor Gray
} else {
    Write-Host "   ✗ README.md 不存在" -ForegroundColor Red
}

# 檢查 CHANGELOG
Write-Host "`n3. 檢查 CHANGELOG.md..." -ForegroundColor Yellow
if (Test-Path "CHANGELOG.md") {
    Write-Host "   ✓ CHANGELOG.md 存在" -ForegroundColor Green
} else {
    Write-Host "   ✗ CHANGELOG.md 不存在" -ForegroundColor Red
}

# 檢查 LICENSE
Write-Host "`n4. 檢查 LICENSE..." -ForegroundColor Yellow
if (Test-Path "LICENSE") {
    Write-Host "   ✓ LICENSE 存在" -ForegroundColor Green
} else {
    Write-Host "   ✗ LICENSE 不存在" -ForegroundColor Red
}

# 讀取版本號
Write-Host "`n5. 檢查版本資訊..." -ForegroundColor Yellow
$csprojContent = Get-Content "$projectPath\Ozakboy.Mail.csproj" -Raw
if ($csprojContent -match '<Version>(.*?)</Version>') {
    $version = $Matches[1]
    Write-Host "   當前版本: $version" -ForegroundColor Green
} else {
    Write-Host "   ✗ 無法讀取版本號" -ForegroundColor Red
}

# 檢查 Release 建置
Write-Host "`n6. 檢查 Release 建置檔案..." -ForegroundColor Yellow
if (Test-Path $releasePath) {
    $nupkgFile = Get-ChildItem -Path $releasePath -Filter "*.nupkg" | Select-Object -First 1
    if ($nupkgFile) {
        Write-Host "   ✓ 找到 NuGet 套件: $($nupkgFile.Name)" -ForegroundColor Green
        Write-Host "   檔案大小: $([math]::Round($nupkgFile.Length / 1KB, 2)) KB" -ForegroundColor Gray
        Write-Host "   建立時間: $($nupkgFile.LastWriteTime)" -ForegroundColor Gray
    } else {
        Write-Host "   ✗ 找不到 .nupkg 檔案" -ForegroundColor Red
        Write-Host "   請執行: dotnet build -c Release" -ForegroundColor Yellow
    }

    $dllFile = Get-ChildItem -Path "$releasePath\net6.0" -Filter "Ozakboy.Mail.dll" -ErrorAction SilentlyContinue
    if ($dllFile) {
        Write-Host "   ✓ 找到 DLL: $($dllFile.Name)" -ForegroundColor Green
    }

    $xmlFile = Get-ChildItem -Path "$releasePath\net6.0" -Filter "Ozakboy.Mail.xml" -ErrorAction SilentlyContinue
    if ($xmlFile) {
        Write-Host "   ✓ 找到 XML 文件: $($xmlFile.Name)" -ForegroundColor Green
    } else {
        Write-Host "   ! 警告: 找不到 XML 文件檔" -ForegroundColor Yellow
    }
} else {
    Write-Host "   ✗ Release 資料夾不存在" -ForegroundColor Red
    Write-Host "   請執行: dotnet build -c Release" -ForegroundColor Yellow
}

# 檢查 Git 狀態
Write-Host "`n7. 檢查 Git 狀態..." -ForegroundColor Yellow
try {
    $gitStatus = git status --short
    if ($gitStatus) {
        Write-Host "   ! 有未提交的變更:" -ForegroundColor Yellow
        Write-Host $gitStatus -ForegroundColor Gray
    } else {
        Write-Host "   ✓ 工作目錄乾淨" -ForegroundColor Green
    }

    $currentBranch = git branch --show-current
    Write-Host "   當前分支: $currentBranch" -ForegroundColor Gray
} catch {
    Write-Host "   ! 無法取得 Git 資訊" -ForegroundColor Yellow
}

Write-Host "`n========================================" -ForegroundColor Cyan
Write-Host "檢查完成！" -ForegroundColor Cyan
Write-Host "========================================`n" -ForegroundColor Cyan

# 詢問是否要檢視套件內容
$viewPackage = Read-Host "是否要檢視 NuGet 套件內容？ (y/n)"
if ($viewPackage -eq 'y') {
    if ($nupkgFile) {
        Write-Host "`n正在解壓縮套件..." -ForegroundColor Yellow
        $tempPath = "$env:TEMP\ozakboy-mail-check"
        if (Test-Path $tempPath) {
            Remove-Item -Path $tempPath -Recurse -Force
        }
        Expand-Archive -Path $nupkgFile.FullName -DestinationPath $tempPath
        Write-Host "套件內容已解壓縮至: $tempPath" -ForegroundColor Green
        explorer $tempPath
    }
}
