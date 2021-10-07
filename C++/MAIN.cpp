#include "stdafx.h"

//Establish Variables
bool bPRESET1 = false, bPRESET2 = false, bPRESET3 = false;
string sPRESET1 = " ", sPRESET2 = " ", sPRESET3 = " ";
bool bADSFLAG = false;
string sFLAG = "X";

int main()
{
    //Prepare Console Window
    _setWindow(30, 10);
    SetConsoleTitle(L"Unicoil");
    recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sFLAG);
    while (recoilSELECTION)
    {
        //Keybinds
        if (GetAsyncKeyState(VK_NUMPAD1) & 1)
        {
            if (!bPRESET2 && !bPRESET3)
            {
                bPRESET1 = !bPRESET1;
                if (bPRESET1)
                {
                    sPRESET1 = "X";
                    _clearConsole();
                    cout << "\007" << endl;;
                    recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sFLAG);
                }
                else
                {
                    sPRESET1 = " ";
                    _clearConsole();
                    recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sFLAG);
                }
            }
        }

        if (GetAsyncKeyState(VK_NUMPAD2) & 1)
        {
            if (!bPRESET1 && !bPRESET3)
            {
                bPRESET2 = !bPRESET2;
                if (bPRESET2)
                {
                    sPRESET2 = "X";
                    _clearConsole();
                    cout << "\007" << endl;;
                    recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sFLAG);
                }
                else
                {
                    sPRESET2 = " ";
                    _clearConsole();
                    recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sFLAG);
                }
            }
        }

        if (GetAsyncKeyState(VK_NUMPAD3) & 1)
        {
            if (!bPRESET1 && !bPRESET2)
            {
                bPRESET3 = !bPRESET3;
                if (bPRESET3)
                {
                    sPRESET3 = "X";
                    _clearConsole();
                    cout << "\007" << endl;;
                    recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sFLAG);
                }
                else
                {
                    sPRESET3 = " ";
                    _clearConsole();
                    recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sFLAG);
                }
            }
        }

        //ADS Flag & Panic Key
        if (GetAsyncKeyState(VK_INSERT) & 1)
        {
            bADSFLAG = !bADSFLAG;

            if (bADSFLAG)
            {
                sFLAG = " ";
                _clearConsole();
                recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sFLAG);
            }
            else
            {
                sFLAG = "X";
                _clearConsole();
                recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sFLAG);
            }
        }

        if (GetKeyState(VK_END))
        {
            break;
        }

        //Recoil Loops
        if (bPRESET1)
        {
            if (!bADSFLAG)
            {
                _flaggedCOIL(7, 7);
            }
            else
            {
                _UniCoil(7, 7);
            }
        }

        if (bPRESET2)
        {
            if (!bADSFLAG)
            {
                _flaggedCOIL(10, 10);
            }
            else
            {
                _UniCoil(10, 10);
            }
        }

        if (bPRESET3)
        {
            if (!bADSFLAG)
            {
                _flaggedCOIL(15, 15);
            }
            else
            {
                _UniCoil(15, 15);
            }
        }
        
        //Timer
        Sleep(1);
    }
}