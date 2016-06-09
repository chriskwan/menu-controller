using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MenuController
{
    class MenuControllerUnmanaged
    {
        [DllImport("MenuControllerUnmanaged.DLL")]
        public static extern Int32 GetMenuItemString(IntPtr hMenu, Int32 uIDItem, [MarshalAs(UnmanagedType.LPArray)] byte[] lpString);
        [DllImport("MenuControllerUnmanaged.DLL")]
        public static extern Int32 ClickMenuItem(Int32 hWnd, IntPtr hMenu, Int32 nPos);
        [DllImport("MenuControllerUnmanaged.DLL")]
        public static extern bool IsCheckMarksItem(IntPtr hMenu, Int32 nPos);
        [DllImport("MenuControllerUnmanaged.DLL")]
        public static extern bool IsDisabled(IntPtr hMenu, Int32 nPos);
    }
}
