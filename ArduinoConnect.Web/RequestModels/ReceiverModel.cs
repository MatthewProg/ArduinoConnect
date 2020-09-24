using System.ComponentModel.DataAnnotations;

namespace ArduinoConnect.Web.RequestModels
{
    public class ReceiverModel
    {
        [Key]
        public int ReceiverID { get; set; }

        [StringLength(50, ErrorMessage = "Description cannot be longer than 50 characters.")]
        public string Description { get; set; }
    }
}
