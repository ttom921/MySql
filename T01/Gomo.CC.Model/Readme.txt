﻿ Scaffold-DbContext -Connection "Server=127.0.0.1;Database=Blogging;User ID=root;Password=12345678;" -Context "GomoCCDBContext"  -Provider Pomelo.EntityFrameworkCore.MySql -OutputDir "" -Project Gomo.CC.Model  -force -verbose
 1.在編輯專案檔 Gomo.CC.Model.csproj,要加入
   <PropertyGroup>
    <TargetFramework>netcoreapp2.0</TargetFramework>
    <GenerateRuntimeConfigurationFiles>true</GenerateRuntimeConfigurationFiles>
</PropertyGroup>
 <ItemGroup>
    <DotNetCliToolReference Include="Microsoft.EntityFrameworkCore.Tools.DotNet" Version="2.0.1" />
 </ItemGroup>
 2.在專案的目錄下，使用命令行可以執行 dotnet ef 如果有獨角獸就是成功了
  dotnet ef dbcontext scaffold "Server=127.0.0.1;Database=Blogging;User ID=root;Password=12345678;" Pomelo.EntityFrameworkCore.MySql -c "GomoCCDBContext"  -f -v 
 //dotnet ef dbcontext scaffold "Server=127.0.0.1;Database=Blogging;User ID=root;Password=12345678;" Pomelo.EntityFrameworkCore.MySql -c "GomoCCDBContext"  -f -v --use-database-names
 //dotnet ef dbcontext scaffold "Server=127.0.0.1;Database=Blogging;User ID=root;Password=12345678;" Pomelo.EntityFrameworkCore.MySql -c "GomoCCDBContext"  -f -v -d

