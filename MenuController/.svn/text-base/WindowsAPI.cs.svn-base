using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MenuController
{
    class WindowsAPI
    {
        public const short SWP_NOMOVE = 0X2;
        public const short SWP_NOSIZE = 1;
        public const short SWP_NOZORDER = 0X4;
        public const int SWP_SHOWWINDOW = 0x0040;

        [DllImport("User32.dll")]
        public static extern IntPtr GetMenu(Int32 hWnd);
        [DllImport("User32.dll")]
        public static extern Int32 GetMenuItemCount(IntPtr hMenu);
        [DllImport("User32.dll")]
        public static extern IntPtr GetSubMenu(IntPtr hMenu, int nPos);
        [DllImport("User32.dll")]
        public static extern Int32 GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern bool SetForegroundWindow(IntPtr hwnd);
    }
}
