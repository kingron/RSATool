using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSATool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            typeof(Form).GetField("defaultIcon", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, icon);
            Application.Run(new MainForm());
        }
    }
}
