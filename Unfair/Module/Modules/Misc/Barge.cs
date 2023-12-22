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

                FirebaseManager.LIPLNDMKLDB.IPGFHABIDAC.Friends.Friends.Add(new FriendEntry(x.UserId));

                FriendsManager.Instance.FetchFriendsData();
                PhotonChatManager.LIPLNDMKLDB.AddFriends(x.UserId);
                PhotonChatManager.LIPLNDMKLDB.SendPrivateMessage(x.UserId, new PhotonChatMessage(EHHMLNMNHPO.FriendInviteAccept));

                Connector.LIPLNDMKLDB.EnterParty(x.Party);
            });
        }
    }
}