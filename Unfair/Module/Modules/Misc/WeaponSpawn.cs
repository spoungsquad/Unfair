using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Misc
{
    internal class WeaponSpawn : Module
    {
        private readonly List<PlayerController> _players = new List<PlayerController>();

        public WeaponSpawn() : base("WeaponSpawn", "Spawn a shit ton of weapons", Category.Misc, KeyCode.M)
        {
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