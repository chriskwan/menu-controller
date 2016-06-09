using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;

namespace MenuController
{
    public class MenuUtilities
    {
        public struct MenuItem
        {
            public IntPtr hMenu; // For legacy applications
            public AutomationElement aeMenu;
            public string text;
            public bool isToggle;
            public bool isDisabled;
        }

        public static List<MenuItem> GetMenuItems(IntPtr hMenu)
        {
            List<MenuItem> mil = new List<MenuItem>();

            for (int i = 0; i < WindowsAPI.GetMenuItemCount(hMenu); i++)
            {
                byte[] s = new byte[20];
                MenuControllerUnmanaged.GetMenuItemString(hMenu, i, s);

                StringBuilder sb = new StringBuilder(20);
                for (int j = 0; j < s.Length; j++)
                {
                    char c = Convert.ToChar(s[j]);
                    if (c == '\t')
                        break;
                    if (c != '\0' && c != '&')
                        sb.Append(Convert.ToChar(s[j]));
                }

                MenuItem mi = new MenuItem();
                mi.hMenu = hMenu;
                mi.text = sb.ToString().Trim();
                mi.isToggle = MenuControllerUnmanaged.IsCheckMarksItem(hMenu, i);
                mi.isDisabled = MenuControllerUnmanaged.IsDisabled(hMenu, i);
                mil.Add(mi);
            }

            return mil;
        }

        public static List<MenuItem> GetMenuItems(AutomationElement aeMenu)
        {
            return GetMenuItems(aeMenu, false);
        }

        public static List<MenuItem> GetMenuItems(AutomationElement aeMenu, bool expand)
        {
            List<MenuItem> mil = new List<MenuItem>();
            AutomationElementCollection aeMenuItems;
            
            if (expand)
            {
                try
                {
                    ExpandMenuItem(aeMenu);
                }
                catch 
                {
                    ClickMenuItem(aeMenu);
                }
            }

            aeMenuItems = aeMenu.FindAll(TreeScope.Children,
                new PropertyCondition(AutomationElement.ControlTypeProperty,
                ControlType.MenuItem));

            foreach (AutomationElement ae in aeMenuItems)
            {
                MenuItem mi = new MenuItem();
                mi.text = ae.Current.Name;
                mi.isDisabled = !ae.Current.IsEnabled;
                mi.aeMenu = ae;
                mil.Add(mi);
            }

            return mil;
        }

        private static void ExpandMenuItem(AutomationElement aeMenu)
        {
            ExpandCollapsePattern itemOpenPattern = aeMenu.GetCurrentPattern(
                    ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
            itemOpenPattern.Expand();
        }

        public static List<MenuUtilities.MenuItem> GetMenuItems(int hWnd)
        {
            List<MenuUtilities.MenuItem> mil = null;

            AutomationElement aeMainForm = AutomationElement.FromHandle(new IntPtr(hWnd));

            AutomationElementCollection aeMenuBars = GetMenuBar(aeMainForm);

            if (aeMenuBars != null && aeMenuBars.Count > 0)
                mil = MenuUtilities.GetMenuItems(aeMenuBars[0]);

            return mil;
        }

        public static void ClickMenuItem(IntPtr hMenu, int index, int hWnd)
        {
            MenuControllerUnmanaged.ClickMenuItem(hWnd,
                        hMenu, index);
        }

        public static void ClickMenuItem(AutomationElement aeMenuItem)
        {
            try
            {
                InvokePattern ipClickButton1 =
                    (InvokePattern)aeMenuItem.GetCurrentPattern(
                    InvokePattern.Pattern);
                ipClickButton1.Invoke();
            }
            catch { }
        }

        private static AutomationElementCollection GetMenuBar(AutomationElement aeWithMenuBar)
        {
            AutomationElementCollection aeMenuBars = null;
            try
            {
                aeMenuBars = aeWithMenuBar.FindAll(TreeScope.Children,
                        new PropertyCondition(AutomationElement.ControlTypeProperty,
                        ControlType.MenuBar));

                if (aeMenuBars != null && aeMenuBars.Count == 0 || (aeMenuBars.Count > 0 && GetMenuItems(aeMenuBars[0]).Count == 0))
                {
                    AutomationElementCollection aePanes = aeWithMenuBar.FindAll(TreeScope.Children,
                            new PropertyCondition(AutomationElement.ControlTypeProperty,
                            ControlType.Pane));

                    for (int i = 0; i < aePanes.Count; i++)
                    {
                        aeMenuBars = GetMenuBar(aePanes[i]);
                        if (aeMenuBars != null && aeMenuBars.Count > 0 && GetMenuItems(aeMenuBars[0]).Count > 0)
                            break;
                    }
                }
            }
            catch
            {
                // TODO: Handle errors here.
            }

            return aeMenuBars;
        }
    }
}
