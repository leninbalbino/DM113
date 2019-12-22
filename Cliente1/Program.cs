using System;
using System.Collections.Generic;
using System.Linq;
using Cliente1.ServicoEstoque;

namespace Cliente1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pressione ENTER quando o serviço for iniciado");
            Console.ReadLine();

            // Create a proxy object and connect to the service
            ServicoEstoqueClient proxy = new ServicoEstoqueClient("BasicHttpBinding_IServicoEstoque");

            // Test the operations in the service
            Console.WriteLine("CLIENTE 1");

            Console.WriteLine();
            Console.WriteLine("====================================");

            Console.WriteLine("1 - Adicionar um produto");
            String id = DateTime.Now.Second.ToString();
            Produto produto = new Produto()
            {
                NumeroProduto = "NOVO_" + id,
                NomeProduto = "Produto " + id,
                DescricaoProduto = "Este é o produto " + id,
                EstoqueProduto = DateTime.Now.Second
            };
            bool sucesso = proxy.IncluirProduto(produto);
            if (sucesso)
            {
                Console.WriteLine("Sucesso na inclusão!");
            }
            else
            {
                Console.WriteLine("Erro na inclusão!");
            }

            Console.WriteLine();
            Console.WriteLine("====================================");

            Console.WriteLine("2 - Remover produto 10");
            sucesso = proxy.RemoverProduto("10000");
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

            Console.WriteLine("3 - Listar todos produtos");
            List<Produto> produtos = proxy.ListarProdutos().ToList();
            foreach (Produto p in produtos)
            {
                Console.WriteLine("Número: {0}", p.NumeroProduto);
                Console.WriteLine("Nome: {0}", p.NomeProduto);
                Console.WriteLine("Descrição: {0}", p.DescricaoProduto);
                Console.WriteLine("Estoque: {0}", p.EstoqueProduto);
                Console.WriteLine();
            }
            
            Console.WriteLine("====================================");

            Console.WriteLine("4 - Ver todas as informações do produto 2");
            produto = proxy.VerProduto("2000");
            Console.WriteLine("Número: {0}", produto.NumeroProduto);
            Console.WriteLine("Nome: {0}", produto.NomeProduto);
            Console.WriteLine("Descrição: {0}", produto.DescricaoProduto);
            Console.WriteLine("Estoque: {0}", produto.EstoqueProduto);

            Console.WriteLine();
            Console.WriteLine("====================================");

            Console.WriteLine("5 - Adicionar 10 unidades para produto 2");
            sucesso = proxy.AdicionarEstoque("2000", 10);
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

            Console.WriteLine("6 - Verificar o estoque do produto 2");
            int estoque = proxy.ConsultarEstoque("2000");
            Console.WriteLine("Estoque do produto 2: {0}", estoque);

            Console.WriteLine();
            Console.WriteLine("====================================");

            Console.WriteLine("7 - Verificar estoque do produto 1");
            estoque = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Estoque do produto 1: {0}", estoque);

            Console.WriteLine();
            Console.WriteLine("====================================");

            Console.WriteLine("8 - Remover 20 unidades para o produto 1");
            sucesso = proxy.RemoverEstoque("1000", 20);
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

            Console.WriteLine("9 - Verificar o estoque do produto 1 novamente");
            estoque = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Estoque do produto 1: {0}", estoque);

            Console.WriteLine();
            Console.WriteLine("====================================");

            Console.WriteLine("10 - Ver todas a informações do produto 1");
            produto = proxy.VerProduto("1000");
            Console.WriteLine("Número: {0}", produto.NumeroProduto);
            Console.WriteLine("Nome: {0}", produto.NomeProduto);
            Console.WriteLine("Descrição: {0}", produto.DescricaoProduto);
            Console.WriteLine("Estoque: {0}", produto.EstoqueProduto);

            Console.WriteLine();
            Console.WriteLine("================END=================");

            // Disconnect from the service
            proxy.Close();
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
        }
    }
}
