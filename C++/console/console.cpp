#include "stdafx.h"

void _clearConsole()
{
    system("cls");
}

void _setConsole()
{
    //Set Cursor to Draw From Beginning
    //Credit : Acidix -- Guided Hacking 
    COORD coords;
    coords.X = 0;
    coords.Y = 0;
    HANDLE stdHandle = GetStdHandle(STD_OUTPUT_HANDLE);
    SetConsoleCursorPosition(stdHandle, coords);
}

void _setWindow(int Width, int Height)
{
    _COORD coord;
    coord.X = Width;
    coord.Y = Height;

    _SMALL_RECT Rect;
    Rect.Top = 0;
    Rect.Left = 0;
    Rect.Bottom = Height - 1;
    Rect.Right = Width - 1;

    HANDLE Handle = GetStdHandle(STD_OUTPUT_HANDLE);      // Get Handle
    SetConsoleScreenBufferSize(Handle, coord);            // Set Buffer Size
    SetConsoleWindowInfo(Handle, TRUE, &Rect);            // Set Window Size
}

void recoilSELECTION(string& HACK1 , string& HACK2, string& HACK3, string& HACK4, string& FLAG)
{
    _setConsole();
    std::cout << " _______________________ \n";
    std::cout << "|-------NO RECOIL-------|\n";
    std::cout << "| [1] PRESET 1   => [" << HACK1 << "] |\n";
    std::cout << "| [2] PRESET 2   => [" << HACK2 << "] |\n";
    std::cout << "| [3] PRESET 3   => [" << HACK3 << "] |\n";
    std::cout << "| [4] RAPID FIRE => [" << HACK4 << "] |\n";
    std::cout << "| [INS] REQ ADS: => [" << FLAG << "] |\n";
    std::cout << "| [HOME] CUSTOM         |\n";
    std::cout << "| [END] QUIT            |\n";
    std::cout << "|v1.2-------NightFyre---|" << std::endl;
}