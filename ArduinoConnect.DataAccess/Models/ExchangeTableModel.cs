namespace ArduinoConnect.DataAccess.Models
{
    public class ExchangeTableModel
    {
        public int ID { get; set; }
        public int OwnerID { get; set; }
        public int ReceieverID { get; set; }
        public string Command { get; set; }
        public string ReceiverDevice { get; set; }
    }
}
