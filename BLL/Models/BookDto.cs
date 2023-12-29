using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class BookDto
    {
        public int Book_ID { get; set; }
        public int Number_pages { get; set; }
        public int Author_ID { get; set; }
        public int Cost { get; set; }
    }
}
