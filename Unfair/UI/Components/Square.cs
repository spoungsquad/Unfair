using UnityEngine;
using UnityEngine.UI;

namespace Unfair.UI.Components
{
	public class Square : Menu.MenuComponent
	{
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
			
			// triangles
			vh.AddTriangle(0, 1, 2);
			vh.AddTriangle(2, 3, 0);
		}
	}
}