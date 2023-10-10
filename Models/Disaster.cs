using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPR6312POEPart1DAF.Models
{
    public class Disaster
    {
        [Key]
        public int DisasterId { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
