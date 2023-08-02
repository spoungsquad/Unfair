using UnityEngine;
using UnityEngine.UI;

namespace Unfair.UI.Components
{
	public class Panel : Menu.MenuComponent
	{
		public int outlineThickness = 1;
		public Color outlineColor = Color.black;
		
		protected override void OnPopulateMesh(VertexHelper vh)
		{
			vh.Clear();
			
			// i have to write vertices manually. my blood will be on the floor today
			var rect = rectTransform.rect;
			var w = rect.width;
			var h = rect.height;

			var vert = UIVertex.simpleVert;
			vert.color = color;
			
			vert.position = new Vector2(0, 0);
			vh.AddVert(vert);
			
			vert.position = new Vector2(0, h);
			vh.AddVert(vert);
			
			vert.position = new Vector2(w, h);
			vh.AddVert(vert);
			
			vert.position = new Vector2(w, 0);
			vh.AddVert(vert);
			
			// add some triangles
			vh.AddTriangle(0, 1, 2);
			vh.AddTriangle(2, 3, 0);
			
			// outline
			var distance = Mathf.Sqrt(outlineThickness * outlineThickness / 2);
			
			vert.color = outlineColor;
			
			vert.position = new Vector2(distance, distance);
			vh.AddVert(vert);
			
			vert.position = new Vector2(distance, h - distance);
			vh.AddVert(vert);
			
			vert.position = new Vector2(w - distance, h - distance);
			vh.AddVert(vert);
			
			vert.position = new Vector2(w - distance, distance);
			vh.AddVert(vert);
			
			// and finally, triangle hell
			// vh.AddTriangle(0, 1, 5);
			// vh.AddTriangle(5, 4, 0);
			//
			// vh.AddTriangle(1, 2, 6);
			// vh.AddTriangle(6, 5, 1);
			//
			// vh.AddTriangle(2, 3, 7);
			// vh.AddTriangle(7, 6, 2);
			//
			// vh.AddTriangle(3, 0, 4);
			// vh.AddTriangle(4, 7, 3);
			
			// offset the above by 4 cuz i messed it up
			vh.AddTriangle(4, 5, 9);
			vh.AddTriangle(9, 8, 4);
			
			vh.AddTriangle(5, 6, 10);
			vh.AddTriangle(10, 9, 5);
			
			vh.AddTriangle(6, 7, 11);
			vh.AddTriangle(11, 10, 6);
			
			vh.AddTriangle(7, 4, 8);
			vh.AddTriangle(8, 11, 7);
		}
	}
}