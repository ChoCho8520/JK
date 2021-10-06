#include "stdafx.h"

void _UniCoil(int speed, int delay)
{
    if ((GetKeyState(VK_LBUTTON) & 0x100) != 0)
    {
        mouse_event(MOUSEEVENTF_MOVE, 0, speed, NULL, NULL);
        Sleep(delay);
    }
}

void _flaggedCOIL(int speed, int delay)
{
    if ((GetKeyState(VK_RBUTTON) & 0x100) != 0)
    {
        if ((GetKeyState(VK_LBUTTON) & 0x100) != 0)
        {
            mouse_event(MOUSEEVENTF_MOVE, 0, speed, NULL, NULL);
            Sleep(delay);
        }
    }
}