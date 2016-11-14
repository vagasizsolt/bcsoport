using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO; 
using System.Data.SQLite;

namespace Dolgozok
{
    class Adatbazis
    {
        SQLiteConnection conn;

        #region singleton

        private Adatbazis()
        {

            string adatbEleres = Directory.GetCurrentDirectory() + @"\Adatbazis\dolgozok.db";

            conn = new SQLiteConnection(string.Format("Data Source = {0};Version = 3;", adatbEleres));
            conn.Open();

        }
        private static Adatbazis peldany = null;
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static Adatbazis GetPeldany()
        {
            if (peldany == null)
            {
                peldany = new Adatbazis();
            }
            return peldany;
        }

        /// <summary>
        /// </summary>
        /// <param name="lekerdezes"></param>
        /// <returns></returns>
        public SQLiteDataReader Lekerdezes(string lekerdezes)
        {
            SQLiteCommand comm = new SQLiteCommand(lekerdezes, conn); 
            SQLiteDataReader reader = comm.ExecuteReader(); 

            return reader; 
        }
        #endregion

    }
}