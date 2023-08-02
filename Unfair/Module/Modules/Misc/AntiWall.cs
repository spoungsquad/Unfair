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
            Building[] buildings = Object.FindObjectsOfType<Building>();
            if (buildings.Length == 0)
            {
                GUI.Label(new Rect(50, 400, 1000, 20), "No buildings found");
            }
            else
            {
                GUI.Label(new Rect(50, 400, 1000, 20), "buildings found " + buildings.Length);
            }
            foreach (Building building in buildings)
            {
                building.OnDestroyReceived();
            }
        }
    }
}