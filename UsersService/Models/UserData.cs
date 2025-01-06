using System.ComponentModel.DataAnnotations;

namespace UsersService.Models
{
    public class UserData
    {
        [Required]
        [Key]
        public int User_ID { get; set; }
    

        [Required]
        public String User_Name { get; set; }

        [Required]
        public String User_Surname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public String User_Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public String User_Password { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public String User_PhoneNumber { get; set; }

        [Required]
        public String User_Adress { get; set; }

    }
}
