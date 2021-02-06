using System;
using System.Collections.Generic;
using DataAccess;
using Domain;

namespace Business
{
    public interface IBlBook
    {
        List<ListBookModel> List(string query);
        Result<NewBookModel> Add(NewBookModel model);
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

        public Result<NewBookModel> Add(NewBookModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
                return new Result<NewBookModel>("Book Name cannot be blank");

            if (model.PageCount < 20 || model.PageCount > 2000)
                return new Result<NewBookModel>("Book with name " + model.Name + " page count can be minimum 20 and maximum 2000");

            return _efBook.Add(model);
        }
    }
}
