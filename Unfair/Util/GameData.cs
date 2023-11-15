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
		public static PlayerController LocalPlayer => PlayerController.PAGMKIHEDAK;
		public static PlayerHealth LocalPlayerHealth => LocalPlayer.KIKIGFOCCEM;
		public static vThirdPersonController ThirdPersonController => LocalPlayer.GetField<vThirdPersonController>("_thirdPersonController");
		public static WeaponsController WeaponController => LocalPlayer.PBFKLLIHCOA;
		public static WeaponModel CurrentWeapon => WeaponController.CKDFKAJOAGF;
		public static WeaponBaseData CurrentWeaponData => CurrentWeapon.IGFOEIMJNML;
		
		// world stuff
		public static Pickupable[] Pickupables => Object.FindObjectsOfType<Pickupable>();
		public static SupplyCrate[] Crates => Object.FindObjectsOfType<SupplyCrate>();
		public static BuildingNetworkController BuildingNetworkController => BuildingNetworkController.Instance;
		public static Building[] Buildings => Object.FindObjectsOfType<Building>();
		public static string[] BuildingIDs => BuildingNetworkController
			.GetField<Dictionary<string, Building>>("GGNDPANCELF").Keys.ToArray();
		
		// misc i guess
		public static ModeInfo CurrentGameMode => PKHMDOCJGMA.OEFABDODDDO;
		public static ServerUser LocalProfile => FirebaseManager.ACMIJJJBFPF.BPNHJECLOGK;
		public static UiManager UIManager => UiManager.ACMIJJJBFPF;
		public static Camera MainCamera => CameraManager.ACMIJJJBFPF.MainCamera;
	}
}