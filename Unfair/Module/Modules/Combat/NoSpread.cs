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
            PlayerController.LHFJFKJJKCG.NLJCMEMPBLA.GBNMBOFAHAA.CFIBMJEFJFA.Stats.StatsForLevel.SpreadSettings.AimingSpread = 0;
            PlayerController.LHFJFKJJKCG.NLJCMEMPBLA.GBNMBOFAHAA.CFIBMJEFJFA.Stats.StatsForLevel.SpreadSettings.SpreadOutTime = 0;
            PlayerController.LHFJFKJJKCG.NLJCMEMPBLA.GBNMBOFAHAA.CFIBMJEFJFA.Stats.StatsForLevel.SpreadSettings.DefaultSpread = 0;
            PlayerController.LHFJFKJJKCG.NLJCMEMPBLA.GBNMBOFAHAA.CFIBMJEFJFA.Stats.StatsForLevel.SpreadSettings.IncreasePerShot = 0;
        }
    }
}