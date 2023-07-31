using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Unfair.Util
{
	public static class DebugConsole
	{
		// native imports
		[DllImport("kernel32.dll")]
		private static extern bool AttachConsole(int dwProcessId);

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool AllocConsole();
		
		private const int ATTACH_PARENT_PROCESS = -1;

		// the meat
		private static bool _init;
		private static StreamWriter _writer;

		private static void Allocate()
		{
			AllocConsole();

			var stdout = Console.OpenStandardOutput();
			_writer = new StreamWriter(stdout)
			{
				AutoFlush = true
			};

			AttachConsole(ATTACH_PARENT_PROCESS);
			_init = true;
		}

		public static void Write(string text)
		{
#if DEBUG
			if (!_init)
			{
				Allocate();
			} // only allocates a console if visual studio is found
#endif
			
			_writer.WriteLine(text);
			Console.WriteLine(text);
		}
	}
}