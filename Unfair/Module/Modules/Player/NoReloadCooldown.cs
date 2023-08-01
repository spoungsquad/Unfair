using UnityEngine;

namespace Unfair.Module.Modules.Player
{
	public class NoReloadCooldown : Module
	{
		public NoReloadCooldown() : base("NoReloadCooldown", "Removes the reload cooldown", Category.Player, KeyCode.X)
		{
		}
		
		public override void OnUpdate()
		{
			var weapons = PlayerController.LHFJFKJJKCG.NLJCMEMPBLA;
			var currentWeapon = weapons.GBNMBOFAHAA;
			var stats = currentWeapon.ACJHMFJNJML;
			stats.StatsForLevel.AmmoSettings.ReloadTime = 0;
		}
	}
}