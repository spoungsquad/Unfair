using Assets.Scripts;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Misc
{
    internal class ForceWin : Module
    {
        public ForceWin() : base("ForceWin", "Force a win", Category.Misc, KeyCode.Keypad0)
        {
        }

        public override void OnEnable()
        {
            Func<PlayerController, bool> func = null;

            if (GGGKABIJIFJ.OJINMONIHIE.IsTeams)
            {
                func = (PlayerController player) => player.JNGLPAJKPEI == GameData.LocalPlayer.JNGLPAJKPEI;
            }
            else
            {
                func = (PlayerController player) => player.IFJDJGLJHGD == GameData.LocalPlayer.IFJDJGLJHGD;
            }

            List<int> list = (from playerController in PlayersManager.LIPLNDMKLDB.HPICKALGINH.Values.Where(func)
                              select playerController.PBIJHIGLJEM.IFJDJGLJHGD).ToList();

            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
            GameManager.Instance.EndGame(false, false, list);

            this.Toggle();
        }
    }
}