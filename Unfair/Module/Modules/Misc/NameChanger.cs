using Assets.Scripts.Network;
using Photon.Pun;
using Unfair.Config.Settings;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Misc
{
    public class NameChanger : Module
    {
        private enum NameAnimation
        {
            Scrolling,
            Buildup,
            Static
        }
        
        private TextSetting _name 
            = new TextSetting("Name", "The name to change to", "Unfair on Top!!");
        
        private ModeSetting<NameAnimation> _animationMode 
            = new ModeSetting<NameAnimation>("Animation mode", "How the name should be animated", NameAnimation.Scrolling);
        
        private NumberSetting _animationSpeed = new NumberSetting("Animation speed",
            "How fast the name should be animated, in milliseconds between each update", 100, 0, 1000);
        
        private string _oldName = "";
        private string _scrollingText = "Unfair on Top!! "; // space is intentional
        private int _updateTicks;

        // Constructor
        public NameChanger() : base("NameChanger", "Change your name", Category.Misc, KeyCode.UpArrow)
        {
            Settings.Add(_name);
            Settings.Add(_animationMode);
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
            GameData.Connector.OnPlayerDataChanged();
        }
    }
}