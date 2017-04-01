using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace k8asd {
    /// <summary>
    /// http://stackoverflow.com/questions/32591157/richtextbox-selection-choose-color-while-selecting/32618479#32618479
    /// http://stackoverflow.com/questions/3282384/richtextbox-syntax-highlighting-in-real-time-disabling-the-repaint/3282911#3282911
    /// </summary>
    public class FastRichTextBox : RichTextBoxEx {
        [DllImport("kernel32.dll", EntryPoint = "LoadLibraryW", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr LoadLibraryW(string s_File);

        public static IntPtr LoadLibrary(string s_File) {
            IntPtr h_Module = LoadLibraryW(s_File);
            if (h_Module != IntPtr.Zero)
                return h_Module;

            int s32_Error = Marshal.GetLastWin32Error();
            throw new Win32Exception(s32_Error);
        }

        protected override CreateParams CreateParams {
            get {
                CreateParams i_Params = base.CreateParams;
                try {
                    // Available since XP SP1
                    LoadLibrary("MsftEdit.dll"); // throws

                    // Replace "RichEdit20W" with "RichEdit50W"
                    i_Params.ClassName = "RichEdit50W";
                } catch {
                    // Windows XP without any Service Pack.
                }
                return i_Params;
            }
        }

        public void BeginUpdate() {
            SendMessage(Handle, WM_SETREDRAW, (IntPtr) 0, IntPtr.Zero);
        }

        public void EndUpdate() {
            SendMessage(Handle, WM_SETREDRAW, (IntPtr) 1, IntPtr.Zero);
            Invalidate();
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private const int WM_SETREDRAW = 0x0b;
    }
}
