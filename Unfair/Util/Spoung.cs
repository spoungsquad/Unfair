using UnityEngine;

namespace Unfair.Util
{
	public static class Spoung
	{
		public static Texture2D DeployTheSpoung()
		{
			using (var stream = typeof(Spoung).Assembly.GetManifestResourceStream("Unfair.Resources.spoung.png"))
			{
				if (stream == null)
				{
					DebugConsole.Write("spoung.png not found in resources");
					return null;
				}
				
				var bytes = new byte[stream.Length];
				var read = stream.Read(bytes, 0, bytes.Length);
				
				if (read != bytes.Length)
				{
					DebugConsole.Write("spoung.png not read correctly");
					return null;
				}

				var texture = new Texture2D(1, 1); // not actual size
				texture.LoadImage(bytes);
				return texture;
			}
		}
	}
}