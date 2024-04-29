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

        public async Task ConstruirEspera(int preferencia, string turno, DateTime tiempo , string nombre, string tipoDocumento, int numDocumento, int attentionId, int employeeId, int userId){
            TimeSpan diferencia = DateTime.Now - tiempo;
                int minutos = (int)diferencia.TotalMinutes;
            await Clients.All.SendAsync("NuevoEspera", preferencia,  turno, minutos,  nombre,  tipoDocumento,  numDocumento, attentionId, employeeId, userId);
        }
    }
}
