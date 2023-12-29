using System;


namespace DAL.Entities
{
    public class Book
    {
        public int Book_ID { get; set; }
        public int Number_pages { get; set; }

        public string Book_Name { get; set; }
        public int Author_ID { get; set; }
        public Author author { get; set; }
        public int Cost { get; set; }

    }
}
