using DataLibrary.Models;

namespace WebApi.Interfaces
{
    public interface IPublisherRepository
    {
        /// <summary>
        /// Get publishers
        /// </summary>
        /// <returns></returns>
        Task<ICollection<Publisher>> GetPublishers();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="publisher"></param>
        /// <returns></returns>
        Task<bool> CreatePublisher(Publisher publisher);
    }
}
