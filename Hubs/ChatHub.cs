using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Misericordia.Hubs
{
    public class ChatHub : Hub
    {
        public async Task EnviarMensaje(string usuario, string mensaje)
        {
            await Clients.All.SendAsync("NuevoMensaje", usuario, mensaje);
        }

        public async Task Limpiar(string id)
        {
            await Clients.All.SendAsync("Limpiar", id);
        }
    }
}
