using System.Collections.Generic;

namespace Domain
{
    public class Result<T>
    {
        public bool IsErrorExists { get; set; }

        public List<string> ErrorList { get; set; }

        public int Id { get; set; }

        public Result()
        {
            IsErrorExists = true;
        }

        public Result(string error)
        {
            var errorExists = !string.IsNullOrWhiteSpace(error);
            IsErrorExists = errorExists;
            ErrorList = errorExists ? new List<string> { error } : null;
        }
        public Result(int id)
        {
            Id = id;
        }
    }

}