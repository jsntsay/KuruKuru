using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace KuruKuru
{
    //I'd like for this class to eventually handle rotation via graphic card level calls rather than through Windows
    class ScreenRotater
    {
        private Dictionary<KuruKuru.Rotations, int> orientationValues = new Dictionary<KuruKuru.Rotations, int>();

        private static ScreenRotater instance;

        private ScreenRotater() 
        {
            orientationValues.Add(KuruKuru.Rotations.TOP, DMDO_DEFAULT);
            orientationValues.Add(KuruKuru.Rotations.LEFT, DMDO_90);
            orientationValues.Add(KuruKuru.Rotations.BOTTOM, DMDO_180);
            orientationValues.Add(KuruKuru.Rotations.RIGHT, DMDO_270);
        }

        public static ScreenRotater Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ScreenRotater();
                }
                return instance;
            }
        }

        public KuruKuru.Rotations currentOrientation()
        {
            DEVMODE dm = CreateDevmode();
            GetSettings(ref dm);
            int dmOrient = dm.dmDisplayOrientation;
            foreach (KeyValuePair<KuruKuru.Rotations, int> kvp in orientationValues)
            {
                if (kvp.Value == dmOrient)
                    return kvp.Key;
            }
            //shouldn't happen
            return KuruKuru.Rotations.TOP;
        }

        public int currentScreenWidth()
        {
            DEVMODE dm = CreateDevmode();
            GetSettings(ref dm);
            return dm.dmPelsWidth;
        }

        public int currentScreenHeight()
        {
            DEVMODE dm = CreateDevmode();
            GetSettings(ref dm);
            return dm.dmPelsHeight;
        }

        public void Rotate(KuruKuru.Rotations rotation)
        {
            // obtain current settings
            DEVMODE dm = CreateDevmode();
            GetSettings(ref dm);

            // swap height and width if needed
            int diff = Math.Abs(KuruKuru.CurrentRotation - rotation);
            if (diff == 90 || diff == 270)
            {
                int temp = dm.dmPelsHeight;
                dm.dmPelsHeight = dm.dmPelsWidth;
                dm.dmPelsWidth = temp;
            }

            // set the orientation value
            dm.dmDisplayOrientation = orientationValues[rotation];

            // switch to new settings
            ChangeSettings(dm);

            KuruKuru.CurrentRotation = rotation;
            KuruKuru.ScreenHeight = dm.dmPelsHeight;
            KuruKuru.ScreenWidth = dm.dmPelsWidth;

            //update mainform
            KuruKuru.ModifyOrientation();
        }

        private void ChangeSettings(DEVMODE dm)
        {
            int iRet = ChangeDisplaySettings(ref dm, 0);
            //TODO: actual error handling (lol)
            if (iRet != DISP_CHANGE_SUCCESSFUL)
            {
                Console.WriteLine("error");
            }
        }

        private int GetSettings(ref DEVMODE dm)
        {
            // helper to obtain current settings
            return GetSettings(ref dm, ENUM_CURRENT_SETTINGS);
        }

        private int GetSettings(ref DEVMODE dm, int iModeNum)
        {
            // helper to wrap EnumDisplaySettings Win32 API
            return EnumDisplaySettings(null, iModeNum, ref dm);
        }

        // helper for creating an initialized DEVMODE structure
        public static DEVMODE CreateDevmode()
        {
            DEVMODE dm = new DEVMODE();
            dm.dmDeviceName = new String(new char[32]);
            dm.dmFormName = new String(new char[32]);
            dm.dmSize = (short)Marshal.SizeOf(dm);
            return dm;
        }

        // constants
        public const int ENUM_CURRENT_SETTINGS = -1;
        public const int DISP_CHANGE_SUCCESSFUL = 0;
        public const int DISP_CHANGE_BADDUALVIEW = -6;
        public const int DISP_CHANGE_BADFLAGS = -4;
        public const int DISP_CHANGE_BADMODE = -2;
        public const int DISP_CHANGE_BADPARAM = -5;
        public const int DISP_CHANGE_FAILED = -1;
        public const int DISP_CHANGE_NOTUPDATED = -3;
        public const int DISP_CHANGE_RESTART = 1;
        public const int DMDO_DEFAULT = 0;
        public const int DMDO_90 = 1;
        public const int DMDO_180 = 2;
        public const int DMDO_270 = 3;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct DEVMODE
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmDeviceName;

            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public int dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmFormName;

            public short dmLogPixels;
            public short dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        };

        // PInvoke declaration for EnumDisplaySettings Win32 API
        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        public static extern int EnumDisplaySettings(string lpszDeviceName, int iModeNum, ref DEVMODE lpDevMode);

        // PInvoke declaration for ChangeDisplaySettings Win32 API
        [DllImport("user32.dll", CharSet = CharSet.Ansi)]
        public static extern int ChangeDisplaySettings(ref DEVMODE lpDevMode, int dwFlags);
    }
}
