

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Bibilioteca.Biblioteca.Api.DTOs
{
    public class LivroCreateDto //Class para transporte de dados do service para o controller
    {

        [MaxLength(2), MinLength(1)]
        public string Nome { get; set; } = null!;

        public bool Disponivel { get; set; }
        [JsonIgnore]
        public int id { get; set; }
    }
}
