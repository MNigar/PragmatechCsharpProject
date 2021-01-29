using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UpdateEntityFramework.DAL;
using UpdateEntityFramework.DataBaseContext;
using UpdateEntityFramework.Mdels;

namespace UpdateEntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetJanr();
            GetAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        DataBase dataBase = new DataBase();
        private void GetAll()
        {
            using (BookDbContext context = new BookDbContext())
            {
                var query = context.Books.Select(book => new
                {   book.Id,
                    book.Name,
                    book.Author,
                    book.JanrId,
                    Janre = book.Janr.Name

                }).ToList();
                dataGridView1.DataSource = query;
            }
        }
        //private void Update(Book book)
        //{
        //    using (BookDbContext context = new BookDbContext())
        //    {
              
        //        //var query = context.Books.Find(book.Id);
        //        var q=context.Entry(book);
        //        q.State = System.Data.Entity.EntityState.Modified;
        //        context.SaveChanges();

        //    }
        //}
        private void SetJanr()
        {
            using (BookDbContext context = new BookDbContext())
            {
                foreach (Janr janr in context.Janrs.ToList())
                {
                    cmb_Janr.Items.Add(janr.Id + "." + janr.Name);
                }
            }
        }
        private void btn_Update_Click(object sender, EventArgs e)
        {
            Book book = new Book()
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                Name = txb_Name.Text,
                Author = txb_Author.Text,
                JanrId =Convert.ToInt32( cmb_Janr.Text.Split('.')[0])

            };
            dataBase.Update(book);
            GetAll();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txb_Name.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txb_Author.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cmb_Janr.SelectedItem = dataGridView1.CurrentRow.Cells[3].Value.ToString()+"."+dataGridView1.CurrentRow.Cells[4].Value.ToString();

        }
    }
}
