using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Criptomonedas.Models
{
    public class Criptomoneda
    {
        [Key]
        public string moneda { get; set; }
        public decimal lastValor { get; set; }
        public decimal maxValor { get; set; }
    }
}