using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Group
    {
        [Key]
        public int GroupID { get; set; }
        public int SpecializationID { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        [ForeignKey("SpecializationID")]
        public virtual Specialization Specialization { get; set; }
    }
}
