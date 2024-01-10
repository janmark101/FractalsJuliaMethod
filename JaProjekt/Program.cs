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
        [DllImport(@"C:\Users\janma\source\repos\JaProjekt\x64\Debug\JAAsm.dll")]

        public static extern void MyProc1(int a, int b);
    }
}