using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Interfaces;

namespace WebApi.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context"></param>
        public AuthorRepository(AppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();

            CreationDate = DateTime.Now;
        }

        #region Properties
        /// <summary>
        /// Date of creation
        /// </summary>
        public DateTime CreationDate { get; set; }
        #endregion

        #region Requests

        /// <summary>
        ///  Get Authors
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Author>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
        }

        /// <summary>
        /// Get autor by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Author> GetAuthorById(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
                throw new Exception("No such author. :/");
            return author;
        }

        /// <summary>
        /// Get date
        /// </summary>
        /// <returns></returns>
        public DateTime GetCreatedDate()
        {
            return CreationDate;
        }

        /// <summary>
        /// Create author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public async Task<bool> CreateAuthor(Author author)
        {
            _context.Authors.Add(author);
            return await Save();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="author"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> UpdateAuthor(Author author, int id)
        {
            var dbAuthor = await _context.Authors.FindAsync(id);
            if (dbAuthor == null)
                throw new Exception("No such author. :/");

            dbAuthor.FirstName = author.FirstName;
            dbAuthor.LastName = author.LastName;
            dbAuthor.City = author.City;
            dbAuthor.EmailAddress = author.EmailAddress;
            dbAuthor.Salary = author.Salary;
            dbAuthor.PhoneNumber = author.PhoneNumber;

            return await Save();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteAuthor(int id)
        {
            var dbAuthor = await _context.Authors.FindAsync(id);
            if (dbAuthor == null)
                throw new Exception("No such author. :/");

            _context.Authors.Remove(dbAuthor);
            return await Save();
        }

        /// <summary>
        /// Save in database
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        #endregion
    }
}
