using System;
using System.Runtime.InteropServices;

namespace Unfair.UI.Hooks
{
	public delegate int WndProc(IntPtr hWnd, int msg, int wParam, int lParam);
	
	public static class Native
	{
		[DllImport("user32.dll")]
		public static extern IntPtr FindWindowA(string lpClassName, string lpWindowName);
		
		[DllImport("user32.dll")]
		public static extern int CallWindowProcA(IntPtr lpPrevWndFunc, IntPtr hWnd, int msg, int wParam, int lParam);
		
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr SetWindowLongPtrA(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
		
		// messages
		public const int WM_KEYDOWN = 0x0100;
		public const int WM_KEYUP = 0x0101;
		public const int WM_SYSKEYDOWN = 0x0104;
		public const int WM_SYSKEYUP = 0x0105;
		public const int WM_MOUSEMOVE = 0x0200;
		public const int WM_LBUTTONDOWN = 0x0201;
		public const int WM_LBUTTONUP = 0x0202;
		public const int WM_RBUTTONDOWN = 0x0204;
		public const int WM_RBUTTONUP = 0x0205;
		public const int WM_MBUTTONDOWN = 0x0207;
		public const int WM_MBUTTONUP = 0x0208;
		public const int WM_MOUSEWHEEL = 0x020A;
	}
}