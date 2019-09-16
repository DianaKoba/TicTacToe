using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GameUI
{
    public static class Program
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameSettingsForm());
        }
    }
}
