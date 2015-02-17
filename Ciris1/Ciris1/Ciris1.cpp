// Ciris1.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"
#include <Windows.h>
#include <iostream>
#include <string>


using namespace std;

int main() //_tmain(int argc, _TCHAR* argv[])
{

	HDC hdc = GetDC(NULL);
	while (1)
	{
		for (int i = 0; i < 800; i++) {
			for (int j = 0; j < 800; j++) {
				//if (GetPixel(hdc, i, i) == RGB(100,100,200)) {
				//std::cout << "Got in here" << std::endl;
				//}
				SetPixel(hdc, i, j, RGB(100, 100, 200));
			}
		}
		Sleep(1);
	}
	return 0;
}

