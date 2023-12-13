using Unfair.Attributes;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Building
{
    // not sure what this is for when Breakdown exists so
    [DebugOnly]
    public class AntiWall : Module
    {
        public AntiWall() : base("AntiWall", "Remove all walls", Category.Building, KeyCode.Semicolon)
        {
        }
        
        public override void OnUpdate()
        {
            foreach (var building in GameData.Buildings)
            {
                building.OnDestroyReceived();
            }
        }
    }
}