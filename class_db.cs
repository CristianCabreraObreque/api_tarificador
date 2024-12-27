using System.Data;
using Microsoft.Data.SqlClient;

public class ClassDb : IDisposable
{
  private Config c = new();
  private SqlConnection Conexion = new();
  private SqlCommand cmd = new();

  public ClassDb(string nombre)
  {
    StringConexion(BuscarConexion(nombre));
  }

  public string BuscarConexion(string nombreConexion)
  {
    return c.leer["ConnectionStrings:" + nombreConexion]?.ToString() ?? string.Empty;
  }

  public void StringConexion(string strConexion)
  {
    Conexion = new SqlConnection(strConexion);
    // Configurar la conexión para usar SSL
    SqlConnectionStringBuilder builder = new(strConexion)
    {
      Encrypt = true, // Habilita la encriptación SSL/TLS
      TrustServerCertificate = true, // Confía en el servidor automáticamente
      ApplicationIntent = ApplicationIntent.ReadWrite // Para aplicaciones que escriben datos
    };
    Conexion.ConnectionString = builder.ConnectionString;
  }

  public void Conectar()
  {
    if (Conexion.State == ConnectionState.Closed)
      Conexion.Open();
  }

  public void Desconectar()
  {
    if (Conexion.State != ConnectionState.Closed)
      Conexion.Close();
  }

  public SqlDataReader Ej_SP_DataSet(string Nombre)
  {
    cmd.CommandTimeout = 300;
    cmd.Connection = Conexion;
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.CommandText = Nombre;
    SqlDataReader resultado = cmd.ExecuteReader();
    return resultado;
  }

  public void Ej_SP_NoDataSet(string Nombre)
  {
    cmd.CommandTimeout = 300;
    cmd.Connection = Conexion;
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.CommandText = Nombre;
    cmd.ExecuteNonQuery();
  }

  public SqlDataReader EjSQL_DataSet(string Sql)
  {
    cmd.CommandTimeout = 300;
    cmd.Connection = Conexion;
    cmd.CommandType = CommandType.Text;
    cmd.CommandText = Sql;
    SqlDataReader resultado = cmd.ExecuteReader();
    return resultado;
  }

  public void Agregar_Param(string Nombre,
                           SqlDbType Tipo,
                           int Largo,
                           ParameterDirection Direccion,
                           object Valor)
  {
    SqlParameter Parametro = new SqlParameter
    {
      ParameterName = Nombre,
      SqlDbType = Tipo,
      Size = Largo,
      Direction = Direccion,
      Value = Valor
    };
    cmd.Parameters.Add(Parametro);
  }

  public object LeerParametro(string Nombre)
  {
    return cmd.Parameters[Nombre].Value;
  }

  public void QuitarParametros()
  {
    cmd.Parameters.Clear();
  }

  #region IDisposable Support
  private bool disposedValue = false;

  protected virtual void Dispose(bool disposing)
  {
    if (!disposedValue)
    {
      if (disposing)
      {
        Conexion.Dispose();
        cmd.Dispose();
      }

      disposedValue = true;
    }
  }

  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }
  #endregion
}
