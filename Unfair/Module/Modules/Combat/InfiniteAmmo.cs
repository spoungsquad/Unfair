using UnityEngine;

namespace Unfair.Module.Modules.Combat
{
    public class InfiniteAmmo : Module
    {
        public InfiniteAmmo() : base("InfiniteAmmo", "Infinite ammo", Category.Combat, KeyCode.L)
        {
            Enabled = true;
        }

        public override void OnUpdate()
        {
            PlayerController.LHFJFKJJKCG.NLJCMEMPBLA.GBNMBOFAHAA.SetCurrentMagazineAmount(10000);
        }
    }
}