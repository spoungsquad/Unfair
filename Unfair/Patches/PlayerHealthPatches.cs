using HarmonyLib;

namespace Unfair.Patches
{
	[HarmonyPatch(typeof(PlayerHealth))]
	public class PlayerHealthPatches
	{
		[HarmonyPrefix]
		[HarmonyPatch("Die")]
		private static bool Prefix()
		{
			// skip original method
			return false;
		}
	}
}