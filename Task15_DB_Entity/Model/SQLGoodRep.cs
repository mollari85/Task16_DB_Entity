using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Data.SqlClient;
using System.Windows;
using System.Data;
using System.Collections.ObjectModel;
using Task15_DB_Entity.Model.SQLite;
using Microsoft.EntityFrameworkCore;

namespace Task15_DB_Entity.Model
{
    internal class SQLGoodRep : IRepository<Good>
    {
        private IEnumerable<Good> db;

        public SQLGoodRep()
        {
            this.db = new List<Good>();
            GetItemList();
        }

        public void Create(Good item)
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

        public IEnumerable<Good> GetItemList()
        {
            GetGoodsSQL();



            return db;
        }


        public Good GetItem(int id)
        {
            return db.FirstOrDefault(x => x.ID == id);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Good item)
        {
            UpdateAsync(item);
            
        }
        async private Task<int?> DeleteAsync(int id)
        {

            //   ConnectionString = "Server=ES-RW-20-32; Database=Clients;Trusted_Connection=true;";
            //   ConnectionString = "Server=ES-RW-20-32; Database=Clients;User=abc; Password=123";
            try
            {
                using (SQLiteGoodRepEntity dbSQLite = new SQLiteGoodRepEntity())
                {
                    Good? item = dbSQLite.dbGood.FirstOrDefault(x => x.ID == id);
                    if (item != null)
                     dbSQLite.dbGood.Remove(item);
                    dbSQLite.SaveChanges();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return (null);

        }
        async private Task<int?> CreateAsync(Good item)
        {

            
            try
            {
                using (SQLiteGoodRepEntity dbSQLite=new SQLiteGoodRepEntity())
                {
                   await  dbSQLite.dbGood.AddAsync(item);
                   await dbSQLite.SaveChangesAsync();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return (null);

        }

        async private Task<int?> UpdateAsync(Good item)
        {

            //   ConnectionString = "Server=ES-RW-20-32; Database=Clients;Trusted_Connection=true;";
            //   ConnectionString = "Server=ES-RW-20-32; Database=Clients;User=abc; Password=123";
            try
            {
                using (SQLiteGoodRepEntity dbSQLite=new SQLiteGoodRepEntity())
                {
                   dbSQLite.dbGood.Update(item);
                   await dbSQLite.SaveChangesAsync();
                   
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            return (null);

        }
        async private Task<int?> GetGoodsSQL()
        {
           
            try
            {
                using (SQLiteGoodRepEntity dbSQLite= new SQLiteGoodRepEntity())
                {
                    db=await dbSQLite.dbGood.ToListAsync();
                  
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


            return (null);
            
        }
    

    #region tools
    public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
