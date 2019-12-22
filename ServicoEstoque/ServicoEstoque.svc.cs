using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using EstoqueEntityModel;

namespace EstoqueLibrary
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServicoEstoque : IServicoEstoque, IServicoEstoqueV2
    {
        public bool AdicionarEstoque(string numeroProduto, int quantidade)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = database.Estoque.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);
                    produtoEstoque.EstoqueProduto += quantidade;
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public int ConsultarEstoque(string numeroProduto)
        {
            int quantidade = 0;
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = database.Estoque.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);
                    quantidade = produtoEstoque.EstoqueProduto;
                }
            }
            catch
            {
            }
            return quantidade;
        }

        public bool IncluirProduto(Produto produto)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = new ProdutoEstoque();
                    produtoEstoque.NumeroProduto = produto.NumeroProduto;
                    produtoEstoque.NomeProduto = produto.NomeProduto;
                    produtoEstoque.DescricaoProduto = produto.DescricaoProduto;
                    produtoEstoque.EstoqueProduto = produto.EstoqueProduto;

                    database.Estoque.Add(produtoEstoque);
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public List<Produto> ListarProdutos()
        {
            List<Produto> products = new List<Produto>();
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    List<ProdutoEstoque> listProducts = (from product 
                                                         in database.Estoque
                                                         select product).ToList();

                    foreach (ProdutoEstoque produtoEstoque in listProducts)
                    {
                        Produto produto = new Produto();

                        produto.NumeroProduto = produtoEstoque.NumeroProduto;
                        produto.NomeProduto = produtoEstoque.NomeProduto;
                        produto.DescricaoProduto = produtoEstoque.DescricaoProduto;
                        produto.EstoqueProduto = produtoEstoque.EstoqueProduto;
                        
                        products.Add(produto);
                    }
                }
            }
            catch
            {
            }
            return products;
        }

        public bool RemoverEstoque(string numeroProduto, int quantidade)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = database.Estoque.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);
                    produtoEstoque.EstoqueProduto = produtoEstoque.EstoqueProduto - quantidade;
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool RemoverProduto(string numeroProduto)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = database.Estoque.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);
                    database.Estoque.Remove(produtoEstoque);
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public Produto VerProduto(string numeroProduto)
        {
            Produto produto = null;
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    ProdutoEstoque produtoEstoque = database.Estoque.First(
                        p => String.Compare(p.NumeroProduto, numeroProduto) == 0);

                    produto = new Produto();
                    produto.NumeroProduto = produtoEstoque.NumeroProduto;
                    produto.NomeProduto = produtoEstoque.NomeProduto;
                    produto.DescricaoProduto = produtoEstoque.DescricaoProduto;
                    produto.EstoqueProduto = produtoEstoque.EstoqueProduto;
                }
            }
            catch
            {
            }
            return produto;
        }
    }
}