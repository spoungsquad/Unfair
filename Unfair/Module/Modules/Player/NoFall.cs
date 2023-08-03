using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Player
{
    public class NoFall : Module
    {
        // Constructor
        public NoFall() : base("NoFall", "No fall damage", Category.Player, KeyCode.None)
        {
        }
        
        public override void OnUpdate()
        {
            GameData.LocalPlayerHealth.SetFallDamageEnabled(true);
        }
        
        public override void OnDisable()
        {
            GameData.LocalPlayerHealth.SetFallDamageEnabled(false);
        }
    }
}