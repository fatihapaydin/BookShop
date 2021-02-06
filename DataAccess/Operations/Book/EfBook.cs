using System.Collections.Generic;
using System.Linq;
using Domain;

namespace DataAccess
{
    public interface IEfBook
    {
        List<ListBookModel> List(string query);
    }

    public class EfBook : IEfBook
    {
        SampleContext db;

        public EfBook(SampleContext context)
        {
            db = context;
        }

        public List<ListBookModel> List(string query)
        {
            return db.Books.Where(j => j.Name.Contains(query)).Select(j => new ListBookModel
            {
                Id = j.Id,
                Name = j.Name,
                PageCount = j.PageCount
            }).ToList();
        }
    }
}