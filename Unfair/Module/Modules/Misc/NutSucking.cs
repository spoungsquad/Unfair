using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Misc
{
    public class NutSucking : Module
    {
        public NutSucking() : base("NutSucking", "Removes walls lol", Category.Misc, KeyCode.Comma)
        {
        }
        
        public override void OnGUI()
        {
            FirebaseManager[] buildings = Object.FindObjectsOfType<FirebaseManager>();
            if (buildings.Length == 0)
            {
                GUI.Label(new Rect(50, 400, 1000, 20), "No buildings found");
            }
            else
            {
                GUI.Label(new Rect(50, 400, 1000, 20), "buildings found " + buildings.Length);
            }
            foreach (FirebaseManager building in buildings)
            {
                building.GetField<ServerUser>("BDALMNICAAH").Nickname = "THIS USERNAME IS VERY LEGIT, I AM NOT CHEATING AT ALL NO SIRREE BOB";
            }
        }
    }
}