using BrunoDPO.WCF.Contratos.Interfaces;
using System;
using System.ServiceModel;

namespace BrunoDPO.WCF.Servidor.Host
{
    static class Program
    {
        private const string PROTOCOLO = "net.tcp";
        private const string ENDERECO_BASE = "localhost";
        private const int PORTA = 8_000;

        static void Main(string[] args)
        {
            var baseAddress = new Uri($"{PROTOCOLO}://{ENDERECO_BASE}:{PORTA}");

            var simuladorServidor = new SimuladorServidor();
            var selfHost = new ServiceHost(simuladorServidor, baseAddress);
            try
            {
                selfHost.AddServiceEndpoint(typeof(IServidor), new NetTcpBinding(SecurityMode.None, true), baseAddress);

                selfHost.Open();
                Console.WriteLine("Simulador do Servidor iniciado.");
                Console.WriteLine();

                Console.WriteLine("Ouvindo em:");
                foreach (var address in selfHost.Description.Endpoints)
                {
                    Console.WriteLine($"-> {address.Address.Uri}");
                }
                Console.WriteLine();

                Console.WriteLine("Pressione qualquer tecla para finalizar.");
                Console.ReadKey();
                Console.WriteLine("Servidor está finalizando...");
                simuladorServidor.FinalizarServidor();
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine($"Exceção no servidor: {ce.Message}");
                selfHost.Abort();
            }
            Console.WriteLine("Servidor finalizado");
        }
    }
}
