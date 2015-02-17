// Ciris1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <Windows.h>

int _tmain(int argc, _TCHAR* argv[])
{

	HDC hdc = GetDC(NULL);
	while (1)
	{
		for (int i = 0; i < 800; i++) {
			if (GetPixel(hdc, i, i) == RGB(100,100,200)) {

			}
			SetPixel(hdc, i, i, RGB(100,100,200));
		}
		Sleep(1);
	}
	return 0;

	return 0;
}

