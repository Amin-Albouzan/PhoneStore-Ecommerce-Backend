using System.ComponentModel.DataAnnotations;

namespace UsersService.Models
{
    public class manager
    {




            [Required]
            [Key]
            public int manager_ID { get; set; }

            [Required]
            public String manager_Name { get; set; }

            [Required]
            public String manager_Surname { get; set; }

            [Required]
            [DataType(DataType.EmailAddress)]
            public String manager_Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public String manager_Password { get; set; }

            [Required]
            [DataType(DataType.PhoneNumber)]
            public String manager_PhoneNumber { get; set; }

            [Required]
            public String manager_Adress { get; set; }

   




}
}
