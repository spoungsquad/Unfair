using UnityEngine;

namespace Unfair.Util
{
    public class Render : MonoBehaviour
    {
        private static Material renderMat = null;
        private static readonly int SrcBlend = Shader.PropertyToID("_SrcBlend");
        private static readonly int DstBlend = Shader.PropertyToID("_DstBlend");
        private static readonly int Cull = Shader.PropertyToID("_Cull");
        private static readonly int ZTest = Shader.PropertyToID("_ZTest");
        private static readonly int ZWrite = Shader.PropertyToID("_ZWrite");
        private static readonly int Color1 = Shader.PropertyToID("_Color");

        public static Color Color { get; set; } = Color.white;

        public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);
        
        public static void DrawLine(Vector2 start, Vector2 end, float width, Color color)
        {
            InitMat();
            renderMat.SetColor("_Color", color);
            GL.PushMatrix();
            GL.LoadPixelMatrix(0, Screen.width, Screen.height, 0);
            GL.Begin(1);
            GL.Color(color);
            GL.Vertex3(start.x, start.y, 0f);
            GL.Vertex3(end.x, end.y, 0f);
            GL.End();
            GL.PopMatrix();
        }
        
        public static void DrawLine(Vector2 start, Vector2 end, Color color, float width = 1f)
        {
            DrawLine(start, end, width, color);
        }
        
        public static void FillRect(Rect rect, Color color) // Filled btw
        {
            InitMat();
            renderMat.SetColor("_Color", color);
            GL.PushMatrix();
            GL.LoadPixelMatrix(0, Screen.width, Screen.height, 0);
            GL.Begin(7); // 7 = GL.QUADS
            GL.Color(color);
            GL.Vertex3(rect.xMin, rect.yMin, 0f);
            GL.Vertex3(rect.xMax, rect.yMin, 0f);
            GL.Vertex3(rect.xMax, rect.yMax, 0f);
            GL.Vertex3(rect.xMin, rect.yMax, 0f);
            GL.End();
            GL.PopMatrix();
        }
        
        public static void FillRect(Rect rect)
        {
            FillRect(rect, Color);
        }
        
        public static void FillRect(Vector2 position, Vector2 size, Color color)
        {
            FillRect(new Rect(position, size), color);
        }
        
        public static void FillRect(Vector2 position, Vector2 size)
        {
            FillRect(new Rect(position, size), Color);
        }
        
        public static void DrawRect(Rect rect, Color color, float width = 1f)
        {
            InitMat();
            renderMat.SetColor("_Color", color);
            GL.PushMatrix();
            GL.LoadPixelMatrix(0, Screen.width, Screen.height, 0);
            GL.Begin(1);
            GL.Color(color);
            GL.Vertex3(rect.xMin, rect.yMin, 0f);
            GL.Vertex3(rect.xMax, rect.yMin, 0f);
            GL.Vertex3(rect.xMax, rect.yMax, 0f);
            GL.Vertex3(rect.xMin, rect.yMax, 0f);
            GL.End();
            GL.PopMatrix();
        }
        
        public static void DrawRect(Rect rect, float width = 1f)
        {
            DrawRect(rect, Color, width);
        }
        
        public static void DrawRect(Vector2 position, Vector2 size, Color color, float width = 1f)
        {
            DrawRect(new Rect(position, size), color, width);
        }
        
        public static void DrawRect(Vector2 position, Vector2 size, float width = 1f)
        {
            DrawRect(new Rect(position, size), Color, width);
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

            renderMat = new Material(Shader.Find($"Hidden/Internal-Colored"))
            {
                hideFlags = HideFlags.DontSaveInEditor | HideFlags.HideInHierarchy
            };
            renderMat.SetInt(SrcBlend, (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            renderMat.SetInt(DstBlend, (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            renderMat.SetInt(Cull, (int)UnityEngine.Rendering.CullMode.Off);
            renderMat.SetInt(ZTest, (int)UnityEngine.Rendering.CompareFunction.Always);
            renderMat.SetInt(ZWrite, 0);
            renderMat.SetColor(Color1, Color.clear);

            return renderMat;
        }

        public static bool DrawButton(Rect rect, string text, Color textColor, Color boxColor)
        {
            FillRect(rect, boxColor);
            DrawString(new Vector2(rect.position.x + rect.size.x / 2, rect.position.y + rect.size.y / 2), text, textColor, true);
            return GUI.Button(rect, new GUIContent(""), StringStyle);
        }
    }
}