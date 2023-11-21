using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Common;
using Task15_DB_Entity.Model.ClientModel;
using Microsoft.EntityFrameworkCore;

namespace Task15_DB_Entity.Model
{
    internal class SQLClientRep : IRepository<Client>
    {
        private IEnumerable<Client> db;
      //  private string _ConnectionString = "Server=ES-RW-20-32; Database=Clients;Trusted_Connection=true;";
           private string _ConnectionString = "Server=ES-RW-20-32; Database=Clients;User=abc; Password=123";
        public SQLClientRep()
        {
            this.db = new List<Client>();
            GetItemList();
        }

        public void Create(Client item)
        {
            CreateAsync(item);
        }

        public void Delete(int id)
        {
            DeleteAsync(id);
        }

        private bool _disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
                if (disposing)
                    Dispose();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Client> GetItemList()
        {
             GetClientsSQL();
           


            return  db;
        }


        public Client GetItem(int id)
        {
            return db.FirstOrDefault(x => x.ID == id);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Client item)
        {
            UpdateAsync(item);
        }
        async private Task<int?> DeleteAsync(int id)
        {
            

            try
            {
                using (SQLClientRepContext dbSQL = new SQLClientRepContext())
                {
                    
                    dbSQL.Clients.Remove(dbSQL.Clients.FirstOrDefault(x => x.ID == id));
                    await dbSQL.SaveChangesAsync();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return (null);
         
        }
        async private Task<int?> CreateAsync(Client client)
        {

            try
            {
                using (SQLClientRepContext dbSQL = new SQLClientRepContext())
                {
                    dbSQL.Clients.Add(client);
                    await dbSQL.SaveChangesAsync();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return (null);

        }

        async private Task<int?> UpdateAsync(Client client)
        {


            try
            {
                using( SQLClientRepContext dbSQL = new SQLClientRepContext())
                {
                     dbSQL.Clients.Update(client);
                   await  dbSQL.SaveChangesAsync();
                }
               
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return (null);

        }
        async private Task GetClientsSQL()
        {
           

            try
            {
                using (SQLClientRepContext dbSQL = new SQLClientRepContext())
                {
                    db = await dbSQL.Clients.ToListAsync();
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

           
        }
    }
}
