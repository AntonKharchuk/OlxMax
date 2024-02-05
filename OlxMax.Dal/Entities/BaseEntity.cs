

using System.ComponentModel.DataAnnotations;

namespace OlxMax.Dal.Entity
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }



        //юзер(з айді, паролем та балансом, якого треба буде реєструвати)

        //ставка(з юзерІД, ціною, часом дадавання ставки)

        //аункціон(з описом, стартовою ставкою, списком ставок, з фотками)
    }
}
