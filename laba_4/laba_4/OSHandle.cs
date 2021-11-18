using System;
using System.Runtime.InteropServices;

namespace laba_4
{
    class OSHandle : IDisposable
    {

        [DllImport("Kernel32.dll")]
        private static extern bool CloseHandle(IntPtr handle);

        public IntPtr Handle { set; get; }
       
        public OSHandle(IntPtr Handle)
        {
            this.Handle = Handle;
        }

        ~OSHandle(){
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Handle != IntPtr.Zero)
            {
                Console.WriteLine(CloseHandle(Handle));
                Handle = IntPtr.Zero;
                Console.WriteLine("Dispose with disposing = " + disposing + ", Handle = " + Handle);
            }
        }
    }
}
