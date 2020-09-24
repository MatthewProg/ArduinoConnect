using System.ComponentModel.DataAnnotations;

namespace ArduinoConnect.Web.RequestModels
{
    public class DataTableModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int TableID { get; set; }

        [Required]
        public string Data { get; set; }
    }
}
