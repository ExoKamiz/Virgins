using System.ComponentModel.DataAnnotations;

namespace Virgins.Models
{
    public class Virgin
    {
        [Key]
        public int Id { get; set; }
        [Required]                       //обязательное заполнение этого поля 
        [StringLength(50)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]                       //обязательное заполнение этого поля 
        [StringLength(50)]
        [Display(Name = "User Last Name")]
        public string UserLastName { get; set; }

        public string? Image { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public string IsVirgin { get; set; }


    }
}
