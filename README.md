# Hzexe.QQMusic
解析QQ音乐的库,支持无损品质解析和下载<br />

[![Telegram Chat](https://img.shields.io/badge/Chat-Telegram-blue.svg)](https://t.me/hzexe)
[![license](https://img.shields.io/github/license/hzexe/Hzexe.QQMusic.svg)](https://raw.githubusercontent.com/hzexe/Hzexe.QQMusic/master/LICENSE)

|Package|Branch|Visual Studio 2017|Appveyor|
|:-----:|:----:|:---:|:---:|
| [NuGet ![NuGet Release](https://img.shields.io/nuget/vpre/QQMusicLib.svg?label=QQMusicLib&maxAge=3600)](https://www.nuget.org/packages/QQMusicLib/) | `master` |  [![Build status](https://hzexe.visualstudio.com/Hzexe.QQMusic/_apis/build/status/Hzexe.QQMusic-.NET%20Desktop-CI?branchName=master)](https://hzexe.visualstudio.com/Hzexe.QQMusic/_build/latest?definitionId=1) | [![Build status](https://ci.appveyor.com/api/projects/status/6y3vc0nbnuua6cx6/branch/master?svg=true)](https://ci.appveyor.com/project/hzexe/hzexe-qqmusic/branch/master) |

## 功能
* 按歌名搜索
* 下载指定歌曲的指定品质文件
* 下载歌词

## 演示截图

![截图](https://raw.githubusercontent.com/hzexe/Hzexe.QQMusic/master/Example/eg.png)

## 安装

Package manager:

```powershell
Install-Package QQMusicLib
```
.NET CLI:

```bash
dotnet add package QQMusicLib
```

## 使用示例
---
[https://github.com/hzexe/Hzexe.QQMusic/tree/master/Example](Example)

## 从源码编译
1. 获取源码
```bash
git clone https://github.com/hzexe/Hzexe.QQMusic.git
```
Or
```bash
svn checkout https://github.com/hzexe/Hzexe.QQMusic.git
```
2. 修改以满足你需求的目标运行库
项目配置成支持多种.NET运行时，如果编译环境缺少相关SDK，导致编译部分失败或完全失败.错误号MSB3644，提示大致是：

* /home/android/dotnet/sdk/2.2.101/Microsoft.Common.CurrentVersion.targets(1179,5): error MSB3644: The reference assemblies for framework ".NETFramework,Version=v4.5" were not found. To resolve this, install the SDK or Targeting Pack for this framework version or retarget your application to a version of the framework for which you have the SDK or Targeting Pack installed. Note that assemblies will be resolved from the Global Assembly Cache (GAC) and will be used in place of reference assemblies. Therefore your assembly may not be correctly targeted for the framework you intend. [/home/android/Hzexe.QQMusic/Example/WindowsFormsApp/WindowsFormsApp.csproj] *

:使用文本编辑工具打开QQMusic.hzexe.com.csproj,修改[TargetFrameworks!](https://github.com/hzexe/Hzexe.QQMusic/blob/e5fd85d54a792093c4ec6aa959e1e8566f57d8d7/QQMusic.hzexe.com/QQMusic.hzexe.com.csproj#L4)
比如在非Windows下修改成
```xml
<TargetFrameworks>netstandard1.6;netstandard2.0</TargetFrameworks>
```
比如Windows下修改成
```xml
<TargetFrameworks>net45</TargetFrameworks>
```
等
3. 编译工具执行编译
    
    1. Visual Studio 2017
	    打开解决方案直接编译成Release或在开发人员命令提示符下运行msbuild /p:Configuration=Release
	2. .NET Core（2.1或以上版本,已知在Linux Arm64下需要3.0或以上版本[coreclr issues 19578!](https://github.com/dotnet/coreclr/issues/19578#issuecomment-427592817)）
		dotnet build -f netstandard1.6 QQMusic.hzexe.com

其它
---
限技术交流,不对使用本库后果负责
