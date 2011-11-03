using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KuruKuru
{
    static class KuruKuru
    {
        public enum Rotations { TOP = 0, LEFT = 90, BOTTOM = 180, RIGHT = 270 , INITIALDETECT = -1};
        private static Rotations currentRotation = Rotations.INITIALDETECT;
        private static int screenHeight = -1;
        private static int screenWidth = -1;

        private static MainForm mainForm;

        public static Rotations CurrentRotation
        {
            get
            {
                if (currentRotation == Rotations.INITIALDETECT)
                {
                    currentRotation = ScreenRotater.Instance.currentOrientation();
                    ModifyOrientation();
                }
                return currentRotation;
            }
            set
            {
                currentRotation = value;
            }
        }

        public static int ScreenHeight
        {
            get
            {
                if (screenHeight == -1)
                    screenHeight = ScreenRotater.Instance.currentScreenHeight();
                return screenHeight;
            }
            set
            {
                screenHeight = value;
            }
        }

        public static int ScreenWidth
        {
            get
            {
                if (screenWidth == -1)
                    screenWidth = ScreenRotater.Instance.currentScreenWidth();
                return screenWidth;
            }
            set
            {
                screenWidth = value;
            }
        }

        public static void ModifyOrientation()
        {
            mainForm.ModifyOrientation();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}
