using KlassWorkI22._05.Model.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlassWorkI22._05.Model.Tables
{
    internal class TableParcels
    {
        private List<Parcel> parcels;
        private NpgsqlCommand npgsqlCommand;

        public List<Parcel> Rows
        {
            get { return parcels; }
        }

        public TableParcels(NpgsqlCommand npgsqlCommand, TableCities tabelCities)
        {
            this.npgsqlCommand = npgsqlCommand;

            parcels = new List<Parcel>();
            LoadParcels(tabelCities);
        }

        private void LoadParcels(TableCities tabelCities)
        {
            npgsqlCommand.CommandText = "Select * from parcels";

            NpgsqlDataReader dataReader = npgsqlCommand.ExecuteReader();

            parcels.Clear();

            while (dataReader.Read())
            {
                parcels.Add(new Parcel()
                {
                    Id = dataReader.GetInt32(dataReader.GetOrdinal("id")),
                    Dt = dataReader.GetDateTime(dataReader.GetOrdinal("datetime")),
                    IdCiy = dataReader.GetInt32(dataReader.GetOrdinal("id_city")),
                    Weight = dataReader.GetFloat(dataReader.GetOrdinal("weight")),
                    Dimens = dataReader.GetString(dataReader.GetOrdinal("dimens")),
                    Price = dataReader.GetInt32(dataReader.GetOrdinal("price")),

                    City = tabelCities.Rows.Find(item => item.Id == dataReader.GetInt32(dataReader.GetOrdinal("id_city")))
                }); ;
            }

            dataReader.Close();
        }
    }
}
