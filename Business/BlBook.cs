using System;
using System.Collections.Generic;
using DataAccess;
using Domain;

namespace Business
{
    public interface IBlBook
    {
        List<ListBookModel> List(string query);
    }

    public class BlBook : IBlBook
    {
        readonly IEfBook _efBook;

        public BlBook(IEfBook efBook)
        {
            _efBook = efBook;
        }

        public List<ListBookModel> List(string query)
        {
            return _efBook.List(query);
        }
    }
}
