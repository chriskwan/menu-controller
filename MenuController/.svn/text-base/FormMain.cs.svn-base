using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Automation;

namespace MenuController
{
    public partial class FormMain : Form
    {
        private const string VERSION = "Menu Controller v1.1.25";

        enum OrientationTypes
        {
            HorizontalTop, HorizontalBottom, VerticalLeft, VerticalRight
        };

        enum DisplayBehaviorTypes
        {
            AutoResizeCompatible, AutoHideMenuController, None
        };

        private Int32 _currentWnd;
        private Boolean _lastWndWasThis = false;
        private Boolean _mouseEntered = false;
        private McButton _lastClickedButton = null;

        public FormMain()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            //pbContainer.BackColor = Color.DarkKhaki; //for debugging
            
            this.TopMost = Settings.Default.AlwaysOnTop;
            
            //fill up the entire screen height or width depending on orientation
            if (this.Orientation == OrientationTypes.VerticalLeft || this.Orientation == OrientationTypes.VerticalRight)
            {
                this.Height = Screen.PrimaryScreen.Bounds.Height;
                btnExit.Left = 0;
                btnOptions.Left = 0;
            }
            else
            {
                this.Width = Screen.PrimaryScreen.Bounds.Width;
                btnOptions.Left = this.Right - (btnOptions.Width + 5);
                btnExit.Left = btnOptions.Left - (btnExit.Width + 5);
            }

            pbContainer.Top = this.Top;
            pbContainer.Left = this.Left;
            btnLeft.Height = ButtonDim;
            btnLeft.Width = ButtonDim;
            btnRight.Height = ButtonDim;
            btnRight.Width = ButtonDim;

            //place arrows depending on orientation:
            //if vertical orientations
            if (this.Orientation == OrientationTypes.VerticalLeft || this.Orientation == OrientationTypes.VerticalRight)
            {
                //calculate how many buttons can fit on the screen, rounding up
                int numButtonsOnScreen = (int)((Screen.PrimaryScreen.Bounds.Height / (double)ButtonIncrement) + 0.5);

                //place the left arrow button one button space before the middle button
                btnLeft.Top = ((numButtonsOnScreen / 2 - 1) * ButtonIncrement);

                //leave a gap the size of a button + spacing on either side between the arrow buttons
                btnRight.Top = btnLeft.Top + btnLeft.Height + ButtonSpacing + ButtonDim + ButtonSpacing;

                //arrow button icons
                btnLeft.Text = @"\/";
                btnRight.Text = @"/\";
            }
            else //else horizontal orientations
            {
                //calculate how many buttons can fit on the screen, rounding up
                int numButtonsOnScreen = (int)((Screen.PrimaryScreen.Bounds.Width / (double)ButtonIncrement) + 0.5);

                //place the left arrow button one button space before the middle button
                btnLeft.Left = ((numButtonsOnScreen / 2 - 1) * ButtonIncrement);

                //leave a gap the size of a button + spacing on either side between the arrow buttons
                btnRight.Left = btnLeft.Left + btnLeft.Width + ButtonSpacing + ButtonDim + ButtonSpacing;

                //arrow button icons
                btnLeft.Text = ">";
                btnRight.Text = "<";
            }

            lblVersion.Text = VERSION;
            tmrUpdate.Start();
            Collapse(true);
        }

        private void AddButtons(List<MenuUtilities.MenuItem> mil)
        {
            pbContainer.Controls.Clear();
            int j = 0;

            for (int i = 0; i < mil.Count; i++)
            {
                if (mil[i].text.Trim() != "")
                {
                    McButton b = new McButton();
                    b.Text = mil[i].text;
                    ToolTip tt = new ToolTip();
                    tt.SetToolTip(b, mil[i].text);
                    if (mil[i].aeMenu != null)
                        b.aeMenu = mil[i].aeMenu;
                    else
                        b.Tag = mil[i].hMenu + ";" + i;
                    b.Enabled = !mil[i].isDisabled;
                    b.Width = ButtonDim;
                    b.Height = ButtonDim;

                    if (this.Orientation == OrientationTypes.VerticalLeft || this.Orientation == OrientationTypes.VerticalRight)
                    {
                        b.Top = j * ButtonIncrement;
                    }
                    else
                    {
                        b.Left = j * ButtonIncrement;
                    }

                    b.Click += new EventHandler(button_Click);
                    b.Font = new System.Drawing.Font("Arial", 18);
                    pbContainer.Controls.Add(b);
                    j++;
                }
            }

            if (this.Orientation == OrientationTypes.VerticalLeft || this.Orientation == OrientationTypes.VerticalRight)
            {
                pbContainer.Width = ButtonDim;
                pbContainer.Height = mil.Count * ButtonIncrement - ButtonSpacing;
            }
            else
            {
                pbContainer.Width = mil.Count * ButtonIncrement - ButtonSpacing;
                pbContainer.Height = ButtonDim;
            }
        }

        void button_Click(object sender, EventArgs e)
        {
            McButton button = (McButton)sender;

            if (button.aeMenu != null)
            {
                List<MenuUtilities.MenuItem> mil = MenuUtilities.GetMenuItems(button.aeMenu, true);
                if (mil.Count > 0)
                    AddButtons(mil);
                else 
                {
                    HighlightLastClicked(button);
                    MenuUtilities.ClickMenuItem(button.aeMenu);
                }
            }
            else
            {
                string[] tag = ((McButton)sender).Tag.ToString().Split(';');
                IntPtr ips = WindowsAPI.GetSubMenu((IntPtr)Convert.ToInt32(tag[0]), Convert.ToInt32(tag[1]));
                if (WindowsAPI.GetMenuItemCount(ips) > 0)
                    AddButtons(MenuUtilities.GetMenuItems(ips));
                else
                {
                    HighlightLastClicked(button);
                    IntPtr hMenu = new IntPtr(Convert.ToInt32(tag[0]));
                    MenuUtilities.ClickMenuItem(hMenu, Convert.ToInt32(tag[1]), _currentWnd);
                }
            }
        }

        private void HighlightLastClicked(McButton button)
        {
            button.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            if (_lastClickedButton != null)
                _lastClickedButton.BackColor = System.Drawing.SystemColors.Control;
            _lastClickedButton = button;
        }

        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            if (DisplayBehavior == DisplayBehaviorTypes.AutoHideMenuController)
            {
                Point pos = this.PointToClient(Cursor.Position);
                bool entered = this.ClientRectangle.Contains(pos);
                if (entered != _mouseEntered)
                {
                    _mouseEntered = entered;
                    if (!entered)
                    {
                        Collapse(false);
                        WindowsAPI.SetForegroundWindow(new IntPtr(_currentWnd));
                    }
                    else if (pbContainer.Controls.Count > 0)
                    {
                        Expand();
                        WindowsAPI.SetForegroundWindow(this.Handle);
                    }
                }
            }

            Int32 hWnd = WindowsAPI.GetForegroundWindow();
            if (hWnd == (Int32)this.Handle)
                _lastWndWasThis = true;
            else if (_lastWndWasThis)
            {
                _lastWndWasThis = false;
                _currentWnd = 0;
            }
            if (hWnd != _currentWnd && hWnd != (Int32)this.Handle && hWnd != 0)
            {
                _currentWnd = hWnd;
                IntPtr ip = WindowsAPI.GetMenu(_currentWnd);
                List<MenuUtilities.MenuItem> mil = null;
                if ((int)ip != 0)
                {
                    mil = MenuUtilities.GetMenuItems(ip);
                    if (mil.Count == 0)
                        mil = MenuUtilities.GetMenuItems(_currentWnd);
                }
                else
                {
                    mil = MenuUtilities.GetMenuItems(_currentWnd);
                }

                if (mil != null && mil.Count > 0)
                {
                    AddButtons(mil);
                    lblVersion.Text = VERSION + " - IN-FOCUS WINDOW COMPATIBLE.";
                    lblVersion.BackColor = Color.PaleGreen;
                    if (DisplayBehavior != DisplayBehaviorTypes.AutoHideMenuController)
                        Expand();
                }
                else
                {
                    lblVersion.Text = VERSION + " - IN-FOCUS WINDOW NOT COMPATIBLE.";
                    lblVersion.BackColor = Color.LightPink;
                    Collapse(true);
                }
            }
        }

        /// <summary>
        /// Collapse Menu Controller if the in focus application is NOT compatible.
        /// </summary>
        private void Collapse(bool clearButtons)
        {
            pbContainer.Visible = false;
            if (clearButtons)
                pbContainer.Controls.Clear();

            //vertical
            if (this.Orientation == OrientationTypes.VerticalLeft || this.Orientation == OrientationTypes.VerticalRight)
            {
                btnExit.Left = 5;
                this.Width = btnExit.Left + btnExit.Width;
                
                btnOptions.Left = 5;
                lblVersion.Left = 5;                
            }
            else //horizontal
            {
                btnExit.Top = 5;
                this.Height = btnExit.Top + btnExit.Height;
     
                btnOptions.Top = 5;
                lblVersion.Top = 5;
            }
            
            SetScreenLocation();
        }

        /// <summary>
        /// Expand Menu Controller if the in focus application IS compatible
        /// </summary>
        private void Expand()
        {
            pbContainer.Visible = true;

            if (this.Orientation == OrientationTypes.VerticalLeft || this.Orientation == OrientationTypes.VerticalRight)
            {
                btnExit.Left = ButtonDim * 2 - 25;
                btnOptions.Left = ButtonDim * 2 - 25;
                btnOptions.Top = btnExit.Bottom + 2;
                lblVersion.Left = ButtonDim * 2 - 25;

                btnLeft.Left = ButtonDim + ButtonSpacing;
                btnRight.Left = ButtonDim + ButtonSpacing;
                this.Width = btnLeft.Right;
            }
            else
            {
                btnExit.Top = ButtonDim * 2 - 25;
                btnOptions.Top = ButtonDim * 2 - 25;
                lblVersion.Top = ButtonDim * 2 - 25;

                btnLeft.Top = ButtonDim + ButtonSpacing;
                btnRight.Top = ButtonDim + ButtonSpacing;
                this.Height = btnLeft.Bottom;
            }
            
            if (DisplayBehavior == DisplayBehaviorTypes.AutoResizeCompatible)
                WindowsAPI.SetWindowPos(new IntPtr(_currentWnd), 0, 0, this.Height, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - this.Height, WindowsAPI.SWP_SHOWWINDOW);

            SetScreenLocation();
        }

        private void SetScreenLocation()
        {
            this.Top = 0;
            this.Left = 0;
            if (this.Orientation == OrientationTypes.VerticalLeft)
            {
                this.Left = 0;
            }
            else if (this.Orientation == OrientationTypes.VerticalRight)
            {
                this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width;
            }
            else if (this.Orientation == OrientationTypes.HorizontalTop)
            {
                this.Top = 0;
            }
            else if (this.Orientation == OrientationTypes.HorizontalBottom)
            {
                this.Top = Screen.PrimaryScreen.Bounds.Height - this.Height;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            FormOptions fo = new FormOptions();
            fo.ShowDialog(this);

            Initialize();
        }

        /// <summary>
        /// Slide the toolbar to the "previous" position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeft_Click(object sender, EventArgs e)
        {
            //vertical:
            if (this.Orientation == OrientationTypes.VerticalLeft || this.Orientation == OrientationTypes.VerticalRight)
            {
                //only slide if the topmost button does not go beyond the bottom edge of the screen
                if ((pbContainer.Top + ButtonIncrement) < Screen.PrimaryScreen.Bounds.Height)
                {
                    pbContainer.Top += ButtonIncrement;
                }
            }
            else //horizontal:
            { 
                //only slide if the leftmost button does not go beyond the right edge of the screen
                if ((pbContainer.Left + ButtonIncrement) < Screen.PrimaryScreen.Bounds.Width)
                {
                    pbContainer.Left += ButtonIncrement;
                }
            }
        }

        /// <summary>
        /// Slide the toolbar to the "next" position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRight_Click(object sender, EventArgs e)
        {
            //vertical:
            if (this.Orientation == OrientationTypes.VerticalLeft || this.Orientation == OrientationTypes.VerticalRight)
            {
                //only slide if the bottommost button does not go beyond the top edge of the screen
                int pbContainerBottom = pbContainer.Top + pbContainer.Height;
                if ((pbContainerBottom - ButtonIncrement) > 0)
                {
                    pbContainer.Top -= ButtonIncrement;
                }
            }
            else //horizontal:
            {
                //only slide if the rightmost button does not go beyond the left edge of the screen
                int pbContainerRight = pbContainer.Left + pbContainer.Width;
                if ((pbContainerRight - ButtonIncrement) > 0)
                {
                    pbContainer.Left -= ButtonIncrement;
                }
            }            
        }

        private int ButtonDim
        {
            get { return Convert.ToInt32(Settings.Default.ButtonSize.Split('x')[0]); }
        }

        private int ButtonSpacing
        {
            get { return ButtonDim / 2; }
        }

        private int ButtonIncrement
        {
            get { return ButtonDim + ButtonSpacing; }
        }

        private OrientationTypes Orientation
        {
            get
            {
                string orientation = Settings.Default.Orientation;
                if (orientation == "Horizontal - Top")
                    return FormMain.OrientationTypes.HorizontalTop;
                else if (orientation == "Horizontal - Bottom")
                    return FormMain.OrientationTypes.HorizontalBottom;
                else if (orientation == "Vertical - Left")
                    return FormMain.OrientationTypes.VerticalLeft;
                else if (orientation == "Vertical - Right")
                    return FormMain.OrientationTypes.VerticalRight;
                else
                    return FormMain.OrientationTypes.HorizontalTop;
            }
        }

        private DisplayBehaviorTypes DisplayBehavior
        {
            get
            {
                string displayBehavior = Settings.Default.DisplayBehavior;
                if (displayBehavior == "None")
                    return DisplayBehaviorTypes.None;
                else if (displayBehavior == "Auto-resize compatible windows")
                    return DisplayBehaviorTypes.AutoResizeCompatible;
                else if (displayBehavior == "Auto-hide Menu Controller")
                    return DisplayBehaviorTypes.AutoHideMenuController;
                else
                    return DisplayBehaviorTypes.None;
            }
        }
    }
}
