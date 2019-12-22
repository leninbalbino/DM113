namespace EstoqueEntityModel
{
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
 
    public class ProvedorEstoque : DbContext
    {
        public ProvedorEstoque(): base("name=ProvedorEstoque")
        {
        }

        public virtual DbSet<ProdutoEstoque> Estoque { get; set; }
    }

    public class ProdutoEstoque
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string NumeroProduto { get; set; }
        [Required]
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        [Required]
        public int EstoqueProduto { get; set; }
    }
}