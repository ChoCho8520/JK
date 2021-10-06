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

        static void Main(string[] args)
        {
            while (_consoleMENU)
            {
                short keyLMB = GetAsyncKeyState(VK_LBUTTON);
                short keyRMB = GetAsyncKeyState(VK_RBUTTON);
                short keyEND = GetAsyncKeyState(VK_END);
                short keyINSERT = GetAsyncKeyState(VK_INSERT);
                short keyNUM1 = GetAsyncKeyState(VK_NUMPAD1);
                short keyNUM2 = GetAsyncKeyState(VK_NUMPAD2);
                short keyNUM3 = GetAsyncKeyState(VK_NUMPAD3);

                //Keybind Toggle
                if ((keyNUM1 & 1) == 1)
                {
                    bPRESET1 = !bPRESET1;
                    if (bPRESET1)
                    {
                        //Key Pressed
                        Console.WriteLine("PRESET 1 ENABLED - PRESS 1 TO DISABLE or PRESS [END] TO QUIT");
                    }
                    else
                    {
                        Console.WriteLine("PRESET 1 DISABLED");
                    }
                }


                if ((keyEND & 1) == 1)
                {
                    break;
                }


                //RecoilEvent
                if (bPRESET1)
                {
                    if ((keyRMB) != 0)
                    {
                        if ((keyLMB) != 0)
                        {
                            mouse_event(MOUSEEVENTF_MOVE, 0, 7, 0, 0);
                            Thread.Sleep(7);
                        }
                    }
                }
            }
        }
    }
}
