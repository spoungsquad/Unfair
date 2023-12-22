using System;
using System.Runtime.InteropServices;
using Unfair.Util;

namespace Unfair.UI.Hooks
{
	public static class WindowHook
	{
		private static IntPtr _originalWndProc;
		private static int _lol;
		
		private static int WndProc(IntPtr hWnd, int msg, int wParam, int lParam)
		{
			switch (msg)
			{
				case Native.WM_KEYDOWN:
				case Native.WM_SYSKEYDOWN:
					DebugConsole.Write("Key down: " + wParam);
					break;
				case Native.WM_KEYUP:
				case Native.WM_SYSKEYUP:
					DebugConsole.Write("Key up: " + wParam);
					break;
				case Native.WM_MOUSEMOVE:
					DebugConsole.Write("Mouse move");
					break;
				case Native.WM_LBUTTONDOWN:
					DebugConsole.Write("Left mouse down");
					break;
				case Native.WM_LBUTTONUP:
					DebugConsole.Write("Left mouse up");
					break;
				case Native.WM_RBUTTONDOWN:
					DebugConsole.Write("Right mouse down");
					break;
				case Native.WM_RBUTTONUP:
					DebugConsole.Write("Right mouse up");
					break;
				case Native.WM_MBUTTONDOWN:
					DebugConsole.Write("Middle mouse down");
					break;
				case Native.WM_MBUTTONUP:
					DebugConsole.Write("Middle mouse up");
					break;
				case Native.WM_MOUSEWHEEL:
					DebugConsole.Write("Mouse wheel");
					break;
				default:
					// literally junkcode
					_lol++;
					break;
			}
			
			if (_lol > 100)
				_lol = 0;
			
			return Native.CallWindowProcA(_originalWndProc, hWnd, msg, wParam, lParam);
		}
		
		public static void Hook()
		{
			_originalWndProc = Native.SetWindowLongPtrA(
				Native.FindWindowA(null, "1v1.LOL"), 
				-4, Marshal.GetFunctionPointerForDelegate(new WndProc(WndProc)));

			if (_originalWndProc == IntPtr.Zero)
			{
				DebugConsole.Write($"Failed to create window hook, error code: 0x{Marshal.GetLastWin32Error():X}");
				return;
			}
			
			DebugConsole.Write("Created window hook");
		}
	}
}