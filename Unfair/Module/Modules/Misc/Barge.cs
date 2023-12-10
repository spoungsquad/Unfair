using System.Linq;
using Assets.Scripts.Network;
using Photon.Pun;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Misc
{
    public class Barge: Module
    {

        // Constructor
        public Barge() : base("Barge", "Allows you to invite yourself to a players game", Category.Misc, KeyCode.End)
        {
        }

        
        
        
        // Called every frame
        public override void OnEnable()
        {
            
            int i = 0;
            
                //FirebaseManager.OJICDNBLPIC.PKLGANDEHJB.Friends.Friends
            
            PhotonNetwork.PlayerList.ToList().ForEach(x =>
            {
                DebugConsole.Write(x.Party);
                
                
                if (x.Party == null)
                {
                    DebugConsole.Write("Party is null");
                    return;
                }
                DebugConsole.Write(x.NickName);
                
                
                
                Connector.OJICDNBLPIC.EnterParty(x.Party);

            });
        }
    }
}