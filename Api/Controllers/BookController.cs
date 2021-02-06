using System.Collections.Generic;
using Business;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BookController : ControllerBase
    {
        readonly IBlBook _blBook;

        public BookController(IBlBook blBook)
        {
            _blBook = blBook;
        }

        public List<ListBookModel> List(string query)
        {
            query = query ?? "";
            return _blBook.List(query);
        }

        [HttpPost]
        public Result<NewBookModel> New([FromBody] NewBookModel model)
        {
            return _blBook.Add(model);
        }


    }
}