using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class NoRecoil : Module
    {
        public NoRecoil() : base("NoRecoil", "Removes recoil from your current weapon", Category.Combat, KeyCode.L)
        {
            Enabled = true;
        }
        
        public override void OnUpdate()
        {
            PlayerController.LHFJFKJJKCG.NLJCMEMPBLA.GBNMBOFAHAA.CFIBMJEFJFA.Stats.StatsForLevel.RecoilForce = 0;
            PlayerController.LHFJFKJJKCG.NLJCMEMPBLA.GBNMBOFAHAA.CFIBMJEFJFA.Stats.StatsForLevel.RecoilDuration = 0;
            PlayerController.LHFJFKJJKCG.NLJCMEMPBLA.GBNMBOFAHAA.CFIBMJEFJFA.Stats.StatsForLevel.DamageSettings.DamageToBuildings = 1000;
            PlayerController.LHFJFKJJKCG.NLJCMEMPBLA.GBNMBOFAHAA.CFIBMJEFJFA.Stats.StatsForLevel.DamageSettings.DamageToPlayers = 1000;
        }
    }
}