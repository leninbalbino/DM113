using System;
using System.ServiceModel;
using EstoqueLibrary;

namespace ProvedorEstoqueHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost productsServiceHost = new ServiceHost(typeof(ServicoEstoque));
            productsServiceHost.Open();
            Console.WriteLine("Service Running");
            Console.ReadLine();
            Console.WriteLine("Service Stopping");
            productsServiceHost.Close();
        }
    }
}
