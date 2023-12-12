using System;
using UnityEngine;

namespace Unfair.Util
{
    public enum GLMode
    {
        Lines = 1,
        Quads = 7
    }

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

            // Calculate the perpendicular offset vector
            Vector2 offset = (end - start).normalized * width / 2f;

            // Calculate the four corner points of the rectangle
            Vector2 topLeft = start + new Vector2(-offset.y, offset.x);
            Vector2 topRight = start + new Vector2(offset.y, -offset.x);
            Vector2 bottomLeft = end + new Vector2(-offset.y, offset.x);
            Vector2 bottomRight = end + new Vector2(offset.y, -offset.x);

            GL.PushMatrix();
            GL.LoadPixelMatrix(0, Screen.width, Screen.height, 0);
            GL.Begin((int)GLMode.Quads); // Use GL.QUADS to draw a filled rectangle

            GL.Color(color);
            GL.Vertex3(topLeft.x, topLeft.y, 0f);
            GL.Vertex3(topRight.x, topRight.y, 0f);
            GL.Vertex3(bottomRight.x, bottomRight.y, 0f);
            GL.Vertex3(bottomLeft.x, bottomLeft.y, 0f);

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
            GL.Begin(1); // 1 = GL.LINES
            GL.Color(color);
            GL.Vertex3(rect.xMin, rect.yMin, 0f);
            GL.Vertex3(rect.xMax, rect.yMin, 0f);
            GL.Vertex3(rect.xMax, rect.yMin, 0f);
            GL.Vertex3(rect.xMax, rect.yMax, 0f);
            GL.Vertex3(rect.xMax, rect.yMax, 0f);
            GL.Vertex3(rect.xMin, rect.yMax, 0f);
            GL.Vertex3(rect.xMin, rect.yMax, 0f);
            GL.Vertex3(rect.xMin, rect.yMin, 0f);
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
            DrawString(new Vector2(rect.position.x + rect.size.x / 2, rect.position.y + rect.size.y / 2), text,
                textColor, true);
            return GUI.Button(rect, new GUIContent(""), StringStyle);
        }

        public static void DrawTexture(Rect rect, Texture2D texture)
        {
            GUI.DrawTexture(rect, texture);
        }

        private static readonly float Deg2Rad = (float)Math.PI / 180f;

        public static void DrawCircle(Vector2 vector2, float maxDistanceFromCenter, Color red)
        {
            InitMat();
            renderMat.SetColor("_Color", red);
            GL.PushMatrix();
            GL.LoadPixelMatrix(0, Screen.width, Screen.height, 0);
            GL.Begin(1);
            GL.Color(red);
            // be sure to connect these with lines
            for (int i = 0; i < 360; i++)
            {
                float degInRad = i * Deg2Rad;
                GL.Vertex3(vector2.x + Mathf.Cos(degInRad) * maxDistanceFromCenter,
                    vector2.y + Mathf.Sin(degInRad) * maxDistanceFromCenter, 0);
            }

            GL.End();
            GL.PopMatrix();
        }
    }
}