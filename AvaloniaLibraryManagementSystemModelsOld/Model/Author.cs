using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => string.Join(' ', FirstName, LastName);

        //a.Код_Автор || ' ' || a.Имя || ' ' || a.Фамилия || a.Отчество AS Author,
        public void CreateByDB(string Response)
        {
            Id = Int32.Parse(Response.Split(' ')[0]);
            FirstName = Response.Split(' ')[1];
            LastName = Response.Split(' ')[2];
        }
    }
}