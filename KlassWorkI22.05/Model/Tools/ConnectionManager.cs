using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Pos
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace KlassWorkI22._05.Model.Tools
{
    internal class ConnectionManager
    {
        public static NpgsqlConnection GetConnection() 
        {
            string  connnectionString = $"Host=194.67.105.79;Username=my_delivery_user;Password=12345;Database=my_delivery_db";

            return new NpgsqlConnection(connnectionString);
        }

    }
}
