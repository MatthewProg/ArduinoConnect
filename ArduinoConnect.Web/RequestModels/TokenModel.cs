using System.ComponentModel.DataAnnotations;

namespace ArduinoConnect.Web.RequestModels
{
    public class TokenModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Token must be exactly 50 characters long.")]
        public string Token { get; set; }
    }
}
