using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class NoSpread : Module
    {
        public NoSpread() : base("NoSpread", "Remove spread", Category.Combat, KeyCode.L)
        {
            
        }

        public override void OnUpdate()
        {
            if (HudManager.Instance == null || HudManager.Instance.currentCrosshair == null) return;
            var crosshair = HudManager.Instance.currentCrosshair.GetField<RectTransform>("_crosshair");
            
            crosshair.sizeDelta = Vector2.zero;
            HudManager.Instance.currentCrosshair.SetField("_minSpread", 0f);
        }
    }
}