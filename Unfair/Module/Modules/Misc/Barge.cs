using System;
using System.Linq;
using Assets.Scripts.Network;
using Photon.Pun;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Misc
{
    public class Barge : Module
    {
        public Barge() : base("Barge", "Force join party", Category.Misc, KeyCode.End)
        {
        }
        
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

                FriendsManager.Instance.SendFriendInvite(x.UserId);
                FriendsManager.Instance.AcceptInvite(x.UserId);
                DebugConsole.Write("Added friend");
                
                FirebaseManager.OJICDNBLPIC.PKLGANDEHJB.Friends.Friends.Add(new FriendEntry(x.UserId));
                
                FriendsManager.Instance.FetchFriendsData();
                PhotonChatManager.OJICDNBLPIC.AddFriends(x.UserId);
                PhotonChatManager.OJICDNBLPIC.SendPrivateMessage(x.UserId, new PhotonChatMessage(LEMFLKDJENG.FriendInviteAccept));
                
                Connector.OJICDNBLPIC.EnterParty(x.Party);
            });
        }
    }
}