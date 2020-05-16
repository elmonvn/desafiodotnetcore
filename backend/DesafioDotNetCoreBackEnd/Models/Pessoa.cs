using System.ComponentModel.DataAnnotations;

namespace DesafioDotNetCoreBackEnd.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        [Required] [StringLength(256)] public string Nome { get; set; }

        [Phone] public string Telefone { get; set; }

        [EmailAddress] public string Email { get; set; }
    }
}