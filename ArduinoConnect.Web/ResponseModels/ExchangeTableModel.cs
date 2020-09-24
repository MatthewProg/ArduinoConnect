using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArduinoConnect.Web.ResponseModels
{
    public class ExchangeTableModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int OwnerID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("Add Time")]
        public DateTime AddTime { get; set; }

        [Required]
        public int ReceiverID { get; set; }

        [Required]
        public string Command { get; set; }

        [DisplayName("Receiver Device")]
        [StringLength(50, ErrorMessage = "Receiver Device cannot be longer than 50 characters.")]
        public string ReceiverDevice { get; set; }
    }
}
