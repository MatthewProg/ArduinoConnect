using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArduinoConnect.Web.RequestModels
{
    public class UserTableModel
    {
        [Key]
        public int TableID { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [DisplayName("Name")]
        public string TableName { get; set; }

        [StringLength(100, ErrorMessage = "Description cannot be longer than 100 characters.")]
        [DisplayName("Description")]
        public string TableDescription { get; set; }

        [DisplayName("Schema")]
        public string TableSchema { get; set; }
    }
}
