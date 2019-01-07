#include<stdio.h>
#include<wchar.h>

#ifndef QQMusic_CStyle_LibraryH
#define QQMusic_CStyle_LibraryH
/*按音乐名搜索的参数*/
struct SearchArg
{
	int page;   /*页码*/
	int pageSize;  /*每页最多数量*/
	wchar_t keywords[64];     /*歌曲名搜索关键字*/
};

enum EnumFileType //: int //C可能不支持这种写法，用下面的UnionFileType hack
{
	Ape = 0x00000002,
	Flac = 0x00000004,
	Mp3_320k = 0x00000008,
	Mp3_128k = 0x00000010,
};

/*用来确保有与int占用相同的字节 */
union UnionFileType {
	EnumFileType a;
	int fix;
};

struct Native_SongItem
{
	wchar_t file_strMediaMid[16];
	wchar_t album_name[64];
	wchar_t singer_name[64];   //多个用逗号分开
	UnionFileType fileType;
};

struct SearchResult {
	int curnum;
	int curpage;
	int totalnum;
	Native_SongItem Psong[];
};


struct MarshalArrayTestClass
{
	int abc[2];
};


//测试
wchar_t* test();
/*
搜索歌曲
*/
bool SearchMusicByName(SearchArg*, SearchResult*);

void testMarshalArray(MarshalArrayTestClass *);
#endif // !QQMusic_CStyle_LibraryH








