using UnityEngine;

namespace Unfair.Module.Modules.Movement
{
    public class VClip : Module
    {
        public VClip() : base("VClip", "Allows you to clip through blocks", Category.Movement, KeyCode.DownArrow)
        {
        }

        public override void OnEnable()
        {
            PlayerController.LHFJFKJJKCG.gameObject.transform.position = new Vector3(PlayerController.LHFJFKJJKCG.transform.position.x, PlayerController.LHFJFKJJKCG.transform.position.y - 5, PlayerController.LHFJFKJJKCG.transform.position.z);
            this.Enabled = false;
            OnDisable();
        }
    }
}