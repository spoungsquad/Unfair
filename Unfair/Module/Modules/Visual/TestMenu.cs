using Unfair.UI;
using Unfair.UI.Components;
using UnityEngine;

namespace Unfair.Module.Modules.Visual
{
	public class TestMenu : Module
	{
		private Menu _menu;
		
		public TestMenu() : base("TestMenu", "TestMenu", Category.Visuals, KeyCode.Insert)
		{
			_menu = new Menu();

			var panel = _menu.Add<Panel>();
			panel.color = new Color(0, 0, 0, 0.5f);
			panel.rectTransform.sizeDelta = new Vector2(200, 200);
			panel.rectTransform.anchoredPosition = new Vector2(100, 100);
			panel.outlineColor = Color.white;
			panel.outlineThickness = 5;
			
			var line = _menu.Add<Line>();
			line.color = Color.white;
			line.start = new Vector2(100, 100);
			line.end = new Vector2(300, 300);
		}

		public override void OnEnable() => _menu.Toggle();
		public override void OnDisable() => _menu.Toggle();
	}
}