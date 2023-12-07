using UnityEngine;

namespace Unfair.Util
{
    public class Render : MonoBehaviour
    {
        private static Material renderMat = null;

        public static Color Color
        {
            get { return GUI.color; }
            set { GUI.color = value; }
        }

        public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);

        public static void DrawBox(Vector2 position, Vector2 size, Color color)
        {
            Color = color;
            DrawBox(position, size);
        }

        public static void DrawBox(float x, float y, float width, float height, Color color)
        {
            Color = color;
            DrawBox(new Vector2(x, y), new Vector2(width, height));
        }

        public static void DrawBox(Vector2 position, Vector2 size)
        {
            GUI.DrawTexture(new Rect(position, size), Texture2D.whiteTexture, ScaleMode.StretchToFill);
        }

        public static void DrawBoxGUI(Rect rect, Color color, float thickness)
        {
            Texture2D tex = new Texture2D(1, 1);
            tex.SetPixel(0, 0, color);
            tex.Apply();

            Color originalColor = GUI.color;

            GUI.color = color;

            GUI.DrawTexture(new Rect(rect.x, rect.y, rect.width, thickness), tex);
            GUI.DrawTexture(new Rect(rect.x, rect.y, thickness, rect.height), tex);
            GUI.DrawTexture(new Rect(rect.x + rect.width - thickness, rect.y, thickness, rect.height), tex);
            GUI.DrawTexture(new Rect(rect.x, rect.y + rect.height - thickness, rect.width, thickness), tex);

            GUI.color = originalColor;
        }

        public static void DrawBoxOutline(Vector2 origin, float width, float height, Color color)
        {
            DrawLine(origin, new Vector2(origin.x + width, origin.y), color);
            DrawLine(origin, new Vector2(origin.x, origin.y + height), color);
            DrawLine(new Vector2(origin.x + width, origin.y + height), new Vector2(origin.x + width, origin.y), color);
            DrawLine(new Vector2(origin.x + width, origin.y + height), new Vector2(origin.x, origin.y + height), color);
        }

        public static bool DrawButton(Rect rect, string text, Color textColor, Color buttonColor)
        {
            DrawBoxOutline(rect.position, rect.width + 6, rect.height, buttonColor);
            DrawString(rect.position + new Vector2(3, 0), text, textColor, false); // padding!

            return GUI.Button(rect, new GUIContent(""), GUI.skin.label); // invis button
        }

        public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color)
        {
            var mat = InitMat();
            mat.SetColor("_Color", color);

            GL.PushMatrix();
            GL.LoadPixelMatrix(0, Screen.width, Screen.height, 0);
            GL.Begin(1); // 1 = GL.LINES

            GL.Color(color);

            GL.Vertex(pointA);
            GL.Vertex(pointB);

            GL.End();
            GL.PopMatrix();
        }

        public static void DrawRect(Rect rect, Color color)
        {
            var mat = InitMat();
            mat.SetColor("_Color", color);

            GL.PushMatrix();
            GL.LoadPixelMatrix(0, Screen.width, Screen.height, 0);
            GL.Begin(7); // 7 = GL.QUADS

            GL.Color(color);

            GL.Vertex(new Vector3(rect.x + rect.width, rect.y));
            GL.Vertex(new Vector3(rect.x, rect.y));
            GL.Vertex(new Vector3(rect.x, rect.y + rect.height));
            GL.Vertex(new Vector3(rect.x + rect.width, rect.y + rect.height));

            GL.End();
            GL.PopMatrix();
        }

        public static void DrawString(Vector2 position, string label, Color color, bool centered)
        {
            Color = color;
            DrawString(position, label, centered);
        }

        public static void DrawString(Vector2 position, string label, bool centered = true)
        {
            GUIContent content = new GUIContent(label);
            Vector2 size = StringStyle.CalcSize(content);
            Vector2 upperLeft = centered ? position - size / 2f : position;
            GUI.Label(new Rect(upperLeft, size), label);
        }

        public static float GetTextWidth(string text)
        {
            GUIContent content = new GUIContent(text);
            Vector2 size = StringStyle.CalcSize(content);
            return size.x;
        }

        private static Material InitMat()
        {
            if (renderMat != null) return renderMat;

            renderMat = new Material(Shader.Find("Hidden/Internal-Colored"))
            {
                hideFlags = HideFlags.DontSaveInEditor | HideFlags.HideInHierarchy
            };
            renderMat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            renderMat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            renderMat.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            renderMat.SetInt("_ZTest", (int)UnityEngine.Rendering.CompareFunction.Always);
            renderMat.SetInt("_ZWrite", 0);
            renderMat.SetColor("_Color", Color.clear);

            return renderMat;
        }
    }
}