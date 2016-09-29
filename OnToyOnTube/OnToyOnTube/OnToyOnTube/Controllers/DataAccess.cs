using OnToyOnTube.Models;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;


namespace OnToyOnTube.Controllers
{
    public class DataAccess : IDisposable
    {
        private SQLiteConnection connection;

        public DataAccess()
        {
            var config = DependencyService.Get<iConfig>();
            connection = new SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DirectorioDB, "OnToyOnTube.db3"));
            connection.CreateTable<Configuracion>();
            connection.CreateTable<Persona>();
            connection.CreateTable<Ubicacion>();
        }

        public T Insert<T>(T model)
        {
            connection.Insert(model);
            return model;
        }

        public T Update<T>(T model)
        {
            connection.Update(model);
            return model;
        }

        public bool Delete<T>(T model)
        {
            var response = connection.Delete(model);
            return response == 1;
        }

        public List<T> GetList<T>() where T : class
        {
            return connection.Table<T>().ToList();
        }

        public List<T> GetListWithChildren<T>() where T : class
        {
            return connection.GetAllWithChildren<T>().ToList();
        }
        public T Find<T>(int Pk) where T : class
        {
            return connection.Table<T>().FirstOrDefault(m => m.GetHashCode() == Pk);
        }

        public T FindWithChildren<T>(int Pk) where T : class
        {
            return connection.GetAllWithChildren<T>().FirstOrDefault(m => m.GetHashCode() == Pk);
        }

        public T GetFirst<T>() where T : class
        {
            return connection.Table<T>().FirstOrDefault();
        }

        public T GetFirstWithChildren<T>() where T : class
        {
            return connection.GetAllWithChildren<T>().FirstOrDefault();
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}