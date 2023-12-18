using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unfair.Config.Settings;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Misc
{
    internal class WeaponSpawn : Module
    {
        private enum SpawnLocation
        {
            Everyone,
            Closest,
            Self
        }
        
        // TODO: better
        private TextSetting _weaponName 
            = new TextSetting("Weapon name", "The name of the weapon to spawn", "M4A1");
        
        private NumberSetting _amount 
            = new NumberSetting("Amount", "How many weapons to spawn per location", 10f, 1f, 100f);
        
        private ModeSetting _spawnLocation 
            = new ModeSetting("Spawn location", "Where to spawn the weapons", Enum.GetNames(typeof(SpawnLocation)), (int)SpawnLocation.Everyone);
        
        private readonly List<PlayerController> _players = new List<PlayerController>();

        public WeaponSpawn() : base("WeaponSpawn", "Spawn a shit ton of weapons", Category.Misc, KeyCode.M)
        {
            Settings.Add(_weaponName);
            Settings.Add(_amount);
            Settings.Add(_spawnLocation);
        }

        public override void OnEnable()
        {
            _players.Clear();
            _players.AddRange(GameData.PlayerControllers);
        }

        public override void OnUpdate()
        {
            var localPlayer = GameData.LocalPlayer;
            if (localPlayer == null)
                return;

            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);

            foreach (var player in _players)
            {
                if (player is null || player.IsMine())
                    continue;

                Vector3 vector = player.FHAOJNEKKGD + player.transform.up;
                PickupableSpawner.CreateWeaponDrop(GameData.CurrentWeaponData.Id, vector);
            }
        }
    }
}