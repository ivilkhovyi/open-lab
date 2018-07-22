using LinqToDB;
using System.Linq;

namespace UI.Classes
{
    public class DbConnection : LinqToDB.Data.DataConnection
    {
        public DbConnection() : base("laboratory") { }

        public void CreateTableIfNotExists<T>()
        {
            var sp = this.DataProvider.GetSchemaProvider();
            var dbSchema = sp.GetSchema(this);
            if (!dbSchema.Tables.Any(t => t.TableName == typeof(T).Name))
            {
                this.CreateTable<T>();
            }
        }

        public ITable<T> GetTableAndCreateIfNotExists<T>() where T : class
        {
            CreateTableIfNotExists<T>();
            return GetTable<T>();
        }
    }
}
