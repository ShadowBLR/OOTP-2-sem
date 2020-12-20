using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPLab3_new
{
   partial class Book
    {
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            Book b = obj as Book;
            if (b  == null)
                return false;
            return this.Name == b.Name &&
                this.NumberOfPages == b.NumberOfPages &&
                this.Price == b.Price &&
                this.YearOfPublishing == b.YearOfPublishing &&
                this.Author == b.Author;
        }
        public override int GetHashCode()
        {
            if (price > 500)
            {
                return price * 20 + NumberOfPages * 4 + YearOfPublishing * 12  + Name.Length * 48;
            }
            else
            {
                return price * 50 + NumberOfPages * 24 + YearOfPublishing * 12   + Name.Length * 48;
            }
        }
        public override string ToString()
        {
            string str = $@"Книга:{Name}
Автор:{Author}
Цена:{Price}
Год публикации:{YearOfPublishing}
Число страниц:{NumberOfPages}
Цена:{price}
Толщина:{Толщина}";

            return str;
        }
    }
}
