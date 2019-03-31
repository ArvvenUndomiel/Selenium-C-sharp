namespace AutomationCourseMockingHomework.Models
{
    using System.Collections.Generic;

    public class Wishlist
    {
        public Wishlist()
        {
            Books = new List<Book>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books {get;set;}
    }
}