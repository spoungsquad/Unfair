using HarmonyLib;

namespace Unfair.Patches
{
	public class PlayerHealthPatches
	{
		[HarmonyPatch(typeof(PlayerHealth), nameof(PlayerHealth.Die))]
		public class Die
		{
			// return false to skip original method
			private static bool Prefix()
			{
				return false;
			}
		}
	}
}