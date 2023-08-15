using Microsoft.AspNetCore.SignalR;

namespace TicTacToeSignalR.API.Hubs
{
    public class GameHub : Hub
    {
        public async Task SelectSquare(string gameId, int selectedSquare, int move)
        {
            try
            {
                await Clients.Group(gameId).SendAsync("SelectedSquare", selectedSquare, move);
                Console.WriteLine($"Se selecciono el {selectedSquare} cuadrado en el movimiento {move}.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
        }

        public async Task Join(string gameId, string player)
        {
            try
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, gameId);
                await Clients.Group(gameId).SendAsync("join", player);
                Console.WriteLine($"El jugador {player} se unio");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
        }
    }
}
