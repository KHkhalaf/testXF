using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using testXF.Models;
using Xamarin.Forms;

namespace testXF.Data
{
    public class DataAccess<T>
    {
        public static SQLiteConnection connection { get; set; }
        public DataAccess()
        {
            try
            {
                connection = DependencyService.Get<Isqlite>().GetConnection();
                connection.CreateTable<T>();
            }
            catch (Exception)
            {
                DependencyService.Get<ISnackBar>().ShowSnackBar("Error ... Something went wrong");
            }
        }

        public List<T> GetUsers()
        {
            try
            {
                if (typeof(T) == typeof(User))
                    return connection.Table<User>().ToList() as List<T>;
                else
                    return null;
            }
            catch (Exception)
            {
                DependencyService.Get<ISnackBar>().ShowSnackBar("Error ... Something went wrong");
                return new List<T>();
            }
        }
        public void AddUser(T t)
        {
            try
            {
                connection.Insert(t);
            }
            catch (Exception)
            {
                DependencyService.Get<ISnackBar>().ShowSnackBar("Error ... Something went wrong");
            }
        }
        public List<T> SearchByName(string searchKey)
        {
            if (searchKey == "" || searchKey == null)
            {
                try
                {
                    if (typeof(T) == typeof(User))
                        return connection.Table<User>().ToList() as List<T>;
                    else
                        return null;
                }
                catch (Exception)
                {
                    DependencyService.Get<ISnackBar>().ShowSnackBar("Error ... Something went wrong");
                    return new List<T>();
                }
            }
            if (string.IsNullOrWhiteSpace(searchKey))
            {
                return new List<T>();
            }

            try
            {
                if (typeof(T) == typeof(User))
                    return connection.Table<User>().ToList().Where(u => u.Email.ToLower().Contains(searchKey)).ToList() as List<T>;
                else
                    return null;
            }
            catch (Exception)
            {
                DependencyService.Get<ISnackBar>().ShowSnackBar("Error ... Something went wrong");
            }
            return new List<T>();
        }
    }
}
