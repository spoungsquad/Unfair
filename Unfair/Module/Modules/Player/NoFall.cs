using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Player
{
    public class NoFall : Module
    {
        // Constructor
        public NoFall() : base("NoFall", "Remove fall damage", Category.Player, KeyCode.None)
        {
        }

        public override void OnDisable()
        {
            GameData.LocalPlayerHealth.SetProp("BBKGOMEJMPJ", true);
        }

        public override void OnUpdate()
        {
            GameData.LocalPlayerHealth.SetProp("BBKGOMEJMPJ", false);
        }
    }
}