using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaggieCafe.ClientForms
{
    public partial class FrmSidebar : Form
    {
        public FrmSidebar()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent,
            IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        private void FrmSidebar_Load(object sender, EventArgs e)
        {
            IntPtr hWnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Progman", null);
            ShowWindow(hWnd, 0);

            const int margin = 0;
            int x = Screen.PrimaryScreen.WorkingArea.Right -
                this.Width - margin;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom -
                this.Height - margin;
            this.Location = new Point(x, 0);
            this.Size = new Size(321,Screen.PrimaryScreen.WorkingArea.Height);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Progman", null);
            ShowWindow(hWnd, 5);            
            Process myExplorer = Process.GetProcesses().FirstOrDefault(pp => pp.ProcessName == "explorer");
            if (myExplorer == null) {
                Process.Start(@"C:\Windows\explorer.exe");
            }                
            //FrmLogin frmLogIn = new FrmLogin();
            //frmLogIn.Show();
            //this.Hide();
        }
    }
}
