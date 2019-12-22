using Cliente2.ServicoEstoque;
using System;

namespace Cliente2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pressione ENTER quando o serviço for iniciado");
            Console.ReadLine();

            // Create a proxy object and connect to the service
            ServicoEstoqueV2Client proxy = new ServicoEstoqueV2Client("WS2007HttpBinding_IServicoEstoque");

            // Test the operations in the service
            Console.WriteLine("CLIENTE 2");

            Console.WriteLine();
            Console.WriteLine("====================================");

            Console.WriteLine("1 - Verificar estoque do produto 1");
            int estoque = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Estoque do produto 1: {0}", estoque);

            Console.WriteLine();
            Console.WriteLine("====================================");

            Console.WriteLine("2 - Adicionar 20 unidades para o produto 1");
            bool sucesso = proxy.AdicionarEstoque("1000", 20);
            if (sucesso)
            {
                Console.WriteLine("Sucesso na adição!");
            }
            else
            {
                Console.WriteLine("Erro na adição!");
            }

            Console.WriteLine();
            Console.WriteLine("====================================");

            Console.WriteLine("3 - Verificar estoque do produto 1 novamente");
            estoque = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Estoque do produto 1: {0}", estoque);

            Console.WriteLine();
            Console.WriteLine("====================================");

            Console.WriteLine("4 - Verificar estoque do produto 5");
            estoque = proxy.ConsultarEstoque("5000");
            Console.WriteLine("Estoque do produto 5: {0}", estoque);

            Console.WriteLine();
            Console.WriteLine("====================================");

            Console.WriteLine("5 - Remover 10 unidades do produto 5");
            sucesso = proxy.RemoverEstoque("5000", 10);
            if (sucesso)
            {
                Console.WriteLine("Sucesso na remoção!");
            }
            else
            {
                Console.WriteLine("Erro na remoção!");
            }

            Console.WriteLine();
            Console.WriteLine("====================================");

            Console.WriteLine("6 - Verificar estoque do produto 5 novamente");
            estoque = proxy.ConsultarEstoque("5000");
            Console.WriteLine("Estoque do produto 5: {0}", estoque);

            Console.WriteLine();
            Console.WriteLine("================END=================");

            // Disconnect from the service
            proxy.Close();
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
        }
    }
}
