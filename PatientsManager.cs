using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace testovoe
{
    public class PatientsManager
    {
        private string connectionString = DB.ConnectionString;


        public void InsertZlList(int num_e, int num_zg)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string sql = $"INSERT INTO ZL__LIST(Num_event, Num_zglv) VALUES " +
                $"('{num_e}', '{num_zg}')";

            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            connection.Close();

        }




        public void InsertZGLV(string num_ver, DateTime date, string filename, int year, string Code_mo )
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string sql = $"INSERT INTO ZGLV(Numversion, Data_Zglv, Filename, Year, Code_mo) VALUES " +
                $"(N'{num_ver}', '{date.ToString("yyyy-MM-dd HH:mm:ss.fff")}', N'{filename}', '{year}',N'{Code_mo}')";

            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }





        public int SelectIdZGLV()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string sql = "SELECT MAX(Id_zglv) FROM ZGLV";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            int IdZGLV;
            if (!reader.HasRows)
            {
                IdZGLV = 1;
            }
            else
            {
                reader.Read();
                IdZGLV = MyIntonverter(reader[0]);
            }
            reader.Close();

            connection.Close();

            return IdZGLV;
        }




        public void InsertCONTACTS(int id, string phF,  string phM, string email, string address)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string sql = $"INSERT INTO CONTACTS(Id_contacts, Phone_f, Phone_m, Email, Address) VALUES " +
                $"('{id}', N'{phF}', N'{phM}',  N'{email}', N'{address}')";


            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            connection.Close();  
        }


        public int SelectIdContacts()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string sql = "SELECT MAX(Id_contacts) FROM CONTACTS";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            int idContacts;
            if (!reader.HasRows)
            {
                idContacts = 1;
            }
            else
            {
                reader.Read();
                idContacts = MyIntonverter(reader[0]) + 1;
            }
            reader.Close();
            return idContacts;
        }


        public void InsertPERS1(ZL__LIST ZL__)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            int g = 0;
            List<EVENT> eVENTs = ZL__.Num_event;

            foreach(EVENT ev in eVENTs)
            {
                int Num_event = SelectNumEvent();


                List<PERS> ps = ev.Pers;
                foreach(PERS pERS in ps)
                {

                    int con = SelectIdContacts();


                    if ((pERS.Contacts == null))
                    {
                        g++;
                        string sql = $"INSERT INTO PERS(N_zap, Id_pac, W, Dr, Smo, Vpolis, Spolis, Npolis,  Quarter, Month, Lpu1, Depth, Ss_Doc, Ss_Doc_D, Prvs_D," +
                           $"Ds_D, Place_D, Id_Tfoms, Comment) VALUES " +
                           $"('{pERS.N_zap}', N'{pERS.Id_pac}','{pERS.W}','{pERS.Dr.ToString("yyyy-MM-dd HH:mm:ss.fff")}', N'{pERS.Smo}', '{pERS.Vpolis}',N'{pERS.Spolis}',N'{pERS.Npolis}', " +
                           $"'{pERS.Quarter}', '{pERS.Month}',N'{pERS.Lpu1}',N'{pERS.Depth}',N'{pERS.Ss_Doc}',N'{pERS.Ss_Doc_D}', '{pERS.Prvs_D}',N'{pERS.Ds_D}', '{pERS.Place_D}',N'{pERS.Id_Tfoms}',N'{pERS.Comment}')";


                        SqlCommand command = new SqlCommand(sql, connection);
                        command.ExecuteNonQuery();
                    }
                    else

                    {
                        InsertCONTACTS(con, pERS.Contacts.Phone_f, pERS.Contacts.Phone_m, pERS.Contacts.Email, pERS.Contacts.Address); ;


                        string sql = $"INSERT INTO PERS(N_zap, Id_pac, W, Dr, Smo, Vpolis, Spolis, Npolis, Contacts, Quarter, Month, Lpu1, Depth, Ss_Doc, Ss_Doc_D, Prvs_D," +
                            $"Ds_D, Place_D, Id_Tfoms, Comment) VALUES " +
                            $"('{pERS.N_zap}', N'{pERS.Id_pac}','{pERS.W}','{pERS.Dr.ToString("yyyy-MM-dd HH:mm:ss.fff")}', N'{pERS.Smo}', '{pERS.Vpolis}',N'{pERS.Spolis}',N'{pERS.Npolis}', {con}," +
                            $"'{pERS.Quarter}', '{pERS.Month}',N'{pERS.Lpu1}',N'{pERS.Depth}',N'{pERS.Ss_Doc}',N'{pERS.Ss_Doc_D}', '{pERS.Prvs_D}',N'{pERS.Ds_D}', '{pERS.Place_D}',N'{pERS.Id_Tfoms}',N'{pERS.Comment}')";


                        SqlCommand command = new SqlCommand(sql, connection);
                        command.ExecuteNonQuery();
                    }

                    int IdPers = SelectIdPers();

                    InsertEVENT(Num_event, ev.Disp, ev.Num_m, ev.Num_w, IdPers);


                    int IdZGLV = SelectIdZGLV();
                    int IdEvent = SelectIdEvent();
                    InsertZlList(IdEvent, IdZGLV);
                }
           }

            connection.Close();
        }



        public int SelectIdPers()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string sql = "SELECT MAX(Id_pers) FROM PERS";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            int IdPers;
            if (!reader.HasRows)
            {
                IdPers = 1;
            }
            else
            {
                reader.Read();
                IdPers = MyIntonverter(reader[0]);
            }
            reader.Close();

            connection.Close();

            return IdPers;
        }


        public int SelectNumEvent()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string sql = "SELECT MAX(Num_event) FROM EVENT";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            int IdEvent;
            if (!reader.HasRows)
            {
                IdEvent = 1;
            }
            else
            {
                reader.Read();
                IdEvent = MyIntonverter(reader[0]) + 1;
            }
            reader.Close();

            connection.Close();

            return IdEvent;
        }



        public void InsertEVENT(int numEvent, string disp, int num_m, int num_w, int pers)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string sql = $"INSERT INTO EVENT(Num_event, Disp, Num_m, Num_w, Pers) VALUES " +
                $"('{numEvent}', N'{disp}', N'{num_m}',  N'{num_w}', N'{pers}')";


            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }


        public int SelectIdEvent()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string sql = "SELECT MAX(Id_event) FROM EVENT";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            int IdEvent;
            if (!reader.HasRows)
            {
                IdEvent = 1;
            }
            else
            {
                reader.Read();
                IdEvent = MyIntonverter(reader[0]);
            }
            reader.Close();

            connection.Close();

            return IdEvent;
        }



        public static int MyIntonverter(object o)
        {
            if (o == DBNull.Value || o == null)
                return 0;

            return Convert.ToInt32(o);
        }


        public static string MyStringConverter(object o)
        {
            if (o == DBNull.Value || o == null)
                return "";

            return o.ToString();
        }




        public List<ZL__LIST> GetAll()
        {
            List<ZL__LIST> childs = new List<ZL__LIST>();

            SqlConnection connection = new SqlConnection(connectionString);
            string sql = @"SELECT  Z.Id_list, Z.Num_event, Z.Num_zglv, e.Disp, e.Num_m, e.Num_w, P.N_zap, P.Id_pac, P.W, P.Dr, P.Smo, P.Vpolis, P.Spolis, P.Npolis, P.Contacts,
                           P.Quarter, P.Month, P.Lpu1, P.Depth, P.Ss_Doc, P.Ss_Doc_D, P.Prvs_D, P.Ds_D, P.Place_D, C.Phone_f, C.Phone_m, C.Email, C.Address,
                           ZL.Numversion, ZL.Data_Zglv, ZL.Filename, ZL.Year, ZL.Code_mo
                            FROM ZL__LIST as Z
                          LEFT JOIN   EVENT  as e  ON e.Id_event= Z.Num_event
                          LEFT JOIN PERS as P ON P.Id_pers=e.Pers
                          LEFT JOIN CONTACTS as C ON C.Id_contacts=P.Contacts
                          left join ZGLV as ZL ON ZL.Id_zglv=Z.Num_zglv";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                int id1 = reader.GetInt32(1);
                int id2 = reader.GetInt32(2);


                List<EVENT> classes = GetEvents(id1);


                ZL__LIST c = new ZL__LIST(id, classes);

                childs.Add(c);
            }

            reader.Close();
            connection.Close();

            return childs;
        }




        private List<EVENT> GetEvents(int num)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = $"SELECT " +
                $"e.Id_event, " +
                $"e.Num_event, " +
                $"e.Disp, " +
                $"e.Num_m, " +
                $"e.Num_w, " +
                $"e.Pers " +
                "FROM ZL__LIST as Z "+
                         "LEFT JOIN  EVENT as e  ON   Z.Num_event=e.Id_event";


            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<EVENT> classes = new List<EVENT>();
            while (reader.Read())
            {
                EVENT class_ = new EVENT(
                    reader.GetInt32(0),
                    MyIntonverter(reader[1]),
                    MyStringConverter(reader[2]),
                    MyIntonverter(reader[3]),
                    MyIntonverter(reader[4]));

                classes.Add(class_);
            }

            reader.Close();
            connection.Close();

            return classes;
        }

    }
}
