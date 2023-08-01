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
			PlayerController.LHFJFKJJKCG.NPPCBODBJDN._capsuleCollider.enabled = false;
		}
		
		public override void OnDisable()
		{
			PlayerController.LHFJFKJJKCG.NPPCBODBJDN._capsuleCollider.enabled = true;
		}
	}
}