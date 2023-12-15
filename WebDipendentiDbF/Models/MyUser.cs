using System.ComponentModel.DataAnnotations;

namespace WebDipendentiDbF.Models
{
    public class MyUser
    {
        [Key]
        public int Id { get; set; }

        [MinLength(5, ErrorMessage ="L'username deve avere almeno 5 caratteri")]
        [MaxLength(20, ErrorMessage = "L'username deve avere massimo 10 caratteri")]
        [Required]
        public string? Username { get; set; }

        //[Required]
        //[MinLength(8, ErrorMessage ="La password deve contenere almeno 8 caratteri")]
        //[RegularExpression(@"[a-z][A-Z][0-9][',!.:_]")]
        public string? Password { get; set; }

        public string? Email { get; set; }
    }
}
