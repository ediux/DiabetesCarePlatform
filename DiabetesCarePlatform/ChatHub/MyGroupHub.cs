using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalRChat
{
    [HubName("GroupChatHub")]
    public class MyGroupHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        [HubMethodName("broadCastUser")]
        public void BroadCastMessage(String action, String msg, String userId, String datetime)
        {
            var id = Context.ConnectionId;
            string[] Exceptional = new string[0];
            Clients.Group(userId, Exceptional).receiveMessage(action, msg, "", datetime);
            ///Clients.All.receiveMessage(msgFrom, msg, "");
            /*string[] Exceptional = new string[1];
            Exceptional[0] = id;       
            Clients.AllExcept(Exceptional).receiveMessage(msgFrom, msg);*/
        }

        [HubMethodName("groupconnect")]
        public void Get_Connect(String userId)
        {
            //string count = "NA";
            //string msg = "Welcome to group "+GroupName;
            //string list = "";
           
            var id = Context.ConnectionId;
            Groups.Add(id, userId);

            //string[] Exceptional = new string[1];
            //Exceptional[0] = id;

            //Clients.Caller.receiveMessage("Group Chat Hub", msg, list);
            //Clients.OthersInGroup(GroupName).receiveMessage("NewConnection", GroupName+" "+username + " " + id, count);
            //Clients.AllExcept(Exceptional).receiveMessage("NewConnection", username + " " + id, count);
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            //string username = Context.QueryString["username"].ToString();
            //string clientId = Context.ConnectionId;
            //string data = clientId;
            //string count = "NA";
            //Clients.Caller.receiveMessage("ChatHub", data, count);
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnReconnected()
        {
            return base.OnReconnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            //string count = "NA";
            //string msg = "";

            //string clientId = Context.ConnectionId;
            //string[] Exceptional = new string[1];
            //Exceptional[0] = clientId;
            //Clients.AllExcept(Exceptional).receiveMessage("NewConnection", clientId + " leave", count);

            return base.OnDisconnected(stopCalled);
        }
    }
}