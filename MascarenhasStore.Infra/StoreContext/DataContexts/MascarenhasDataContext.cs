using MascarenhasStore.Shared;
using System.Data.SqlClient;
using System.Data;

namespace MascarenhasStore.Infra.StoreContext.DataContexts {
    public class MascarenhasDataContext : IDisposable {
         public SqlConnection Connection { get; set; }

        public MascarenhasDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
