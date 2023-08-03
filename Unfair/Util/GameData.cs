using System.Collections.Generic;
using System.Linq;
using Invector.CharacterController;
using JustPlay.Equipment;
using UnityEngine;

namespace Unfair.Util
{
	public static class GameData
	{
		// player related things
		public static PlayerController[] PlayerControllers => Object.FindObjectsOfType<PlayerController>();
		public static PlayerController LocalPlayer => PlayerController.JPIGHMOLDBI;
		public static PlayerHealth LocalPlayerHealth => LocalPlayer.LBFGDDPCNOJ;
		public static vThirdPersonController ThirdPersonController => LocalPlayer.GetField<vThirdPersonController>("_thirdPersonController");
		public static WeaponsController WeaponController => LocalPlayer.OFGEHBLDKHD;
		public static WeaponModel CurrentWeapon => WeaponController.KOBBJGHNHKE;
		public static WeaponBaseData CurrentWeaponData => CurrentWeapon.MCPIPFAKLFJ;
		
		// world stuff
		public static Pickupable[] Pickupables => Object.FindObjectsOfType<Pickupable>();
		public static SupplyCrate[] Crates => Object.FindObjectsOfType<SupplyCrate>();
		public static BuildingNetworkController BuildingNetworkController => BuildingNetworkController.Instance;
		public static Building[] Buildings => Object.FindObjectsOfType<Building>();
		public static string[] BuildingIDs => BuildingNetworkController
			.GetField<Dictionary<string, Building>>("FBCJOFJMLJA").Keys.ToArray();
		
		// misc i guess
		public static ModeInfo CurrentGameMode => DKEJFHJHCJN.CMIPDLBPIFK;
		public static ServerUser LocalProfile => FirebaseManager.Instance.JLPGEKNJLMG;
		public static UiManager UIManager => UiManager.IPAJKCLGNJF;
	}
}