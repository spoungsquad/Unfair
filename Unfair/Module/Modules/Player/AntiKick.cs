using Photon.Pun;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Player
{
    public class AntiKick : Module
    {
        private string _oldUserId;

        public AntiKick() : base("AntiKick", "Prevents you from being kicked", Category.Player, KeyCode.F7)
        {
            Toggle();
        }

        public override void OnDisable()
        {
            PhotonNetwork.LocalPlayer.SetProp("UserId", _oldUserId);
        }

        public override void OnEnable()
        {
            _oldUserId = PhotonNetwork.LocalPlayer.UserId;
        }

        public override void OnUpdate()
        {
            PhotonNetwork.LocalPlayer.SetProp("UserId", RandomString(8));
        }
    }
}