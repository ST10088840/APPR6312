using System.ComponentModel.DataAnnotations;

namespace APPR6312POEPart1DAF.Models
{
    public class Catagory
    {
        [Key]
        public int CatagoryId { get; set; }
        public string? CatagoryName { get; set; }
    }
}
