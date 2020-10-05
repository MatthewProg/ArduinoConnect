using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ArduinoConnect.Web.RequestModels
{
    public class TokenModel
    {
        [Required]
        [StringLength(50, MinimumLength = 50, ErrorMessage = "Token must be exactly 50 characters long.")]
        [Remote(action: "VerifyToken", controller: "Start")]
        public string Token { get; set; }
    }
}
