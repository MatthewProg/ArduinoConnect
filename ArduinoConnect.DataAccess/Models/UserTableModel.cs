namespace ArduinoConnect.DataAccess.Models
{
    public class UserTableModel
    {
        public int TableID { get; set; }
        public int OwnerID { get; set; }
        public string TableName { get; set; }
        public string TableDescription { get; set; }
        public string TableSchema { get; set; }
    }
}
