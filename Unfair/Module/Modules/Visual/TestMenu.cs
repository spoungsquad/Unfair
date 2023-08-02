using Unfair.UI;
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
		}

		public override void OnEnable() => _menu.Enabled = true;
		public override void OnDisable() => _menu.Enabled = false;

		public override void OnGUI()
		{
			_menu.DebugRender();
		}
	}
}