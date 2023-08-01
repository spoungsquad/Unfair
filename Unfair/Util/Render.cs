using UnityEngine;

namespace Unfair.Util
{
    public class Render : MonoBehaviour
	{
		public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);

		public static Color Color
		{
			get { return GUI.color; }
			set { GUI.color = value; }
		}
		
		public static void DrawBox(Vector2 position, Vector2 size, Color color, bool centered = true)
		{
			Color = color;
			DrawBox(position, size, centered);
		}
		public static void DrawBox(Vector2 position, Vector2 size, bool centered = true)
		{
			var upperLeft = centered ? position - size / 2f : position;
			GUI.DrawTexture(new Rect(position, size), Texture2D.blackTexture, ScaleMode.StretchToFill);
		}

		public static void DrawString(Vector2 position, string label, Color color, bool centered)
		{
			Color = color;
			DrawString(position, label, centered);
		}
		public static void DrawString(Vector2 position, string label, bool centered = true)
		{
			var content = new GUIContent(label);
			var size = StringStyle.CalcSize(content);
			var upperLeft = centered ? position - size / 2f : position;
			GUI.Label(new Rect(upperLeft, size), label);
		}

		public static void DrawBoxGUI(Rect rect, Color color, float thickness)
		{
			var tex = new Texture2D(1, 1);
			tex.SetPixel(0, 0, color);
			tex.Apply();

			var originalColor = GUI.color;
                
			GUI.color = color;
                
			GUI.DrawTexture(new Rect(rect.x, rect.y, rect.width, thickness), tex);
			GUI.DrawTexture(new Rect(rect.x, rect.y, thickness, rect.height), tex);
			GUI.DrawTexture(new Rect(rect.x + rect.width - thickness, rect.y, thickness, rect.height), tex);
			GUI.DrawTexture(new Rect(rect.x, rect.y + rect.height - thickness, rect.width, thickness), tex);
                
			GUI.color = originalColor;
		}
		
		public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color)
		{
			var texture = new Texture2D(1, 1);
			texture.SetPixel(0, 0, color);
			texture.Apply();
			
			var angle = Vector2.Angle(pointB - pointA, Vector2.right);
			
			if (pointA.y > pointB.y)
				angle = -angle;
			
			var length = (pointB - pointA).magnitude;
			
			GUIUtility.RotateAroundPivot(angle, pointA);
			GUI.DrawTexture(new Rect(pointA.x, pointA.y, length, 1f), texture);
			GUIUtility.RotateAroundPivot(-angle, pointA);
			
			Destroy(texture);
		}
		

		public static Texture2D lineTex;
		public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color, float width)
		{
			Matrix4x4 matrix = GUI.matrix;
			if (!lineTex)
				lineTex = new Texture2D(1, 1);

			Color color2 = GUI.color;
			GUI.color = color;
			float num = Vector3.Angle(pointB - pointA, Vector2.right);

			if (pointA.y > pointB.y)
				num = -num;

			GUIUtility.ScaleAroundPivot(new Vector2((pointB - pointA).magnitude, width), new Vector2(pointA.x, pointA.y + 0.5f));
			GUIUtility.RotateAroundPivot(num, pointA);
			GUI.DrawTexture(new Rect(pointA.x, pointA.y, 1f, 1f), lineTex);
			GUI.matrix = matrix;
			GUI.color = color2;
		}

		public static void DrawBox(float x, float y, float w, float h, Color color, float thickness)
		{
			DrawLine(new Vector2(x, y), new Vector2(x + w, y), color, thickness);
			DrawLine(new Vector2(x, y), new Vector2(x, y + h), color, thickness);
			DrawLine(new Vector2(x + w, y), new Vector2(x + w, y + h), color, thickness);
			DrawLine(new Vector2(x, y + h), new Vector2(x + w, y + h), color, thickness);
		}

		public static void DrawBoxOutline(Vector2 Point, float width, float height, Color color, float thickness)
		{
			DrawLine(Point, new Vector2(Point.x + width, Point.y), color, thickness);
			DrawLine(Point, new Vector2(Point.x, Point.y + height), color, thickness);
			DrawLine(new Vector2(Point.x + width, Point.y + height), new Vector2(Point.x + width, Point.y), color, thickness);
			DrawLine(new Vector2(Point.x + width, Point.y + height), new Vector2(Point.x, Point.y + height), color, thickness);
		}

		public static float GetTextWidth(string text)
        {
			var content = new GUIContent(text);
			var size = StringStyle.CalcSize(content);
			return size.x;
		}

		public static bool DrawButton(Rect rect, string text, Color textColor, Color buttonColor)
        {
			DrawBoxOutline(rect.position, rect.width + 6, rect.height, buttonColor, 3);
			DrawString(rect.position + new Vector2(3, 0), text, textColor, false); // padding!
			
			
			return GUI.Button(rect, new GUIContent(""), GUI.skin.label); // invis button
        }
	}
}