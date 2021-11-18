using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;


namespace laba_4
{
    class Program
    {
        public const uint GENERIC_READ = 0x80000000;
        public const uint OPEN_EXISTING = 3;
        static void Main(string[] args)
        {

            SafeFileHandle file = CreateFile("D:/laba_4.txt", GENERIC_READ, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);

            using (OSHandle os = new OSHandle(file.DangerousGetHandle()))
            {
                Console.WriteLine(os.Handle);
            }
            Console.ReadLine();
        }

      [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
      static extern SafeFileHandle CreateFile(string lpFileName, uint dwDesiredAccess,
      uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition,
      uint dwFlagsAndAttributes, IntPtr hTemplateFile);
    }
}
