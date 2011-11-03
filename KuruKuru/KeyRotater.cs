using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace KuruKuru
{
    class KeyRotater
    {
        private static HookMethods.LowLevelProc proc = HookCallback;
        private static KeyRotater instance;
        private static HookMethods hook;

        private static bool lCtrlMod = false;
        private static bool lShiftMod = false;
        private static bool lAltMod = false;
        private static bool rCtrlMod = false;
        private static bool rShiftMod = false;
        private static bool rAltMod = false;

        private static bool ctrlMod = false;
        private static bool altMod = false;
        private static bool shiftMod = false;

        private static bool modifyKeys = true;

        private KeyRotater() { }

        public static KeyRotater Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KeyRotater();
                }
                return instance;
            }
        }

        public static bool ModifyKeys
        {
            set
            {
                modifyKeys = value;
            }
        }

        public void Initialize()
        {
            hook = new HookMethods(proc, HookMethods.WH_KEYBOARD_LL);
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                KBDLLHOOKSTRUCT hookStruct = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));
                if ((KeyMessages)wParam == KeyMessages.WM_KEYDOWN)
                {
                    switch (hookStruct.vkCode)
                    {
                        case VK_LCONTROL:
                            lCtrlMod = true;
                            break;
                        case VK_RCONTROL:
                            rCtrlMod = true;
                            break;
                        case VK_LALT:
                            lAltMod = true;
                            break;
                        case VK_RALT:
                            rAltMod = true;
                            break;
                        case VK_LSHIFT:
                            lShiftMod = true;
                            break;
                        case VK_RSHIFT:
                            rShiftMod = true;
                            break;
                        case VK_UP:
                            if (ctrlMod && altMod && !shiftMod)
                                ScreenRotater.Instance.Rotate(KuruKuru.Rotations.TOP);
                            else if (modifyKeys)
                            {
                                ModifyArrowKey(VK_UP);
                                return new IntPtr(1);
                            }
                            break;
                        case VK_LEFT:
                            if (ctrlMod && altMod && !shiftMod)
                                ScreenRotater.Instance.Rotate(KuruKuru.Rotations.LEFT);
                            else if (modifyKeys)
                            {
                                ModifyArrowKey(VK_LEFT);
                                return new IntPtr(1);
                            }
                            break;
                        case VK_RIGHT:
                            if (ctrlMod && altMod && !shiftMod)
                                ScreenRotater.Instance.Rotate(KuruKuru.Rotations.RIGHT);
                            else if (modifyKeys)
                            {
                                ModifyArrowKey(VK_RIGHT);
                                return new IntPtr(1);
                            }
                            break;
                        case VK_DOWN:
                            if (ctrlMod && altMod && !shiftMod)
                                ScreenRotater.Instance.Rotate(KuruKuru.Rotations.BOTTOM);
                            else if (modifyKeys)
                            {
                                ModifyArrowKey(VK_DOWN);
                                return new IntPtr(1);
                            }
                            break;
                    }
                }
                else if ((KeyMessages)wParam == KeyMessages.WM_KEYUP)
                {
                    switch (hookStruct.vkCode)
                    {
                        case VK_LCONTROL:
                            lCtrlMod = false;
                            break;
                        case VK_RCONTROL:
                            rCtrlMod = false;
                            break;
                        case VK_LALT:
                            lAltMod = false;
                            break;
                        case VK_RALT:
                            rAltMod = false;
                            break;
                        case VK_LSHIFT:
                            lShiftMod = false;
                            break;
                        case VK_RSHIFT:
                            rShiftMod = false;
                            break;
                    }
                }
                ctrlMod = rCtrlMod || lCtrlMod;
                altMod = rAltMod || lAltMod;
                shiftMod = rShiftMod || lShiftMod;
            }
            return hook.CallNextHook(nCode, wParam, lParam);
        }

        //translates arrow key based on orientation, then emulates pressing that key
        private static void ModifyArrowKey(uint arrow)
        {
            uint newArrow = arrow;
            switch (KuruKuru.CurrentRotation)
            {
                case KuruKuru.Rotations.TOP:
                    //do nothing
                    break;
                case KuruKuru.Rotations.LEFT:
                    newArrow += 1;
                    break;
                case KuruKuru.Rotations.BOTTOM:
                    newArrow += 2;
                    break;
                case KuruKuru.Rotations.RIGHT:
                    newArrow += 3;
                    break;
            }
            if (newArrow > 0x28)
                newArrow = 0x24 + (newArrow % 0x28);

            keybd_event((byte)newArrow, ArrowScanCode(newArrow), 0, 0);
            keybd_event((byte)newArrow, ArrowScanCode(newArrow), KEYEVENTF_KEYUP, 0);
        }

        //given a vk code, return appropriate scan code
        private static byte ArrowScanCode(uint vk)
        {
            switch (vk)
            {
                case VK_LEFT:
                    return SCAN_LEFT;
                case VK_RIGHT:
                    return SCAN_RIGHT;
                case VK_DOWN:
                    return SCAN_DOWN;
                case VK_UP:
                    return SCAN_UP;
            }
            return 0;
        }

        private const uint KEYEVENTF_EXTENDEDKEY = 0x01;
        private const uint KEYEVENTF_KEYUP = 0x02;

        //vkcodes
        private const uint VK_LSHIFT = 0xA0;
        private const uint VK_LCONTROL = 0xA2;
        private const uint VK_LALT = 0xA4;
        private const uint VK_RSHIFT = 0xA1;
        private const uint VK_RCONTROL = 0xA3;
        private const uint VK_RALT = 0xA5;
        private const uint VK_SHIFT = 0x10;
        private const uint VK_CTRL = 0x11;
        private const uint VK_ALT = 0x12;
        private const uint VK_SPACE = 0x20;
        private const uint VK_LEFT = 0x25;
        private const uint VK_UP = 0x26;
        private const uint VK_RIGHT = 0x27;
        private const uint VK_DOWN = 0x28;

        //scancodes
        private const byte SCAN_UP = 0x48;
        private const byte SCAN_LEFT = 0x4B;
        private const byte SCAN_RIGHT = 0x4D;
        private const byte SCAN_DOWN = 0x50;

        private enum KeyMessages
        {    
            WM_KEYDOWN = 0x100,
            WM_KEYUP = 0x101,
            WM_SYSKEYUP = 0x102,
            WM_SYSKEYDOWN = 0x103
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public uint vkCode;
            public uint scanCode;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
    }
}
