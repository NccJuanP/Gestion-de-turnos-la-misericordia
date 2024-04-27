using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace TuProyecto.Hubs
{
    public class ChatHub : Hub
    {
        public async Task EnviarMensaje(string usuario, string mensaje)
        {
            await Clients.All.SendAsync("NuevoMensaje", usuario, mensaje);
        }
    }
}