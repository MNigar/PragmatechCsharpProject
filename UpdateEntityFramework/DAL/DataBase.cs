using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateEntityFramework.DataBaseContext;
using UpdateEntityFramework.Mdels;

namespace UpdateEntityFramework.DAL
{
    public class DataBase
    {

        public void Update(Book book)
        {
            using (BookDbContext context = new BookDbContext())
            {

                //var query = context.Books.Find(book.Id);
                var q = context.Entry(book);
                q.State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
