using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaelumEstoque.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [StringLength(20)]
        public String Nome { get; set; }

        [Required(ErrorMessage="Por favor informe o Preço")]
        public float Preco { get; set; }

        public CategoriaDoProduto Categoria { get; set; }

        [Required]
        public int? CategoriaId { get; set; }
        
        [Required]
        public String Descricao { get; set; }
        
        [Required]
        public int Quantidade { get; set; }
    }
}