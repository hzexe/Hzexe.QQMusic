//Copyright by hzexe https://github.com/hzexe
//All rights reserved
//See the LICENSE file in the project root for more information.

#include "pch.h"
#include <iostream>
#include <stdio.h>
#include <locale.h>

extern "C" {
#include "..\..\QQMusic_Native_Library\QQMusic_Native_Library.h"
}

int main()
{
	std::locale::global(std::locale(""));
	std::wcout.imbue(std::locale(""));

	wchar_t keyword[] = L"沙漠骆驼";
	SearchArg search;
	memset(&search, 0, sizeof(search));
	search.page = 0;
	search.pageSize = 100;
	memcpy_s(&search.keywords, sizeof(search.keywords), keyword, sizeof(keyword));

	int size = 1024*30;
	SearchResult *sresult=(SearchResult *) malloc(size);

	if (SearchMusicByName(&search, sresult))
	{
		printf("本次搜索出%d条记录\r\n", sresult->curnum);
		printf("%s\t", "歌名");
		printf("%s\t", "专辑");
		printf("%s\r\n", "歌手");
		for (size_t i = 0; i < sresult->curnum; i++)
		{
			Native_SongItem* Psong = &sresult->Psong[i];
			wprintf(L"%s\t", Psong->name);
			wprintf(L"%s\t", Psong->album_name);
			wprintf(L"%s\r\n",  Psong->singer_name);
		}
		printf("下载第2首歌吧\n");
		Native_SongItem* song = &sresult->Psong[1];
		EnumFileType type = song->fileType.a;
		enum EnumFileType downloadType;
		if (type & Ape)
			downloadType = Ape;
		else if(type&Flac)
			downloadType = Flac;
		else if (type&Mp3_320k)
			downloadType = Mp3_320k;
		else if (type&m4a)
			downloadType = m4a;
		else
			downloadType = Mp3_128k;
		const wchar_t dir[] = L"./"; //下载存放的目录
		

		if (DownloadMusic(song, downloadType, dir, wcslen(dir)))
		{
			printf("下载成功\n");
		}
		else
		{
			printf("下载失败\n");
		}
	}
	else
	{
		std::cout << "搜索失败\n";
	}
	delete(sresult);
}
