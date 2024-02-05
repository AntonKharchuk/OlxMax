
using OlxMax.Dal.Entity;

using System.ComponentModel.DataAnnotations;

namespace OlxMax.Dal.Entities
{
    public class User:BaseEntity
    {
        //юзер(з айді, паролем та балансом, якого треба буде реєструвати)

        public double Balace { get; set; }

        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }

    }
}
