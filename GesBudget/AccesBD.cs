using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Configuration;

namespace GesBudget
{
    class AccesBD
    {
        OleDbConnection connection = new OleDbConnection();
        OleDbCommand commande = new OleDbCommand();
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        DataSet dataset = new DataSet();
        DataTable table = new DataTable();


        public AccesBD()
          {
             ConnectionStringSettings con = ConfigurationManager.ConnectionStrings["MaConnection"];              
             connection.ConnectionString= con.ConnectionString;

              //connection.ConnectionString = @"provider=Microsoft.Jet.OLEDB.4.0; Data source=C:\Users\marina\Desktop\BD_Arrondissement.mdb";

            try
            {
                connection.Open();
                
            }
            catch 
            {
                MessageBox.Show("L'application ne trouve pas la base de données.Veuillez specifier le chemin vers la base de données");
            }         

           // MessageBox.Show("base ouverte");
            commande.Connection = connection;
            
        }

        public object Select(string Requete)
        {
            commande.CommandText = Requete;
            // commande.Connection = connection;
            object li = (object)commande.ExecuteScalar();
            return li;
        }
        public void Requete_Void(string Requete)
        {
            commande.CommandText = Requete;
            // commande.Connection = connection;
            commande.ExecuteNonQuery();

        }

        public DataTable Visualiser(string Table, string Champ, string Condition)
        {
            adapter.SelectCommand = connection.CreateCommand();
            adapter.SelectCommand.CommandText = string.Format("select {0} from {1} where {2}", Champ, Table, Condition);
            adapter.Fill(table);
            //con.Close();
            return table;
        }

        public DataTable Visualiser(string Requete)
        {
            adapter.SelectCommand = connection.CreateCommand();
            adapter.SelectCommand.CommandText = Requete;
            adapter.Fill(table);
            //con.Close();
            return table;
        }
          public DataTable VisualiserParam()
        {
            adapter.SelectCommand = connection.CreateCommand();
            adapter.SelectCommand.CommandText = "Select * from Payement where Date_Payement between 1/01/2016 and 25/01/2016";
              //commande.Parameters.Add(new SqlParameter("@Date_Creation", dateTimePicker1.Value));
            adapter.Fill(table);
            //con.Close();
            return table;
        }
       

        public void Insert(string table, string GroupeChamp, int NbreChamp, object[] valeur)
        {
            int j = 1;
            string parametres = "@param1";
            while (j < NbreChamp)
            {
                parametres = parametres + ",@param" + (j + 1);  //correspond a  string parametres="@param1,@param2,@param3.....";
                j++;

            }

            commande.CommandText = string.Format("insert into {0} ({1}) values ({2}) ", table, GroupeChamp, parametres);
            for (int i = 0; i < NbreChamp; i++)
            {
                commande.Parameters.Add(new OleDbParameter("@param" + (i + 1), valeur[i]));
            }

            //commande.Connection = connection;
            commande.ExecuteNonQuery();
            commande.Parameters.Clear();
        }

        //public void Update(string table, string ChampAmettreAjour, object NvelleValeur, string Condition)
        //{

        //    commande.CommandText = string.Format("update {0} set {1}= @param  where {2}", table, ChampAmettreAjour, Condition);
        //    commande.Parameters.Add(new MySqlParameter("@param", NvelleValeur));

        //    // commande.Connection = connection;
        //    commande.ExecuteNonQuery();
        //    commande.Parameters.Clear();
        //}
    }
}
