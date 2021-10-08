using System;
using System.Media;
using System.Threading;
using helpers.UniversalNoRecoil2;

namespace UniversalNoRecoil2
{
    class MAIN
    {
        //Establish Variables
        static bool _consoleMENU = true;
        static bool _customMENU = false;
        static bool bPRESET1 = false, bPRESET2 = false, bPRESET3 = false;
        static bool bRAPIDFIRE = false;
        static bool bFLAG = true;
        static bool bCUSTOM = false;
        static string sPRESET1 = " ", sPRESET2 = " ", sPRESET3 = " ";
        static string sRAPIDFIRE = " ";
        static string sFLAG = "X";
        
        //Custom Menu
        static int cSPEED, cDELAY;
        static string cRAPID, cFLAG;
        static int fDELAY, fSPEED;
        static string fFIRE, fFLAG;
        static void Main(string[] args)
        {
            Console.Title = "uniCoil";
            Console.SetWindowSize(30, 12);
            func.recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPIDFIRE, sFLAG);
            while (_consoleMENU)
            {
                //Establish Keybinds
                short keyLMB = func.GetAsyncKeyState(func.VK_LBUTTON);
                short keyRMB = func.GetAsyncKeyState(func.VK_RBUTTON);
                short keyEND = func.GetAsyncKeyState(func.VK_END);
                short keyHOME = func.GetAsyncKeyState(func.VK_HOME);
                short keyINSERT = func.GetAsyncKeyState(func.VK_INSERT);
                short keyNUM1 = func.GetAsyncKeyState(func.VK_NUMPAD1);
                short keyNUM2 = func.GetAsyncKeyState(func.VK_NUMPAD2);
                short keyNUM3 = func.GetAsyncKeyState(func.VK_NUMPAD3);
                short keyNUM4 = func.GetAsyncKeyState(func.VK_NUMPAD4);
                short keyNUM9 = func.GetAsyncKeyState(func.VK_NUMPAD9);
                short keyLSHIFT = func.GetAsyncKeyState(func.VK_LSHIFT);
                short keyALT = func.GetAsyncKeyState(func.VK_MENU);

                //KEYBIND TOGGLES
                if ((keyNUM1 & 1) == 1)
                {
                    if (!_customMENU)
                    {
                        if (!bPRESET2 && !bPRESET3)
                        {
                            bPRESET1 = !bPRESET1;
                            if (bPRESET1)
                            {
                                sPRESET1 = "X";
                                func.recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPIDFIRE, sFLAG);
                                SystemSounds.Asterisk.Play();
                            }
                            else
                            {
                                sPRESET1 = " ";
                                func.recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPIDFIRE, sFLAG);
                            }
                        }
                    }
                }

                if ((keyNUM2 & 1) == 1)
                {
                    if (!_customMENU)
                    {
                        if (!bPRESET1 && !bPRESET3)
                        {
                            bPRESET2 = !bPRESET2;
                            if (bPRESET2)
                            {
                                sPRESET2 = "X";
                                SystemSounds.Asterisk.Play();
                                func.recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPIDFIRE, sFLAG);
                            }
                            else
                            {
                                sPRESET2 = " ";
                                func.recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPIDFIRE, sFLAG);
                            }
                        }
                    }
                }

                if ((keyNUM3 & 1) == 1)
                {
                    if (!_customMENU)
                    {
                        if (!bPRESET1 && !bPRESET2)
                        {
                            bPRESET3 = !bPRESET3;
                            if (bPRESET3)
                            {
                                sPRESET3 = "X";
                                SystemSounds.Asterisk.Play();
                                func.recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPIDFIRE, sFLAG);
                            }
                            else
                            {
                                sPRESET3 = " ";
                                func.recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPIDFIRE, sFLAG);
                            }
                        }
                    }
                }

                if ((keyNUM4 & 1) == 1)
                {
                    if (!_customMENU)
                    {
                        bRAPIDFIRE = !bRAPIDFIRE;
                        if (bRAPIDFIRE)
                        {
                            sRAPIDFIRE = "X";
                            SystemSounds.Asterisk.Play();
                            func.recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPIDFIRE, sFLAG);
                        }
                        else
                        {
                            sRAPIDFIRE = " ";
                            func.recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPIDFIRE, sFLAG);
                        }
                    }
                }

                //CUSTOM INPUT
                if ((keyHOME & 1) == 1)
                {
                    if (!_customMENU)
                    {
                        _customMENU = true;

                        //Check if anything is active first
                        if (bPRESET1 || bPRESET2 || bPRESET3 || bFLAG || bRAPIDFIRE)
                        {
                            bPRESET1 = false;
                            bPRESET2 = false;
                            bPRESET3 = false;
                            bFLAG = false;
                            bRAPIDFIRE = false;
                        }

                        //Clear Console
                        Console.SetWindowSize(50, 12);
                        Console.Clear();

                        //Start gathering user input
                        Console.WriteLine("Enter Recoil Amount: (between 0 - 30)");
                        int cSPEED = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        Console.WriteLine("Enter Desired Delay: (between 0 - 30)");
                        int cDELAY = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();

                        Console.WriteLine("Rapid Fire? (Y/N)");
                        string cRAPID = Console.ReadLine();
                        Console.Clear();

                        //Start Branching based on inputs
                        if (cRAPID == "Y" || cRAPID == "y")
                        {
                            Console.WriteLine("Require ADS? (Y/N)");
                            string cFLAG = Console.ReadLine();
                            Console.Clear();
                            if (cFLAG == "Y" || cFLAG == "y")
                            {
                                //Output Settings to console
                                //Display Keybind to return either Quit or return to main menu
                                Console.WriteLine("CUSTOM SETTINGS");
                                Console.WriteLine($"Recoil Amount: {cSPEED}\n" +
                                $"Delay: {cDELAY}\n" +
                                $"Rapid Fire: {cRAPID}\n" +
                                $"Require ADS: {cFLAG}\n");
                                Console.WriteLine("Press [HOME] to return to Main Menu\n" +
                                    "Press [END] to quit");
                                fDELAY = cDELAY;
                                fSPEED = cSPEED;
                                fFLAG = cFLAG;
                                fFIRE = cRAPID;
                                bCUSTOM = true;
                            }
                            else if (cFLAG == "N" || cFLAG == "n")
                            {
                                Console.WriteLine("CUSTOM SETTINGS");
                                Console.WriteLine($"Recoil Amount: {cSPEED}\n" +
                                $"Delay: {cDELAY}\n" +
                                $"Rapid Fire: {cRAPID}\n" +
                                $"Require ADS: {cFLAG}\n");
                                Console.WriteLine("Press [HOME] to return to Main Menu\n" +
                                    "Press [END] to quit");
                                fDELAY = cDELAY;
                                fSPEED = cSPEED;
                                fFLAG = cFLAG;
                                fFIRE = cRAPID;
                                bCUSTOM = true;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Please enter a valid response of Y or N\n" +
                                    "returning to Main Menu");
                                Thread.Sleep(3000);
                                _customMENU = false;
                                func.recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPIDFIRE, sFLAG);
                            }
                        }
                        else if (cRAPID == "N" || cRAPID == "n")
                        {
                            Console.WriteLine("Require ADS? (Y/N)");
                            string cFLAG = Console.ReadLine();
                            if (cFLAG == "Y" || cFLAG == "y")
                            {
                                Console.WriteLine("CUSTOM SETTINGS");
                                Console.WriteLine($"Recoil Amount: {cSPEED}\n" +
                                $"Delay: {cDELAY}\n" +
                                $"Rapid Fire: {cRAPID}\n" +
                                $"Require ADS: {cFLAG}\n");
                                Console.WriteLine("Press [HOME] to return to Main Menu\n" +
                                    "Press [END] to quit");
                                fDELAY = cDELAY;
                                fSPEED = cSPEED;
                                fFLAG = cFLAG;
                                fFIRE = cRAPID;
                                bCUSTOM = true;
                            }
                            else if (cFLAG == "N" || cFLAG == "n")
                            {
                                Console.WriteLine("CUSTOM SETTINGS");
                                Console.WriteLine($"Recoil Amount: {cSPEED}\n" +
                                $"Delay: {cDELAY}\n" +
                                $"Rapid Fire: {cRAPID}\n" +
                                $"Require ADS: {cFLAG}\n");
                                Console.WriteLine("Press [HOME] to return to Main Menu\n" +
                                    "Press [END] to quit");
                                fDELAY = cDELAY;
                                fSPEED = cSPEED;
                                fFLAG = cFLAG;
                                fFIRE = cRAPID;
                                bCUSTOM = true;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Please enter a valid response of Y or N\n" +
                                    "returning to Main Menu");
                                Thread.Sleep(3000);
                                _customMENU = false;
                                func.recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPIDFIRE, sFLAG);
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Please enter a valid response of Y or N\n" +
                                "returning to Main Menu");
                            Thread.Sleep(3000);
                            _customMENU = false;
                            func.recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPIDFIRE, sFLAG);
                        }
                    }
                    else
                    {
                        _customMENU = false;
                        bCUSTOM = false;
                        fSPEED = 0;
                        fDELAY = 0; 
                        fFIRE = ""; 
                        fFLAG = "";
                        func.recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPIDFIRE, sFLAG);
                    }
                }

                //PANIC & FLAG Keys
                if ((keyEND & 1) == 1)
                {
                    break;
                }

                if ((keyINSERT & 1) == 1)
                {
                    if (!_customMENU)
                    {
                        bFLAG = !bFLAG;
                        if (bFLAG)
                        {
                            sFLAG = "X";
                            func.recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPIDFIRE, sFLAG);
                        }
                        else
                        {
                            sFLAG = " ";
                            func.recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sRAPIDFIRE, sFLAG);
                        }
                    }
                }

                //METHODS
                if (bPRESET1)
                {
                    if (bFLAG)
                    {
                        func._uniCoil(keyRMB, keyLMB, 7, 7);
                    }
                    else
                    {
                        func._uniCoilF(keyLMB, 7, 7);
                    }
                }

                if (bPRESET2)
                {
                    if (bFLAG)
                    {
                        func._uniCoil(keyRMB, keyLMB, 10, 10);
                    }
                    else
                    {
                        func._uniCoilF(keyLMB, 10, 10);
                    }
                }

                if (bPRESET3)
                {
                    if (bFLAG)
                    {
                        func._uniCoil(keyRMB, keyLMB, 15, 15);
                    }
                    else
                    {
                        func._uniCoilF(keyLMB, 15, 15);
                    }
                }

                if (bRAPIDFIRE)
                {
                    if ((keyALT & 1) != 0) 
                    {
                        func._rFIRE(100);
                    }  
                }

                if (bCUSTOM)
                {
                    func._uniCustom(keyRMB, keyLMB, keyALT, fSPEED, fDELAY, fFIRE, fFLAG);
                }
            }
        }
    }
}
