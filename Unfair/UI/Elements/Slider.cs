using System;
using System.Globalization;
using Unfair.Util;
using UnityEngine;

namespace Unfair.UI.Elements
{
	public class Slider : UIElement
	{
		public float Value;
		public float MinValue;
		public float MaxValue;
		public float Step;
		public string Text;
		public Color TrackColor;
		public Color ThumbColor;
		public Color TextColor;
		
		private bool _isDragging;
		
		public Action<Slider> OnValueChanged;

		public override void Draw()
		{
			var pos = AdjustedPosition();
			Render.DrawString(pos, Text, TextColor);
			
			var valueTextSize = Render.MeasureString($"{Value}");
			Render.DrawString(new Vector2(pos.x + Rect.width - valueTextSize.x, pos.y), $"{Value}", TextColor);
			
			Render.FillRect(new Vector2(pos.x, pos.y + 25), new Vector2(Rect.width, 5), TrackColor);
			
			var sliderX = Rect.width / (MaxValue - MinValue) * (Value - MinValue);
			Render.FillRect(new Vector2(pos.x + sliderX, pos.y + 20), new Vector2(5, 10), ThumbColor);
			
			var mousePosition = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
			
			var sliderPos = new Vector2(pos.x, pos.y + 20);
			var sliderSize = new Vector2(Rect.width, 10);
            
            var isMouseOver = _isDragging || mousePosition.x >= sliderPos.x && mousePosition.x <= sliderPos.x + sliderSize.x &&
                            mousePosition.y >= sliderPos.y && mousePosition.y <= sliderPos.y + sliderSize.y;
			
			_isDragging = isMouseOver && Input.GetMouseButton(0);

			if (_isDragging)
			{
				var mouseX = Input.mousePosition.x;
				var mouseXInRect = mouseX - pos.x;
				var value = mouseXInRect / Rect.width * (MaxValue - MinValue) + MinValue;

				// step
				value = Mathf.Round(value / Step) * Step;

				value = Mathf.Clamp(value, MinValue, MaxValue);

				if (Math.Abs(Value - value) > 0.001f)
				{
					Value = value;
					OnValueChanged?.Invoke(this);
				}
			}

			base.Draw();
		}
	}
}