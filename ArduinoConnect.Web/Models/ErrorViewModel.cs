namespace ArduinoConnect.Web.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public short ErrorCode { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
