namespace WhatDoSC
{
    static class Program
    {
        [STAThread]
        static void Main()  // 
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreen());// RUNNING WORKSPACE FORCIBLY
        }
    }
}