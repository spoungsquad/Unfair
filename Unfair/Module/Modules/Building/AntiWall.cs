using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Building
{
    public class AntiWall : Module
    {
        public AntiWall() : base("AntiWall", "Removes all walls", Category.Building, KeyCode.Semicolon)
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
            foreach (global::Building building in GameData.Buildings)
            {
                building.OnDestroyReceived();
            }
        }
    }
}