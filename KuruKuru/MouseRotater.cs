using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace KuruKuru
{
    class MouseRotater
    {
        private static HookMethods.LowLevelProc proc = HookCallback;
        private static MouseRotater instance;
        private static HookMethods hook;

        private static int lastX = Int32.MaxValue;
        private static int lastY = Int32.MaxValue;

        private static KuruKuru.Rotations lastRotation;

        private static bool modifyMouse = true;

        private MouseRotater() { }

        public static MouseRotater Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MouseRotater();
                }
                return instance;
            }
        }

        public static bool ModifyMouse
        {
            set
            {
                modifyMouse = value;
            }
        }

        public void Initialize()
        {
            hook = new HookMethods(proc, HookMethods.WH_MOUSE_LL);
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (modifyMouse && nCode >= 0 && (MouseMessages)wParam == MouseMessages.WM_MOUSEMOVE)
            {
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                int newX = hookStruct.pt.x;
                int newY = hookStruct.pt.y;
                //Console.WriteLine("now: " + hookStruct.pt.x + " , " + hookStruct.pt.y);
                if (KuruKuru.CurrentRotation == lastRotation && lastX != Int32.MaxValue && lastY != Int32.MaxValue)
                {
                    switch (KuruKuru.CurrentRotation)
                    {
                        case KuruKuru.Rotations.TOP:
                            //do nothing, default
                            break;
                        case KuruKuru.Rotations.LEFT:
                            newX = lastX - (hookStruct.pt.y - lastY);
                            newY = lastY + (hookStruct.pt.x - lastX);
                            break;
                        case KuruKuru.Rotations.RIGHT:
                            newX = lastX + (hookStruct.pt.y - lastY);
                            newY = lastY - (hookStruct.pt.x - lastX);
                            break;
                        case KuruKuru.Rotations.BOTTOM:
                            newX = lastX - (hookStruct.pt.x - lastX);
                            newY = lastY - (hookStruct.pt.y - lastY);
                            break;
                    }
                }
                //handle the edge (ha!) cases
                //this needs to be changed to support multi monitors (does it matter?)
                if (newX < 0)
                    newX = 0;
                else if (newX > KuruKuru.ScreenWidth)
                    newX = KuruKuru.ScreenWidth;
                if (newY < 0)
                    newY = 0;
                else if (newY > KuruKuru.ScreenHeight)
                    newY = KuruKuru.ScreenHeight;
                SetCursorPos(newX, newY);
                lastX = newX;
                lastY = newY;
                lastRotation = KuruKuru.CurrentRotation;
                return new IntPtr(1);
            }
            return hook.CallNextHook(nCode, wParam, lParam);
        }

        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);
    }
}
