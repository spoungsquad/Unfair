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

        public static CameraManager CameraManager => CameraManager.LIPLNDMKLDB;
        public static SupplyCrate[] Crates => Object.FindObjectsOfType<SupplyCrate>();

        // misc i guess
        public static ModeInfo CurrentGameMode => GGGKABIJIFJ.OJINMONIHIE;

        public static WeaponModel CurrentWeapon => WeaponController.MMFGMHOCMEP;

        public static WeaponBaseData CurrentWeaponData => CurrentWeapon.IIPJDHGLFKA;

        public static PlayerController LocalPlayer => PlayerController.HGPJOFAPIBH;

        public static PlayerHealth LocalPlayerHealth => LocalPlayer.PAEKEKFLHOK;

        public static ServerUser LocalProfile => FirebaseManager.LIPLNDMKLDB.IPGFHABIDAC;

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

        public static vThirdPersonController ThirdPersonController => LocalPlayer.OEGGIHFLNAN;

        public static UiManager UIManager => UiManager.LIPLNDMKLDB;

        public static WeaponsController WeaponController => LocalPlayer.CIMFGBELHOH;

        public static Camera InitCamera(Camera newMain)
        {
            return _cacheCamera = newMain;
        }
    }
}