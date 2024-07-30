using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Produto.ADO_NET.UnidadeTerra.Proxy
{
    internal class DbSet<T> where T : class, new()
    {
        private readonly SqlConnection _connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EstoqueDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        private string GetColumns(IEnumerable<PropertyInfo> properties)
        {
            return string.Join(",", properties.Select(p => p.Name));
        }

        private string GetParameters(IEnumerable<PropertyInfo> properties)
        {
            return string.Join(",", properties.Select(p => "@" + p.Name));
        }

        private void AddParameters(SqlCommand command, IEnumerable<PropertyInfo> properties, T entity) 
        {
            foreach (var property in properties)
            {
                var value = property.GetValue(entity) ?? DBNull.Value;
                command.Parameters.AddWithValue("@" + property.Name, value);
            }

            return;
        }

        public IEnumerable<T> ToList()
        {
            _connection.Open();
            string sql = $"SELECT * FROM {typeof(T).Name}";
            SqlCommand command = new SqlCommand(sql, _connection);
            var entities = new List<T>();

            using SqlDataReader reader = command.ExecuteReader();

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            while (reader.Read())
            { 
                var entity = new T();

                foreach(var property in properties)
                {
                    var column = property.Name;

                    property.SetValue(entity, Convert.ChangeType(reader[column], property.PropertyType));
                }

                entities.Add(entity);
                
            }
            _connection.Close();
            return entities;
        }

        public int Create(T entity)
        {
            _connection.Open();

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(prop => prop.Name != "Id");
            var columns = GetColumns(properties);
            var parameters = GetParameters(properties);

            string sql = $"INSERT INTO {typeof(T).Name} ({columns}) VALUES ({parameters})";

            SqlCommand command = new SqlCommand(sql, _connection);

            AddParameters(command, properties, entity);

            int result = command.ExecuteNonQuery();
            _connection.Close();

            return result;
        }

        public int Update(T entity)
        {
            _connection.Open();
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(prop => prop.Name != "Id");
            var columns = GetColumns(properties);
            var parameters = GetParameters(properties);

            string setClause = string.Join(",", properties.Select(p => $" {p.Name} = @{p.Name}"));

            string sql = $"UPDATE {typeof(T).Name} SET{setClause} WHERE Id = @Id";

            SqlCommand command = new SqlCommand(sql, _connection);

            AddParameters(command, properties, entity);

            PropertyInfo idProperty = typeof(T).GetProperty("Id")!;
            command.Parameters.AddWithValue("@Id", idProperty.GetValue(entity));
            int result = command.ExecuteNonQuery();
            _connection.Close();

            return result;
        }

        public int Delete(int Id)
        {
            _connection.Open();

            string sql = $"DELETE FROM {typeof(T).Name} WHERE Id = @Id";
            SqlCommand command = new SqlCommand(sql, _connection);
            command.Parameters.AddWithValue("@Id", Id);
            int result = command.ExecuteNonQuery();

            _connection.Close();
            return result;
        }

    }
}
