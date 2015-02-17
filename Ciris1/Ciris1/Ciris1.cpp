// Ciris1.cpp : Defines the entry point for the console application.
//

//#include "stdafx.h"
#include <Windows.h>
#include <iostream>
#include <string>
#include <cstdlib>

using namespace std;

// Get the horizontal and vertical screen sizes in pixel
void GetDesktopResolution(int& horizontal, int& vertical)
{
	RECT desktop;
	// Get a handle to the desktop window
	const HWND hDesktop = GetDesktopWindow();
	// Get the size of screen to the variable desktop
	GetWindowRect(hDesktop, &desktop);
	// The top left corner will have coordinates (0,0)
	// and the bottom right corner will have coordinates
	// (horizontal, vertical)
	horizontal = desktop.right;
	vertical = desktop.bottom;
}

// Margin of Error for CloseTo
int moe = 10;

bool CloseTo(int val, int target) {

	//printf("Value: %i - Target: %i\n", val, target);

	if ((target >= val && val >= (target - moe)) || (target <= val && val <= (target + moe))) {
		return true;
	}
	return false;
}

int main() //_tmain(int argc, _TCHAR* argv[])
{

	// Getting the width and the height of the screen.
	int width = 0;
	int height = 0;
	GetDesktopResolution(width, height);
	printf("Width: %i - Height: %i\n", width, height);
	// Setting the blue color.
	COLORREF blueCol = RGB(0, 116, 195);
	COLORREF temp;
	HDC hdc = GetDC(NULL);

	while (1)
	{
		for (int i = 0; i < 80; i++) {
			for (int j = 0; j < 200; j++) {
				//POINT _cursor;
				//GetCursorPos(&_cursor);
				//printf("Cursor x: %i - Cursor y: %i\n", _cursor.x, _cursor.y);
				temp = GetPixel(hdc, i, j);


				int _red = GetRValue(temp);
				int _green = GetGValue(temp);
				int _blue = GetBValue(temp);

				/*printf("Red: %i\n", _red);
				printf("Green: %i\n", _green);
				printf("Blue: %i\n", _blue);*/

				if (CloseTo(_red, 0) && CloseTo(_green, 116) && CloseTo(_blue, 195)) {
					printf("Changing pixel at: %i , %i\n", i, j);
					SetPixel(hdc, i, j, RGB(255, 100, 0));
				}
				else {
					SetPixel(hdc, i, j, RGB(0, 0, 0));
				}
				
				/*printf("Red: 0x%02x\n", _red);
				printf("Green: 0x%02x\n", _green);
				printf("Blue: 0x%02x\n", _blue);*/
				//Sleep(10000);
				
			}
			//printf("Completed line %i\n", i);
		}
		Sleep(1);
	}
	return 0;
}




/*static void DetectColorWithUnsafe(Bitmap image,
	byte searchedR, byte searchedG, int searchedB, int tolerance)
{
	BitmapData imageData = image.LockBits(new Rectangle(0, 0, image.Width,
		image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);


	int bytesPerPixel = 3;

	byte* scan0 = (byte*)imageData.Scan0.ToPointer();
	int stride = imageData.Stride;

	byte unmatchingValue = 0;
	byte matchingValue = 255;
	int toleranceSquared = tolerance * tolerance;

	for (int y = 0; y < imageData.Height; y++)
	{
		byte* row = scan0 + (y * stride);

		for (int x = 0; x < imageData.Width; x++)
		{
			// Watch out for actual order (BGR)!
			int bIndex = x * bytesPerPixel;
			int gIndex = bIndex + 1;
			int rIndex = bIndex + 2;

			byte pixelR = row[rIndex];
			byte pixelG = row[gIndex];
			byte pixelB = row[bIndex];

			int diffR = pixelR - searchedR;
			int diffG = pixelG - searchedG;
			int diffB = pixelB - searchedB;

			int distance = diffR * diffR + diffG * diffG + diffB * diffB;

			row[rIndex] = row[bIndex] = row[gIndex] = distance >
				toleranceSquared ? unmatchingValue : matchingValue;
		}
	}

	image.UnlockBits(imageData);
}

/*
int main() {
	HDC hdc, hdcTemp;
	RECT rect;
	BYTE* bitPointer;
	int x, y;
	int red, green, blue, alpha;

	while (true)
	{
		hdc = GetDC(NULL);
		GetWindowRect(NULL, &rect);
		int MAX_WIDTH = rect.right;
		int MAX_HEIGHT = rect.bottom;

		hdcTemp = CreateCompatibleDC(hdc);
		BITMAPINFO bitmap;
		bitmap.bmiHeader.biSize = sizeof(bitmap.bmiHeader);
		bitmap.bmiHeader.biWidth = MAX_WIDTH;
		bitmap.bmiHeader.biHeight = MAX_HEIGHT;
		bitmap.bmiHeader.biPlanes = 1;
		bitmap.bmiHeader.biBitCount = 32;
		bitmap.bmiHeader.biCompression = BI_RGB;
		bitmap.bmiHeader.biSizeImage = MAX_WIDTH * 4 * MAX_HEIGHT;
		bitmap.bmiHeader.biClrUsed = 0;
		bitmap.bmiHeader.biClrImportant = 0;
		HBITMAP hBitmap2 = CreateDIBSection(hdcTemp, &bitmap, DIB_RGB_COLORS, (void**)(&bitPointer), NULL, NULL);
		SelectObject(hdcTemp, hBitmap2);
		BitBlt(hdcTemp, 0, 0, MAX_WIDTH, MAX_HEIGHT, hdc, 0, 0, SRCCOPY);

		for (int i = 0; i < (MAX_WIDTH * 4 * MAX_HEIGHT); i += 4)
		{
			red = (int)bitPointer[i];
			green = (int)bitPointer[i + 1];
			blue = (int)bitPointer[i + 2];
			alpha = (int)bitPointer[i + 3];

			x = i / (4 * MAX_HEIGHT);
			y = i / (4 * MAX_WIDTH);

			if (red == 255 && green == 0 && blue == 0)
			{
				SetCursorPos(x, y);
				mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
				Sleep(50);
				mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
				Sleep(25);
			}
		}
	}
}*/