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
            Enabled = false;
        }

        public override void OnEnable()
        {
            Func<PlayerController, bool> func = null;

            if (EOAHGMEBCEG.ADNFNKMBEMF.IsTeams)
            {
                func = (PlayerController player) => player.EEGHEEOAPPH == GameData.LocalPlayer.EEGHEEOAPPH;
            }
            else
            {
                func = (PlayerController player) => player.HIEGIIINGFL == GameData.LocalPlayer.HIEGIIINGFL;
            }

            List<int> list = (from playerController in PlayersManager.OJICDNBLPIC.EBMPBGPAGPL.Values.Where(func)
                              select playerController.HJAHHGHDJOC.HIEGIIINGFL).ToList();

            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
            GameManager.Instance.EndGame(false, false, list);

            this.Toggle();
        }
    }
}