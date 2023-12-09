using Photon.Pun;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Misc
{
    public class NameChanger : Module
    {
        // Random string to make the game think we're a real player

        private string name = "";
        private int updateTicks = 0;

        // Constructor
        public NameChanger() : base("NameChanger", "Change your name", Category.Misc, KeyCode.UpArrow)
        {
        }

        // Called when the module gets disabled
        public override void OnDisable()
        {
            GameData.LocalProfile.GeneralData.Nickname = name;
            GameData.UIManager.UpdateProfileInfo();
        }

        // Called when the module gets enabled
        public override void OnEnable()
        {
            name = GameData.LocalProfile.GeneralData.Nickname;
        }

        // Called every frame
        public override void OnUpdate()
        {
            /*updateTicks++;
            if (updateTicks < 5)
                return;
            updateTicks = 0;
            */
            var newName = "⛓⛓ discord.gg/W36ArNRb4Y ⛓⛓ Unfair on Top!!";//RandomString(8);

            PhotonNetwork.LocalPlayer.NickName = newName;
            GameData.LocalProfile.GeneralData.Nickname = newName;
            GameData.UIManager.UpdateProfileInfo();
        }
    }
}