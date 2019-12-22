using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace EstoqueLibrary
{
    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/01", Name = "IServicoEstoque")]
    public interface IServicoEstoque
    {
        [OperationContract]
        List<Produto> ListarProdutos();

        [OperationContract]
        bool IncluirProduto(Produto produto);

        [OperationContract]
        bool RemoverProduto(string numeroProduto);

        [OperationContract]
        int ConsultarEstoque(string numeroProduto);

        [OperationContract]
        bool AdicionarEstoque(string numeroProduto, int quantidade);

        [OperationContract]
        bool RemoverEstoque(string numeroProduto, int quantidade);

        [OperationContract]
        Produto VerProduto(string numeroProduto);
    }

    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/02", Name = "IServicoEstoqueV2")]
    public interface IServicoEstoqueV2
    {
        [OperationContract]
        bool AdicionarEstoque(string numeroProduto, int quantidade);

        [OperationContract]
        bool RemoverEstoque(string numeroProduto, int quantidade);

        [OperationContract]
        int ConsultarEstoque(string numeroProduto);
    }

    [DataContract]
    public class Produto
    {
        [DataMember(Order = 0)]
        public string NumeroProduto { set; get; }

        [DataMember(Order = 1)]
        public string NomeProduto { set; get; }

        [DataMember(Order = 2)]
        public string DescricaoProduto { set; get; }

        [DataMember(Order = 3)]
        public int EstoqueProduto { set; get; }
    }
}