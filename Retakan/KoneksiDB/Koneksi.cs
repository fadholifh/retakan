using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Retakan.KoneksiDB
{
    class Koneksi
    {
        private static SqlConnection koneksi;

        public static SqlConnection GetKoneksi()
        {
            koneksi = new SqlConnection();
            koneksi.ConnectionString = "Data Source=ACER\\SQLEXPRESS;" +
                                       "Initial Catalog=Retakan;" +
                                       "Integrated Security=True";
            return koneksi;
        }
    }
}
