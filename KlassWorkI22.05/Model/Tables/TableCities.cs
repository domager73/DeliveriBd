using KlassWorkI22._05.Model.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlassWorkI22._05.Model.Tables
{
    internal class TableCities
    {
        private List<City> cities;
        private NpgsqlCommand npgsqlCommand;

        public List<City> Rows 
        {
            get { return cities; }
        }

        public TableCities(NpgsqlCommand npgsqlCommand) 
        {
            this.npgsqlCommand = npgsqlCommand;

            cities = new List<City>();
            LoadCities();
        }

        private void LoadCities() 
        {
            npgsqlCommand.CommandText = "Select * from cities";

            NpgsqlDataReader dataReader = npgsqlCommand.ExecuteReader();

            cities.Clear();

            while (dataReader.Read()) 
            {
                cities.Add(new City()
                {
                    Id = dataReader.GetInt32(dataReader.GetOrdinal("id")),
                    Name = dataReader.GetString(dataReader.GetOrdinal("name")),
                });
            }

            dataReader.Close();
        }
    }
}
