using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Movement
{
    public class Fly : Module
    {
        // Constructor
        public Fly() : base("Fly", "Allows you to fly around the map", Category.Movement, KeyCode.G)
        {
        }
        
        public override void OnEnable()
        {
            GameData.LocalPlayer.SetGodMode(true);
        }
        
        public override void OnDisable()
        {
            GameData.LocalPlayer.SetGodMode(false);
        }
    }
}