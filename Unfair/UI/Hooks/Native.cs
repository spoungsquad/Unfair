using System;
using System.Runtime.InteropServices;

namespace Unfair.UI.Hooks
{
	public delegate int WndProc(IntPtr hWnd, uint msg, UIntPtr wParam, IntPtr lParam);
	
	public static class Native
	{
		[DllImport("user32.dll")]
		public static extern IntPtr FindWindowA(string lpClassName, string lpWindowName);
		
		[DllImport("user32.dll")]
		public static extern int CallWindowProcA(IntPtr lpPrevWndFunc, IntPtr hWnd, uint msg, UIntPtr wParam, IntPtr lParam);
		
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr SetWindowLongPtrA(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
		
		// messages
		public const uint WM_KEYDOWN = 0x0100;
		public const uint WM_KEYUP = 0x0101;
		public const uint WM_SYSKEYDOWN = 0x0104;
		public const uint WM_SYSKEYUP = 0x0105;
		public const uint WM_MOUSEMOVE = 0x0200;
		public const uint WM_LBUTTONDOWN = 0x0201;
		public const uint WM_LBUTTONUP = 0x0202;
		public const uint WM_RBUTTONDOWN = 0x0204;
		public const uint WM_RBUTTONUP = 0x0205;
		public const uint WM_MBUTTONDOWN = 0x0207;
		public const uint WM_MBUTTONUP = 0x0208;
		public const uint WM_MOUSEWHEEL = 0x020A;
	}
}