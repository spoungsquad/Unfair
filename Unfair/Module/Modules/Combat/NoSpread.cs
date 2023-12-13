using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class NoSpread : Module
    {
        public NoSpread() : base("NoSpread", "Removes spread", Category.Combat, KeyCode.L)
        {
            Enabled = true;
        }

        public override void OnUpdate()
        {
            var crosshair = HudManager.Instance.currentCrosshair.GetField<RectTransform>("_crosshair");
            
            crosshair.sizeDelta = Vector2.zero;
            HudManager.Instance.currentCrosshair.SetField("_minSpread", 0f);
        }
    }
}