using Unfair.UI;
using Unfair.Util;
using UnityEngine;
using UnityEngine.UI;

namespace Unfair.Module.Modules.Visual
{
	public class TestMenu : Module
	{
		private Menu _menu;
		
		public TestMenu() : base("TestMenu", "TestMenu", Category.Visuals, KeyCode.Insert)
		{
			_menu = new Menu { Enabled = false };

			var text = _menu.AddComponent<Text>();
			text.text = "HELLO CAN YOU SEE THIS";
			text.font = GUIStyle.none.font;
			text.fontSize = 72;
			text.color = Color.red;
			text.rectTransform.anchoredPosition = new Vector2(0, 0);
		}

		public override void OnEnable() => _menu.Enabled = true;
		public override void OnDisable() => _menu.Enabled = false;

		public override void OnGUI()
		{
			_menu.DebugRender();
			
			Render.DrawBox(0, 0, 150, 500, new Color(0, 255, 0, 0.5f));
		}
	}
}