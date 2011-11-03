using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KuruKuru
{
    public partial class MainForm : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        private MenuItem rotateKeys;
        private MenuItem rotateMouse;

        public MainForm()
        {
            InitializeComponent();
            MouseRotater.Instance.Initialize();
            KeyRotater.Instance.Initialize();

            rotateKeys = new MenuItem("Modify Keyboard", RotateKeyboard);
            rotateKeys.Checked = true;
            rotateMouse = new MenuItem("Modify Mouse", RotateMouse);
            rotateMouse.Checked = true;

            trayMenu = new ContextMenu();

            trayMenu.MenuItems.Add("Rotate Top", RotateTop);
            trayMenu.MenuItems.Add("Rotate Right", RotateRight);
            trayMenu.MenuItems.Add("Rotate Left", RotateLeft);
            trayMenu.MenuItems.Add("Rotate Bottom", RotateBottom);
            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add(rotateKeys);
            trayMenu.MenuItems.Add(rotateMouse);
            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add("Exit", OnExit);

            trayIcon = new NotifyIcon();
            trayIcon.Text = "KuruKuru";
            trayIcon.Icon = MainResource.up;

            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible     = true;
        }

        //run after orientation switch to modify text and icon
        public void ModifyOrientation()
        {
            switch (KuruKuru.CurrentRotation)
            {
                case KuruKuru.Rotations.TOP:
                    trayIcon.Text = "KuruKuru - top";
                    trayIcon.Icon = MainResource.up;
                    break;
                case KuruKuru.Rotations.LEFT:
                    trayIcon.Text = "KuruKuru - left";
                    trayIcon.Icon = MainResource.ccw;
                    break;
                case KuruKuru.Rotations.RIGHT:
                    trayIcon.Text = "KuruKuru - right";
                    trayIcon.Icon = MainResource.cw;
                    break;
                case KuruKuru.Rotations.BOTTOM:
                    trayIcon.Text = "KuruKuru - bottom";
                    trayIcon.Icon = MainResource.flip;
                    break;
            }
        }

        private void rotateRBtn_Click(object sender, EventArgs e)
        {
            ScreenRotater.Instance.Rotate(KuruKuru.Rotations.RIGHT);
        }

        private void rotateLBtn_Click(object sender, EventArgs e)
        {
            ScreenRotater.Instance.Rotate(KuruKuru.Rotations.LEFT);
        }

        private void rotateTBtn_Click(object sender, EventArgs e)
        {
            ScreenRotater.Instance.Rotate(KuruKuru.Rotations.TOP);
        }

        private void rotateBBtn_Click(object sender, EventArgs e)
        {
            ScreenRotater.Instance.Rotate(KuruKuru.Rotations.BOTTOM);
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible       = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.
            base.OnLoad(e);
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RotateKeyboard(object sender, EventArgs e)
        {
            rotateKeys.Checked = !rotateKeys.Checked;
            KeyRotater.ModifyKeys = rotateKeys.Checked;
        }

        private void RotateMouse(object sender, EventArgs e)
        {
            rotateMouse.Checked = !rotateMouse.Checked;
            MouseRotater.ModifyMouse = rotateMouse.Checked;
        }

        private void RotateTop(object sender, EventArgs e)
        {
            ScreenRotater.Instance.Rotate(KuruKuru.Rotations.TOP);
        }

        private void RotateRight(object sender, EventArgs e)
        {
            ScreenRotater.Instance.Rotate(KuruKuru.Rotations.RIGHT);
        }

        private void RotateLeft(object sender, EventArgs e)
        {
            ScreenRotater.Instance.Rotate(KuruKuru.Rotations.LEFT);
        }

        private void RotateBottom(object sender, EventArgs e)
        {
            ScreenRotater.Instance.Rotate(KuruKuru.Rotations.BOTTOM);
        }
    }
}