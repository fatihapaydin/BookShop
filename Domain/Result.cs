using System.Collections.Generic;

namespace Domain
{
    public class Result<T>
    {
        public bool IsErrorExists { get; set; }

        public List<string> ErrorList { get; set; }

        public int Id { get; set; }

        public T Value { get; set; }

        public Result()
        {
            IsErrorExists = true;
        }

        public Result(List<string> errorList)
        {
            IsErrorExists = errorList != null && errorList.Count > 0;
            ErrorList = errorList;
        }

        public Result(int id)
        {
            Id = id;
        }

        public Result(T value, string errorMessage = "")
        {
            Value = value;
            IsErrorExists = value == null;
            ErrorList = new List<string> { errorMessage };
        }

    }

}