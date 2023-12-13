using Photon.Pun;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Misc
{
    public class NameChanger : Module
    {
        private string _oldName = "";
        private string _scrollingText = "Unfair on Top!! "; // space is intentional
        private int _updateTicks;

        // Constructor
        public NameChanger() : base("NameChanger", "Change your name", Category.Misc, KeyCode.UpArrow)
        {
        }

        // Called when the module gets disabled
        public override void OnDisable()
        {
            GameData.LocalProfile.GeneralData.Nickname = _oldName;
            GameData.UIManager.UpdateProfileInfo();
        }

        public override void OnEnable()
        {
            _oldName = GameData.LocalProfile.GeneralData.Nickname;
        }

        public override void OnUpdate()
        {
            _updateTicks++;
            if (_updateTicks < 10)
                return;
            _updateTicks = 0;
            
            var lastChar = _scrollingText[_scrollingText.Length - 1];
            _scrollingText = _scrollingText.Remove(_scrollingText.Length - 1);
            _scrollingText = lastChar + _scrollingText;

            PhotonNetwork.LocalPlayer.NickName = _scrollingText;
            GameData.LocalProfile.GeneralData.Nickname = _scrollingText;
            GameData.UIManager.UpdateProfileInfo();
        }
    }
}