NuGet 套件圖示說明
==================

如果您想為套件加入圖示，請執行以下步驟：

1. 準備一個 128x128 像素的 PNG 圖片
2. 命名為 icon.png
3. 放置在專案根目錄：C:\Users\WIN\source\repos\Ozakboy\ozakboy.Mail\icon.png
4. 在 Ozakboy.Mail.csproj 中加入以下設定：

<ItemGroup>
  <None Include="..\..\..\..\icon.png" Pack="true" PackagePath="\" />
</ItemGroup>

5. 在 <PropertyGroup> 中加入：
<PackageIcon>icon.png</PackageIcon>

建議的圖示內容：
- 信封圖案
- 郵件符號
- 使用品牌色彩
- 簡單清晰的設計

線上圖示資源：
- https://www.flaticon.com/
- https://icons8.com/
- https://www.iconfinder.com/

注意：圖示檔案大小建議在 10KB 以內
