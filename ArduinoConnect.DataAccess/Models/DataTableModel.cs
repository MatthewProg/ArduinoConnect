using System;
using System.Collections.Generic;
using System.Text;

namespace ArduinoConnect.DataAccess.Models
{
    public class DataTableModel
    {
        public int ID { get; set; }
        public int TableID { get; set; }
        public DateTime AddTime { get; set; }
        public string Data { get; set; }
    }
}
