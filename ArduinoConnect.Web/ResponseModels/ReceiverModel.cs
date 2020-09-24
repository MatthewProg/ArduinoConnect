using System.ComponentModel.DataAnnotations;

namespace ArduinoConnect.Web.ResponseModels
{
    public class ReceiverModel
    {
        [Key]
        public int ReceiverID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Description cannot be longer than 50 characters.")]
        public string Description { get; set; }
    }
}
