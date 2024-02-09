
using OlxMax.Dal.Entity;

namespace OlxMax.Dal.Entities
{
    public class User:BaseEntity
    {
        //юзер(з айді, паролем та балансом, якого треба буде реєструвати)

        public double Balace { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

    }
}
