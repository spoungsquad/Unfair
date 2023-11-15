using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Misc
{
    public class NameChanger : Module
    {
        // Random string to make the game think we're a real player
        private string _randomString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private string name = "";

        // Constructor
        public NameChanger() : base("NameChanger", "Change your name", Category.Misc, KeyCode.N)
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
            GameData.LocalProfile.GeneralData.Nickname = RandomString(10);
            GameData.UIManager.UpdateProfileInfo();
        }

        public string RandomString(int length)
        {
            string str = "";
            for (int i = 0; i < length; i++)
            {
                str += _randomString[Random.Range(0, _randomString.Length)];
            }
            return str;
        }
    }
}