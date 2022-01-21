using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data.SqlClient;
using System.Text;

namespace ServicePegawaiPAT
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string CreatePegawai(Pegawai pgw)
        {
            string msg = "GAGAL";
            SqlConnection sqlcon = new SqlConnection("Data Source=LAPTOP-07EGJ8M5\\SQLEXPRESS01;Initial Catalog=\"Kelompok\";Persist Security Info=True;User ID=sa;Password=annisa16");
            string query = String.Format("insert into dbo.Pegawai values('{0}', '{1}','{2}','{3}')", pgw.nama, pgw.id_pegawai, pgw.jenis_kelamin, pgw.agama);

            SqlCommand sqlcom = new SqlCommand(query, sqlcon);

            try
            {
                sqlcon.Open();
                Console.WriteLine(query);
                sqlcom.ExecuteNonQuery();
                sqlcon.Close();
                msg = "Sukses";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
                msg = "Gagal";
            }
            return msg;
        }
        public List<Pegawai> GetAllPegawai()
        {
            List<Pegawai> pegewe = new List<Pegawai>();

            SqlConnection con = new SqlConnection("Data Source=LAPTOP-07EGJ8M5\\SQLEXPRESS01;Initial Catalog=\"Kelompok\";Persist Security Info=True;User ID=sa;Password=annisa16");
            string query = "select nama, id_pegawai, jenis_kelamin, agama from dbo.Pegawai";
            SqlCommand com = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Pegawai pgw = new Pegawai();
                    pgw.nama = reader.GetString(0);
                    pgw.id_pegawai = reader.GetString(1);
                    pgw.jenis_kelamin = reader.GetString(2);
                    pgw.agama = reader.GetString(3);

                    pegewe.Add(pgw);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
            }
            return pegewe;
        }
        public Pegawai GetPegawaiByid_pegawai(string id_pegawai)
        {
            Pegawai pgw = new Pegawai();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-07EGJ8M5\\SQLEXPRESS01;Initial Catalog=\"Kelompok\";Persist Security Info=True;User ID=sa;Password=annisa16");
            string query = String.Format("select  nama, id_pegawai, jenis_kelamin, agama from dbo.Pegawai where id_pegawai = '{0}'", id_pegawai);
            SqlCommand com = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    pgw.nama = reader.GetString(0);
                    pgw.id_pegawai = reader.GetString(1);
                    pgw.jenis_kelamin = reader.GetString(2);
                    pgw.agama = reader.GetString(3);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
            }
            return pgw;
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
