using UnityEngine;

namespace Unfair.Module.Modules.Player
{
	public class Noclip : Module
	{
		public Noclip() : base("Noclip", "Disables player collision", Category.Player, KeyCode.G)
		{
		}
		
		public override void OnUpdate()
		{
			PlayerController.LHFJFKJJKCG.ICCJNHOFBGO.enabled = false;
		}
		
		public override void OnDisable()
		{
			PlayerController.LHFJFKJJKCG.ICCJNHOFBGO.enabled = true;
		}
	}
}