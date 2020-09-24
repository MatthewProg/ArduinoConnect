using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArduinoConnect.Web.ResponseModels
{
    public class DataTableModel
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int TableID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("Add Time")]
        public DateTime AddTime { get; set; }

        [Required]
        public string Data { get; set; }
    }
}
