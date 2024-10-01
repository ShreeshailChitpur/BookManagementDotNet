using Dapper;
using System.Data;
using BookManagementSystem.Models;

namespace BookManagementSystem.Repositories
{
    public class BookRepository
    {
        private readonly IDbConnection _db;

        public BookRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var sql = "SELECT * FROM Books";
            return await _db.QueryAsync<Book>(sql);
        }

        public async Task<Book> GetBookById(int id)
        {
            var sql = "SELECT * FROM Books WHERE BookID = @Id";
            return await _db.QuerySingleOrDefaultAsync<Book>(sql, new { Id = id });
        }

        public async Task<int> CreateBook(Book book)
        {
            var sql = "INSERT INTO Books (Title, Description, PublishedYear, AuthorID, CategoryID) VALUES (@Title, @Description, @PublishedYear, @AuthorID, @CategoryID)";
            return await _db.ExecuteAsync(sql, book);
        }

        public async Task<int> UpdateBook(Book book)
        {
            var sql = "UPDATE Books SET Title = @Title, Description = @Description, PublishedYear = @PublishedYear, AuthorID = @AuthorID, CategoryID = @CategoryID WHERE BookID = @BookID";
            return await _db.ExecuteAsync(sql, book);
        }

        public async Task<int> DeleteBook(int id)
        {
            var sql = "DELETE FROM Books WHERE BookID = @Id";
            return await _db.ExecuteAsync(sql, new { Id = id });
        }
    }
}
