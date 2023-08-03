using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Misc
{
    public class AntiWall : Module
    {
        public AntiWall() : base("Anti-wall", "Removes walls lol", Category.Misc, KeyCode.Semicolon)
        {
        }
        
        public override void OnGUI()
        {
            GUI.Label(new Rect(50, 500, 1000, 20), "hello hi");
            if (GameData.Buildings.Length == 0)
            {
                GUI.Label(new Rect(50, 400, 1000, 20), "No buildings found");
            }
            else
            {
                GUI.Label(new Rect(50, 400, 1000, 20), "buildings found " + GameData.Buildings.Length);
            }
            foreach (Building building in GameData.Buildings)
            {
                building.OnDestroyReceived();
            }
        }
    }
}