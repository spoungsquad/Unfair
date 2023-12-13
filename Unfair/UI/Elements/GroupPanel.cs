using Unfair.Util;
using UnityEngine;

namespace Unfair.UI.Elements
{
	public class GroupPanel : Panel
	{
		public string Text;
		public Color TextColor;

		public override void Draw()
		{
			base.Draw();

			var position = AdjustedPosition();
			var textSize = Render.MeasureString(Text);
			position.x += 9;
			position.y -= textSize.y / 2;
			
			Render.DrawString(position, Text, TextColor);
		}
	}
}