using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPR6312POEPart1DAF.Models
{
    public class DonationMoney
    {
        [Key]
        public int DonationMoneyId { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Doner { get; set; }
        
        [ForeignKey("Disaster")]
        public int DisasterId { get; set; }
        public Disaster? Disaster { get; set; }
    }
}
