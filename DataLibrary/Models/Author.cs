using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Models
{
    public class Author
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public Author()
        {

        }

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [StringLength(20, ErrorMessage = "Name of the city can not be longer than 20 chars")]
        [Required]
        public string City { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Salary
        /// </summary>
        [Range(1000, 99999999, ErrorMessage = "Salary can not be less than 1000")]
        public int Salary { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [Required]
        public string PhoneNumber { get; set; }
    }
}
