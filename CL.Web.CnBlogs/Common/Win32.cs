using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CL.Web.SXDX.Common
{
    public class Win32
    {
        public struct COPYDATASTRUCT
        {
            public int dwData;
            public int cbData;
            public int lpData;
        }
        public const int WM_COPYDATA = 74;
        public const int WM_CHAR = 258;
        public const int WM_IME_CHAR = 646;
        public const int WM_SIZE = 5;
        public const int WM_SYSCOMMAND = 274;
        public static int VarPtr(object e)
        {
            int num = Marshal.SizeOf(e.GetType());
            byte[] value = new byte[num];
            GCHandle gCHandle = GCHandle.Alloc(value, GCHandleType.Pinned);
            IntPtr ptr = gCHandle.AddrOfPinnedObject();
            Marshal.StructureToPtr(e, ptr, false);
            int result = ptr.ToInt32();
            gCHandle.Free();
            return result;
        }
        public static int BtyeArrayPtr(byte[] buf)
        {
            GCHandle gCHandle = GCHandle.Alloc(buf, GCHandleType.Pinned);
            int result = gCHandle.AddrOfPinnedObject().ToInt32();
            gCHandle.Free();
            return result;
        }
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string strClass, string strWindow);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hwnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll")]
        public static extern int SetCursorPos(int x, int y);



        #region DllImport User32
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern IntPtr FindWindowEx(IntPtr hwnd, int s, string tClass, string tTitle);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetDlgItem(IntPtr handleToWindow, int ControlId);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern int GetWindowText(IntPtr handleToWindow, StringBuilder windowText, int maxTextLength);
        #endregion DllImport User32

        #region Methods
        public static string GetWindowText(IntPtr hwnd)
        {
            var length = GetWindowTextLength(hwnd) + 1;
            var buffer = new StringBuilder(length);
            GetWindowText(hwnd, buffer, length);

            return buffer.ToString();
        }

        /// <summary>
        /// 获得总顶级模态弹出窗口(HTMLDIALOG)
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        internal static IntPtr GetTopModalDialogWindows(IntPtr hwnd)
        {
            return FindWindowEx(hwnd, 0, "Internet Explorer_TridentDlgFrame", null);
        }

        /// <summary>
        /// 获得IE子窗口
        /// </summary>
        /// <param name="hwnd">IE句柄</param>
        /// <param name="className">窗口CLASS</param>
        /// <param name="title">窗口标题</param>
        /// <returns></returns>
        internal static IntPtr GetChildWindows(IntPtr hwnd, string className, string title)
        {
            return FindWindowEx(hwnd, 0, className, title);
        }
        #endregion

    }
}
