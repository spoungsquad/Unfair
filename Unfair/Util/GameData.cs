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

        public static BuildingNetworkController BuildingNetworkController => BuildingNetworkController.Instance;

        public static Building[] Buildings => Object.FindObjectsOfType<Building>();

        public static SupplyCrate[] Crates => Object.FindObjectsOfType<SupplyCrate>();

        // misc i guess
        public static ModeInfo CurrentGameMode => EOAHGMEBCEG.PBDDBPPEHAL;

        public static WeaponModel CurrentWeapon => WeaponController.PIIMNHFPCBF;

        public static WeaponBaseData CurrentWeaponData => CurrentWeapon.EKDOLAIHPGP;

        public static PlayerController LocalPlayer => PlayerController.IKIFDINMMKC;

        public static PlayerHealth LocalPlayerHealth => LocalPlayer.MECEACOMEMD;

        public static ServerUser LocalProfile => FirebaseManager.OJICDNBLPIC.PKLGANDEHJB;

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

        public static vThirdPersonController ThirdPersonController => LocalPlayer.JCEELPIJOML;

        public static UiManager UIManager => UiManager.OJICDNBLPIC;

        public static WeaponsController WeaponController => LocalPlayer.FFFJCDBAEBO;

        public static CameraManager CameraManager => CameraManager.OJICDNBLPIC;

        public static Camera InitCamera(Camera newMain)
        {
            return _cacheCamera = newMain;
        }
    }
}