using DataLibrary.Models;

namespace WebApi.Interfaces
{
    public interface IAuthorRepository
    {
        /// <summary>
        /// Get all data
        /// </summary>
        /// <returns></returns>
        Task<ICollection<Author>> GetAuthors();

        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Author> GetAuthorById(int id);

        /// <summary>
        /// Get date
        /// </summary>
        /// <returns></returns>
        DateTime GetCreatedDate();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        Task<bool> CreateAuthor(Author author);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="author"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> UpdateAuthor(Author author, int id);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAuthor(int id);

        /// <summary>
        /// Save
        /// </summary>
        /// <returns></returns>
        Task<bool> Save();
    }
}
