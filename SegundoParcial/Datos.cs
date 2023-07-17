using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial
{
    public static class Datos
    {
        public static void CrearRegistro(AgendaModel model)
        {
            string query = $"insert into dbo.Agenda(Nombre, Apellido, Direccion, FechaNacimiento, Celular) values(@Nombre, @Apellido, @Direccion, @FechaNacimiento, @Celular)";

            using (SqlConnection con = new SqlConnection("Data source=PC\\VVV;initial catalog=Agenda;User iD=sa;Password=123456"))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nombre", model.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", model.Apellido);
                cmd.Parameters.AddWithValue("@Direccion", model.Direccion);
                cmd.Parameters.AddWithValue("@FechaNacimiento", model.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Celular", string.IsNullOrWhiteSpace(model.Celular) ? null : model.Celular);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public static List<AgendaModel> GetList()
        {
            var result = new List<AgendaModel>();
            string query = $"select * from dbo.Agenda";

            AgendaModel model = null;
            try
            {
                using (SqlConnection con = new SqlConnection("Data source=PC\\VVV;initial catalog=Agenda;User iD=sa;Password=123456"))
                {
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model = reader.GetModel<AgendaModel>();
                            result.Add(model);
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception e)
            {
            }
            return result;
        }

        public static void Eliminar(string celular)
        {
            string query = $"delete dbo.Agenda where Celular = '{celular}'";

            using (SqlConnection con = new SqlConnection("Data source=PC\\VVV;initial catalog=Agenda;User iD=sa;Password=123456"))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //terminar
        public static void EditarAgenda(AgendaModel model, string celular)
        {

            try
            {
                if (celular != "")
                {
                    string query = $"update dbo.Agenda set Nombre = '{model.Nombre}', Apellido = '{model.Apellido}', Direccion = '{model.Direccion}', FechaNacimiento = '{model.FechaNacimiento:yyyy-MM-dd}', Celular='{model.Celular}' where Celular = '{celular}'";


                    using (SqlConnection con = new SqlConnection("Data source=PC\\VVV;initial catalog=Agenda;User iD=sa;Password=123456"))
                    {
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        public static T GetModel<T>(this SqlDataReader reader) where T : class
        {
            T model = Activator.CreateInstance<T>();

            foreach (var item in typeof(T).GetProperties().Where(p => p.CanWrite && p.GetCustomAttributes(typeof(ColumnSqlAttribute), false).Any()))
            {
                var column = item.GetCustomAttributes(typeof(ColumnSqlAttribute), false).FirstOrDefault() as ColumnSqlAttribute;

                if (item.PropertyType == typeof(string))
                    item.SetValue(model, Convert.ToString(reader[column.NameColumn]));
                else if (item.PropertyType == typeof(DateTime))
                    item.SetValue(model, Convert.ToDateTime(reader[column.NameColumn] is DBNull ? DateTime.Now : reader[column.NameColumn]));
                else if (item.PropertyType == typeof(double))
                    item.SetValue(model, Convert.ToDouble(reader[column.NameColumn] is DBNull ? 0 : reader[column.NameColumn]));
                else if (item.PropertyType == typeof(int))
                    item.SetValue(model, Convert.ToInt32(reader[column.NameColumn] is DBNull ? 0 : reader[column.NameColumn]));

                EvaluateDateTime<T>(item, reader, column, model);
            }

            return model;
        }

        private static void EvaluateDateTime<T>(PropertyInfo item, SqlDataReader reader, ColumnSqlAttribute column, T model)
        {
            if (item.PropertyType == typeof(DateTime?))
            {
                if (reader[column.NameColumn] is DBNull)
                {
                    //
                }
                else
                    item.SetValue(model, Convert.ToDateTime(reader[column.NameColumn]));
            }
        }
    }

    public class ColumnSqlAttribute : Attribute
    {
        public string NameColumn { get; set; }

        public ColumnSqlAttribute(string nameColumn)
        {
            NameColumn = nameColumn;
        }
    }
}
