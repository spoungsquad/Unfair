using System;
using Unfair.Util;
using UnityEngine;

namespace Unfair.UI.Elements
{
	public class Checkbox : UIElement
	{
		public bool Checked;
		public Color Color;
		public Color CheckedColor;
		public Color TextColor;
		public Color StrokeColor;
		public float StrokeWidth;
		public string Text;
		public Action<Checkbox> OnClick;

		public override void Draw()
		{
			var position = AdjustedPosition();
			
			var color = Checked ? CheckedColor : Color;
			
			Render.FillRect(position, new Vector2(15, 15), color);
			Render.DrawRect(position, new Vector2(15, 15), StrokeColor, StrokeWidth);
			Render.DrawString(position + new Vector2(20, -2), new Vector2(15, 15), Text, TextColor);
			
			var isPressed = GUI.Button(new Rect(position, new Vector2(15, 15)), new GUIContent(""), GUI.skin.label);
			if (isPressed)
			{
				Checked = !Checked;
				OnClick?.Invoke(this);
			}
			
			base.Draw();
		}
	}
}