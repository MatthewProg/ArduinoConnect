using System;

namespace ArduinoConnect.DataAccess.Models
{
    public class ExchangeTableModel
    {
        public int ID { get; set; }
        public int OwnerID { get; set; }
        public DateTime AddTime { get; set; }
        public int ReceiverID { get; set; }
        public string Command { get; set; }
        public string ReceiverDevice { get; set; }
    }
}
