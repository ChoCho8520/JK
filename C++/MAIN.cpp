#include "stdafx.h"

//Establish Variables
bool bMENU = false;
bool bPRESET1 = false, bPRESET2 = false, bPRESET3 = false, bRAPID = false;
string sPRESET1 = " ", sPRESET2 = " ", sPRESET3 = " ", sRAPID = " ";
bool bADSFLAG = false;
string sFLAG = "X";

//CUSTOM MENU
int custom();
bool bCUSTOM = false;
bool cMENU = false;
bool cRUN = false;

int main()
{
    //Prepare Console Window
    _setWindow(30, 10);
    SetConsoleTitle(L"uniCoil");
    recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPID, sFLAG);
    bMENU = true;

    //Display Main Menu
    while (bMENU)
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
                    recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPID, sFLAG);
                }
                else
                {
                    sPRESET1 = " ";
                    _clearConsole();
                    recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPID, sFLAG);
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
                    recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPID, sFLAG);
                }
                else
                {
                    sPRESET2 = " ";
                    _clearConsole();
                    recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPID, sFLAG);
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
                    recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPID, sFLAG);
                }
                else
                {
                    sPRESET3 = " ";
                    _clearConsole();
                    recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPID, sFLAG);
                }
            }
        }

        //Rapid Fire
        if (GetAsyncKeyState(VK_NUMPAD4) & 1)
        {
            bRAPID = !bRAPID;
            if (bRAPID)
            {
                sRAPID = "X";
                _clearConsole();
                recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPID, sFLAG);
            }
            else
            {
                sRAPID = " ";
                _clearConsole();
                recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPID, sFLAG);
            }
        }

        //Customize
        if (GetAsyncKeyState(VK_HOME) & 1)
        {
            _clearConsole();
            bPRESET1, bPRESET2, bPRESET3, bADSFLAG = false;
            sPRESET1, sPRESET2, sPRESET3, sFLAG = "";
            bMENU = false;
            custom();
        }

        //ADS Flag & Panic Key
        if (GetAsyncKeyState(VK_INSERT) & 1)
        {
            bADSFLAG = !bADSFLAG;

            if (bADSFLAG)
            {
                sFLAG = " ";
                _clearConsole();
                recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPID, sFLAG);
            }
            else
            {
                sFLAG = "X";
                _clearConsole();
                recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPID, sFLAG);
            }
        }

        // QUIT
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

        //Rapid Fire
        if (bRAPID)
        {
            _rapidFire(50);
        }

        //Timer
        Sleep(1);
    }
}



int custom()
{
    _setWindow(40, 10);
    //Original Custom Input Method by "Cubb"
    //Original Source Code: https://www.unknowncheats.me/forum/2871653-post1.html
    //This is just placeholder until I have finished with the C# port and start porting the new methods I introduced there

    int speed = 9;
    int delay = 9;


    //Introduce ADS Flag
    string adsFLAG;
    
    //Rapid Fire
    string rapidFLAG;
    bool bRAPID = false;

    cout << "Enter Recoil Amount: (between 0 - 9)" << endl;
    cin >> speed;
    _clearConsole();

    cout << "Enter Desired Delay: (between 0 - 9)" << endl;
    cin >> delay;
    _clearConsole();

    //Begin Branch
    cout << "Require ADS? (Y/N)" << endl;
    cin >> adsFLAG;
    if (adsFLAG == "Y" || adsFLAG == "y")
    {
        _clearConsole();
        cout << "Rapid Fire? (Y/N)" << endl;
        cin >> rapidFLAG;
        if (rapidFLAG == "Y" || rapidFLAG == "y")
        {
            bCUSTOM = true;
            bRAPID = true;
        }
        else if (rapidFLAG == "N" || rapidFLAG == "n")
        {
            bCUSTOM = true;
        }
        else
        {
            //Return to main
            _clearConsole();
            std::cout << "Please enter a valid response of Y or N\n";
            std::cout << "returning to Main Menu" << std::endl;
            Sleep(3000);

            //Restore Custom Menu Defaults
            speed = 0;
            delay = 0;
            adsFLAG = "";
            bCUSTOM = false;
            bRAPID = false;
            cMENU = false;
            bMENU = true;
            _clearConsole();

            //Display Main Menu
            bADSFLAG = false;
            sFLAG = "X";
            recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPID, sFLAG);
        }
    }
    else if (adsFLAG == "N" || adsFLAG == "n")
    {
        _clearConsole();        
        cout << "Rapid Fire? (Y/N)" << endl;
        cin >> rapidFLAG;
        if (rapidFLAG == "Y" || rapidFLAG == "y")
        {
            bCUSTOM = true;
            bRAPID = true;
        }
        else if (rapidFLAG == "N" || rapidFLAG == "n")
        {
            bCUSTOM = true;
        }
        else
        {
            //Return to main
            _clearConsole();
            std::cout << "Please enter a valid response of Y or N\n";
            std::cout << "returning to Main Menu" << std::endl;
            Sleep(3000);

            //Restore Custom Menu Defaults
            speed = 0;
            delay = 0;
            adsFLAG = "";
            bCUSTOM = false;
            bRAPID = false;
            cMENU = false;
            bMENU = true;
            _clearConsole();

            //Display Main Menu
            bADSFLAG = false;
            sFLAG = "X";
            recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPID, sFLAG);
        }
    }
    else
    {
        //Return to main
        _clearConsole();
        std::cout << "Please enter a valid response of Y or N\n";
        std::cout << "returning to Main Menu" << std::endl;
        Sleep(3000);

        //Restore Custom Menu Defaults
        speed = 0;
        delay = 0;
        adsFLAG = "";
        bCUSTOM = false;
        bRAPID = false;
        cMENU = false;
        bMENU = true;
        _clearConsole();

        //Display Main Menu
        bADSFLAG = false;
        sFLAG = "X";
        recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPID, sFLAG);
    }

    // NightFyre Console framework
    while (bCUSTOM)
    {
        //Display user settings and other options
        if (!cMENU)
        {
            //Create menu
            std::cout << " _________________________\n";
            std::cout << "|------CUSTOM PRESET------|\n";
            std::cout << "| Speed        =>   [" << speed << "]   |\n";
            std::cout << "| Delay        =>   [" << delay << "]   |\n";
            std::cout << "| ADS Flag     =>   [" << adsFLAG << "]   |\n";
            if (bRAPID)
            {
                std::cout << "| Rapid Fire   =>   [ON]  |\n";

            }
            else
            {
                std::cout << "| Rapid Fire   =>   [OFF] |\n";

            }
            std::cout << "|v1.2----------NightFyre--|\n";
            std::cout << "PRESS [HOME] FOR MAIN MENU\n";
            std::cout << "PRESS [END] TO QUIT\n" << std::endl;;
            cMENU = true;
            cRUN = true;
        }

        if (cRUN)
        {
            _uniCustom(adsFLAG, speed, delay);
        }

        if (bRAPID)
        {
            _rapidFire(50);
        }

        if (GetAsyncKeyState(VK_HOME) & 1)
        {
            //Return to main
            _clearConsole();
            std::cout << "Returning to Main Menu" << std::endl;
            Sleep(3000);

            //Restore Custom Menu Defaults
            speed = 0;
            delay = 0;
            adsFLAG = "";
            bCUSTOM = false;
            bRAPID = false;
            cMENU = false;
            bMENU = true;
            _clearConsole();

            //Display Main Menu
            bADSFLAG = false;
            sFLAG = "X";
            recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPID, sFLAG);
        }

        if (GetKeyState(VK_END))
        {
            break;
        }

        Sleep(1);
    }
}