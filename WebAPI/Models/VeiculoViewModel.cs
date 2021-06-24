using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class VeiculoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Marca { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Modelo { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Ano { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Quilometragem { get; set; }
    }
}
