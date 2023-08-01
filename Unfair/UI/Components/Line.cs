using UnityEngine;
using UnityEngine.UI;

namespace Unfair.UI.Components
{
	public class Line : Menu.MenuComponent
	{
		public float thickness = 1;
		public Vector2 start;
		public Vector2 end;
		
		protected override void OnPopulateMesh(VertexHelper vh)
		{
			vh.Clear();
			
			AddVertsForPoint(start, vh);
			AddVertsForPoint(end, vh);
			
			vh.AddTriangle(0, 1, 3);
			vh.AddTriangle(3, 2, 0);
		}

		private void AddVertsForPoint(Vector2 p, VertexHelper vh)
		{
			var vert = UIVertex.simpleVert;
			vert.color = color;
			
			vert.position = new Vector2(-thickness / 2, 0);
			vert.position += new Vector3(p.x, p.y);
			vh.AddVert(vert);
			
			vert.position = new Vector2(thickness / 2, 0);
			vert.position += new Vector3(p.x, p.y);
			vh.AddVert(vert);
		}
	}
}