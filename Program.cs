using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            bool info;
            bool ingfo = false;
            getting_data dat = new getting_data();
            operasi op = new operasi();

            if (dat.ExecuteQuery(out info) == true)
            {
                Console.WriteLine("Sukses input data");
            }
            else if (dat.ExecuteQuery(out info) == false)
            {
                Console.WriteLine("Gagal mengambil data");
            }
            if (op.insert(ref ingfo) == true)
            {
                Console.WriteLine("Insert berhasil");
            }
            else if (op.insert(ref ingfo) == false)
            {
                Console.WriteLine("insert gagal");
            }
            if (op.update(ref ingfo) == true)
            {
                Console.WriteLine("Update berhasil");
            }
            else if (op.update(ref ingfo) == false)
            {
                Console.WriteLine("Update gagal");
            }
            if (op.delete(ref ingfo) == true)
            {
                Console.WriteLine("Delete berhasil");
            }
            else if (op.delete(ref ingfo) == false)
            {
                Console.WriteLine("Delete gagal");
            }
        }
    }

    class getting_data
    {
        private static NpgsqlConnection koneksi()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=Smada2jbr_;database=TugasPBOTM;");
        }
        public bool ExecuteQuery(out bool info)
        {
            info = true;
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                string sql = "select * from Brand";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return info;
            }
            catch (Exception)
            {
                info = false;
                return info;
            }
        }
    }

    class operasi
    {
        private static NpgsqlConnection koneksi()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=Smada2jbr_;database=TugasPBOTM;");
        }
        public bool insert(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("insert into Brand(brand_id, nama) values(1, 'So Nice')", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }
        }

        public bool update(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("update Brand set nama = So Nice where brand_id = 2", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }
        }

        public bool delete(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("delete from Brand where brand_id = 1", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }
        }
    }
}
