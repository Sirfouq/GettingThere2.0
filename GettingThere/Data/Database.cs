using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using GettingThere.Models;
using GettingThere;
using System.Collections.ObjectModel;

namespace GettingThere.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

        public Database(string dbpath)
        {
            
            database = new SQLiteAsyncConnection(dbpath);
            database.CreateTableAsync<User>().Wait();
            database.CreateTableAsync<Product>().Wait();
            database.CreateTableAsync<Settings_Master>().Wait();

        }
        public Task<List<User>> GetUserAsync()
        {
            return database.Table<User>().ToListAsync();

        }
        public Task<int> SaveUserAsync(User user)
        {
           
            
            return database.InsertAsync(user);
            

        }

        public Task<int> SaveProductAsync(Product product)
        {
           /* if (product.ID != 0)
            {
                return database.UpdateAsync(product);
            }
            else
            {*/
                return database.InsertAsync(product);
            }
        //}

        public Task<List<Product>> GetProductAsync()
        {
            return database.Table<Product>().ToListAsync();
        }

        public Task<List<Product>> GetProductSearchAsync(string SearchBarText)
        {
            return database.QueryAsync<Product>($"SELECT * FROM [Product] WHERE  [ID]= {Convert.ToInt32(SearchBarText)} OR [Price] = { SearchBarText} OR [Description]={SearchBarText}");
        }

        public Task<int> DeleteProductAsync(Product product)
        {
            return database.DeleteAsync(product);
        }

    }
}
