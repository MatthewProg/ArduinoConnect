using System.ComponentModel.DataAnnotations;

namespace ArduinoConnect.Web.ResponseModels
{
    public class TokenModel
    {
        [Key]
        public int TokenID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Token must be exactly 50 characters long.")]
        public string Token { get; set; }
    }
}
