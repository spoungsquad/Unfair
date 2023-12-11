using Photon.Pun;
using UnityEngine;

namespace Unfair.Module.Modules.Misc
{
    public class NewHost : Module
    {
        NewHost() : base("NewHost", "Makes you the host", Category.Misc, KeyCode.None)
        {
        }
        
        public override void OnUpdate()
        {
            if (PhotonNetwork.IsMasterClient)
                return;
            
            PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
        }
    }
}