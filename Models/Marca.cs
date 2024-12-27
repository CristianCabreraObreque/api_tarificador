using System.Data;
using Microsoft.Data.SqlClient;

namespace api_tarificador.Models
{
  public class Marca
  {
    public int? id_marca { get; set; }
    public string? marca { get; set; }
    public string? rut_usuario { get; set; }
    public bool? estado { get; set; }

    public ApiResuesta ObtenerMarca()
    {
      try
      {
        using ClassDb db = new("BDTarifa");
        db.Conectar();

        SqlDataReader r = db.Ej_SP_DataSet("sp_tar_marca_list");
        var data = P.SqlDataReaderToJson(r);
        db.Desconectar();
        return ApiResuesta.CrearRespuesta(true, "ok", data);
      }
      catch (Exception ex)
      {
        //var res = "Error al obtener Marcas";
        var res = $"Error al obtener Marcas: {ex.Message}";
        return ApiResuesta.CrearRespuesta(false, res, null);
      }
    }

    public ApiResuesta InsertarMarca()
    {
      try
      {

        using ClassDb db = new("BDTarifa");
        db.Conectar();
        db.Agregar_Param("@rut_usuario", SqlDbType.VarChar, 10, ParameterDirection.Input, rut_usuario!);
        db.Agregar_Param("@marca", SqlDbType.VarChar, 64, ParameterDirection.Input, marca!);
        db.Agregar_Param("@estado", SqlDbType.Bit, 1, ParameterDirection.Input, estado!);
        SqlDataReader r = db.Ej_SP_DataSet("sp_tar_marca_ins");
        r.Read();
        string salida = P.ToString(r["salida"]);
        bool res = salida == "ok";
        db.Desconectar();
        return ApiResuesta.CrearRespuesta(res, salida, null);
      }
      catch (Exception ex)
      {
        //var res = "Error al insertar marca";
        var res = $"Error al insertar marca: {ex.Message}";
        return ApiResuesta.CrearRespuesta(false, res, null);
      }
    }


    public ApiResuesta ActualizarMarca()
    {
      try
      {

        using ClassDb db = new("BDTarifa");
        db.Conectar();
        db.Agregar_Param("@rut_usuario", SqlDbType.VarChar, 10, ParameterDirection.Input, rut_usuario!);
        db.Agregar_Param("@id_marca", SqlDbType.Int, 1, ParameterDirection.Input, id_marca!);
        db.Agregar_Param("@marca", SqlDbType.VarChar, 64, ParameterDirection.Input, marca!);
        db.Agregar_Param("@estado", SqlDbType.Bit, 1, ParameterDirection.Input, estado!);
        SqlDataReader r = db.Ej_SP_DataSet("sp_tar_marca_upd");
        r.Read();
        string salida = P.ToString(r["salida"]);
        bool res = salida == "ok";
        db.Desconectar();
        return ApiResuesta.CrearRespuesta(res, salida, null);
      }
      catch (Exception ex)
      {
        //var res = "Error al modificar marca";
        var res = $"Error al modificar marca: {ex.Message}";
        return ApiResuesta.CrearRespuesta(false, res, null);
      }
    }


  }
}
