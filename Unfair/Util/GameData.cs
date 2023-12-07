using System.Collections.Generic;
using System.Linq;
using Invector.CharacterController;
using JustPlay.Equipment;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Unfair.Util
{
    public static class GameData
    {
        private static Camera _cacheCamera = null;

        public static string[] BuildingIDs => BuildingNetworkController
                    .GetField<Dictionary<string, Building>>("GGNDPANCELF").Keys.ToArray();

        public static BuildingNetworkController BuildingNetworkController => BuildingNetworkController.Instance;

        public static Building[] Buildings => Object.FindObjectsOfType<Building>();

        public static SupplyCrate[] Crates => Object.FindObjectsOfType<SupplyCrate>();

        // misc i guess
        public static ModeInfo CurrentGameMode => PKHMDOCJGMA.OEFABDODDDO;

        public static WeaponModel CurrentWeapon => WeaponController.CKDFKAJOAGF;

        public static WeaponBaseData CurrentWeaponData => CurrentWeapon.IGFOEIMJNML;

        public static PlayerController LocalPlayer => PlayerController.PAGMKIHEDAK;

        public static PlayerHealth LocalPlayerHealth => LocalPlayer.KIKIGFOCCEM;

        public static ServerUser LocalProfile => FirebaseManager.ACMIJJJBFPF.BPNHJECLOGK;

        public static Camera MainCamera
        {
            get
            {
                return _cacheCamera ?? InitCamera(Camera.main);
            }
        }

        // world stuff
        public static Pickupable[] Pickupables => Object.FindObjectsOfType<Pickupable>();

        //TODO: Cache all FindObjectsOfType calls
        public static PlayerController[] PlayerControllers => Object.FindObjectsOfType<PlayerController>();

        public static vThirdPersonController ThirdPersonController => LocalPlayer.GetField<vThirdPersonController>("_thirdPersonController");

        public static UiManager UIManager => UiManager.ACMIJJJBFPF;

        public static WeaponsController WeaponController => LocalPlayer.PBFKLLIHCOA;

        public static Camera InitCamera(Camera newMain)
        {
            return _cacheCamera = newMain;
        }
    }
}