using System.Runtime.InteropServices;

namespace JaProjekt
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }

    public static class AssemblyDLL
    {
        [DllImport(@"C:\Users\janma\source\repos\JaProjekt\x64\Release\JAAsm.dll")]

        public static extern int MyProc1(int a,int b);
    }
}