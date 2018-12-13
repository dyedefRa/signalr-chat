using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR_chatUygulamasi.Hubs
{
    [HubName("chaty")]
    public class ChatHub : Hub
    {
        public void hubaGonder(string name,string mesaj)
        {
            var deger = $"{name} :  {mesaj}";
            //Clients.All.hubtanAl(deger);
            //Her client için ; hubtanAl ve hubtanKendineAl atlı metodlarının var. Other dedıdıgımızde kendi clientimize tetıkledıgımız o metodu basmıyor.
            //Aynı sekılde Caller dedıgımızde ıse sadece buraya Metoda dusmemıze yarayan client için basıyor.Js dosyasında sadece Caller clientindaki hubtanKendineAl metodunu tetıkleniyor.
            Clients.Others.hubtanAl(deger);
            Clients.Caller.hubtanKendineAl(mesaj);
            //Burdaki IDyi databaseden cektıgımızı dusun --------

            //string id = Context.ConnectionId;
            //Clients.Client(id);
            //Clients.User("Userların var databaseden idyi alıp yapabılıyosun.").asfasf("bu metodu jsten alcaz");
        }
        public override Task OnConnected()
        {
            //string id = Context.ConnectionId;
            //ConnectionIdyi aldık. İSter sql ye  yaz istedıgını yapabılırısn.Burada id yi databaseye yazdık
            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }
    }
}