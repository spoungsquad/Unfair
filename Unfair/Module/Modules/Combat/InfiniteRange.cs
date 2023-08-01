using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class InfiniteRange : Module
    {
        public InfiniteRange() : base("InfiniteRange", "Infinite range", Category.Combat, KeyCode.L)
        {
            Enabled = true;
        }
        
        public override void OnUpdate()
        {
            PlayerController.LHFJFKJJKCG.NLJCMEMPBLA.GBNMBOFAHAA.CFIBMJEFJFA.Stats.Range = 1000000;
        }
    }
}