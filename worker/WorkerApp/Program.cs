using System;
using StackExchange.Redis;

class Program
{
    static void Main(string[] args)
    {
        // Conectar a Redis
        var redis = ConnectionMultiplexer.Connect("redis:6379");
        var db = redis.GetDatabase();

        Console.WriteLine("Worker listening for votes...");

        // Bucle infinito para procesar tareas de Redis
        while (true)
        {
            // Leer un voto de la lista de Redis
            var vote = db.ListLeftPop("votes");
            if (!vote.IsNull)
            {
                Console.WriteLine($"Processing vote: {vote}");
                // Aquí puedes agregar la lógica para procesar el voto
            }

            // Esperar un segundo antes de verificar nuevamente
            System.Threading.Thread.Sleep(1000);
        }
    }
}
