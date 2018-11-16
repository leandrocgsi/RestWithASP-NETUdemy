using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Model
{
    // Uncomment to connect in Postgree [Table("persons", Schema = "rest_with_asp_net_udemy")]
    [Table("persons")]
    public class Person
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }

        [Column("firstname")]
        public string FirstName { get; set; }

        [Column("lastname")]
        public string LastName { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("gender")]
        public string Gender { get; set; }
    }
}
