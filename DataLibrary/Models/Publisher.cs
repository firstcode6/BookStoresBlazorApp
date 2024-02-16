using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Models
{
    public class Publisher
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public Publisher()
        {

        }

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string PublisherName { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        //public string State { get; set; }
        //public string Country { get; set; }

    }
}
