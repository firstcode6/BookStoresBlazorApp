using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Interfaces;

namespace WebApi.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context"></param>
        public PublisherRepository(AppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        #region Requests

        /// <summary>
        /// Get publishers
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Publisher>> GetPublishers()
        {
           return await _context.Publishers.ToListAsync();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="publisher"></param>
        /// <returns></returns>
        public async Task<bool> CreatePublisher(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
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
