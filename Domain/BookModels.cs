namespace Domain
{
    public class ListBookModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PageCount { get; set; }
    }

    public class NewBookModel
    {
        public string Name { get; set; }

        public int PageCount { get; set; }
    }
}