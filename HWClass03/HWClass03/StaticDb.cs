using Models;

namespace Homework_Class03
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>
        {
            new Book() {Author = "J. K. Rowling", Title = "Harry Potter"},
            new Book() {Author = "Danielle Steel", Title = "Happiness"},
            new Book() {Author = "Bonnie Garmus", Title = "Lessons in Chemistry"},
            new Book() {Author = "Steve McConnell", Title = "Code Complete"},
            new Book() {Author = "Robert Cecil Martin", Title = "Clean Code"}
        };
    }
}
