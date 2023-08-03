using Photon.Pun;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Player
{
	public class AntiKick : Module
	{
		private string _oldUserId;
		
		public AntiKick() : base("AntiKick", "Prevents you from being kicked", Category.Player, KeyCode.F13)
		{
			Enabled = true;
		}

		public override void OnEnable()
		{
			_oldUserId = PhotonNetwork.LocalPlayer.UserId;
			PhotonNetwork.LocalPlayer.SetProp("UserId", "Unfair");
		}

		public override void OnDisable()
		{
			PhotonNetwork.LocalPlayer.SetProp("UserId", _oldUserId);
		}
	}
}