using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_SQLTermekek_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string kapcsolatleiro = "datasource=127.0.0.1;port=3306;database=hardver;username=root;password=;";

            MySqlConnection SQLkapcsolat = new MySqlConnection(kapcsolatleiro);
            try
            {
                SQLkapcsolat.Open();
            }
            catch (MySqlException hiba)
            {
                Console.WriteLine(hiba.Message);
                Environment.Exit(1);
            }

            //Rendezze ár szerint növekvően a Samsung, Lg, Asus
            //gyártók monitorainak nevét és árát, amelyek 27" átmérővel rendelkeznek!
            //(A 27" képátló adatra a termék nevében keressen!)

            string SQLselect = " SELECT Név, Ár " +
                               " FROM termékek " +
                               " WHERE Gyártó " +
                               " IN('Samsung','Lg','Asus') " +
                               " AND Név" +
                               " LIKE '%27\"%' " +
                               " ORDER BY Ár ";
                               
           

            MySqlCommand SQLparancs = new MySqlCommand(SQLselect, SQLkapcsolat);
           
            MySqlDataReader eredmenyOlvaso = SQLparancs.ExecuteReader();
           
            while (eredmenyOlvaso.Read())
            {

                Console.Write(eredmenyOlvaso.GetString(0) + " - ");
                Console.WriteLine(Convert.ToInt32(eredmenyOlvaso.GetString(1)));
            }
            eredmenyOlvaso.Close();
            SQLkapcsolat.Close();

        }
    }
}
