using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace UniversalNoRecoil2
{
    class MAIN
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);
        const uint MOUSEEVENTF_MOVE = 0x0001;

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Int32 vKey);
        static int VK_LBUTTON = 0x01;
        static int VK_RBUTTON = 0x02;
        static int VK_END = 0x23;
        static int VK_INSERT = 0x2D;
        static int VK_NUMPAD1 = 0x61;
        static int VK_NUMPAD2 = 0x62;
        static int VK_NUMPAD3 = 0x63;

        //Establish Variables
        static bool _consoleMENU = true;
        static bool bPRESET1 = false;
        static bool bFLAG = true;
        static string sPRESET1 = " ", sPRESET2 = " ", sPRESET3 = " ";
        static string sFLAG = "X";

        //Methods
        public static void recoilSELECTION(string PRESET1, string PRESET2, string PRESET3, string FLAG)
        {
            Console.Clear();
            Console.WriteLine(" _______________________ \n" +
            "|-------NO RECOIL-------|\n" +
            $"| [1] PRESET 1:  => [{PRESET1}] |\n" +
            $"| [2] PRESET 2:  => [{PRESET2}] |\n" +
            $"| [3] PRESET 3:  => [{PRESET3}] |\n" +
            $"| [INS] REQ ADS: => [{FLAG}] |\n" +
            "| [END] QUIT            |\n" +
            "|v1.0-------NightFyre---|");
        }
        
        //No Recoil Selections
        public static void _uniCoil(short aim_key, short shoot_key, int speed, int delay)
        {
            if ((aim_key) != 0)
            {
                if ((shoot_key) != 0)
                {
                    mouse_event(MOUSEEVENTF_MOVE, 0, speed, 0, 0);
                    Thread.Sleep(delay);
                }
            }
        }

        public static void _uniCoilF(short shoot_key, int speed, int delay)
        {
            if ((shoot_key) != 0)
            {
                mouse_event(MOUSEEVENTF_MOVE, 0, speed, 0, 0);
                Thread.Sleep(delay);
            }
        }

        static void Main(string[] args)
        {
            Console.Title = "uniCoil";
            recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sFLAG);
            while (_consoleMENU)
            {
                //KeyPresses
                short keyLMB = GetAsyncKeyState(VK_LBUTTON);
                short keyRMB = GetAsyncKeyState(VK_RBUTTON);
                short keyEND = GetAsyncKeyState(VK_END);
                short keyINSERT = GetAsyncKeyState(VK_INSERT);
                short keyNUM1 = GetAsyncKeyState(VK_NUMPAD1);
                short keyNUM2 = GetAsyncKeyState(VK_NUMPAD2);
                short keyNUM3 = GetAsyncKeyState(VK_NUMPAD3);

                //RECOIL PRESET KEYBINDS
                if ((keyNUM1 & 1) == 1)
                {
                    bPRESET1 = !bPRESET1;
                    if (bPRESET1)
                    {
                        sPRESET1 = "X";
                        recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sFLAG);
                    }
                    else
                    {
                        sPRESET1 = " ";
                        recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sFLAG);
                    }
                }

                //Quit and Panic Keys
                if ((keyEND & 1) == 1)
                {
                    break;
                }

                if ((keyINSERT & 1) == 1)
                {
                    bFLAG = !bFLAG;
                    if (bFLAG)
                    {
                        sFLAG = "X";
                        recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sFLAG);
                    }
                    else
                    {
                        sFLAG = " ";
                        recoilSELECTION(sPRESET1, sPRESET2, sPRESET3, sFLAG);
                    }
                }

                //RECOIL EVENTS
                if (bPRESET1)
                {
                    if (bFLAG)
                    {
                        _uniCoil(keyRMB, keyLMB, 7, 7);
                    }
                    else
                    {
                        _uniCoilF(keyLMB, 7, 7);
                    }
                }
            }
        }
    }
}
