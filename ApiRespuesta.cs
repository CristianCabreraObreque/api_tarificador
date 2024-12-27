public class ApiResuesta
{
  public bool Exito { get; set; }
  public string? Message { get; set; }
  public object? Data { get; set; }

  public static ApiResuesta CrearRespuesta(bool exito, string? message, object? data)
  {
    return new ApiResuesta
    {
      Exito = exito,
      Message = message,
      Data = data
    };
  }
}