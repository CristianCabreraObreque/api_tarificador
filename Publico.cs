using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;


public class P
{
  public static decimal ToDecimal(object n)
  {
    try
    {
      if (n == DBNull.Value)
        return 0;
      else
        return Convert.ToDecimal(n);
    }
    catch
    {
      return 0;
    }
  }

  public static double ToDouble(object n)
  {
    try
    {
      if (n == DBNull.Value)
        return 0;
      else
        return Convert.ToDouble(n);
    }
    catch
    {
      return 0;
    }
  }
  public static Int32 ToInt32(object n)
  {
    try
    {
      if (n == DBNull.Value)
        return 0;
      else
        return Convert.ToInt32(n);
    }
    catch
    {
      return 0;
    }
  }

  public static string ToString(object n)
  {
    try
    {
      if (n == DBNull.Value)
        return "";
      else
        return Convert.ToString(n)!;
    }
    catch
    {
      return "";
    }
  }

  public static bool ToBool(object n)
  {
    try
    {
      if (n == DBNull.Value)
        return false;
      else
        return Convert.ToBoolean(n);

    }
    catch
    {
      return false;
    }
  }

  public static DateTime ToDateTime(object n)
  {
    try
    {
      if (n == DBNull.Value)
        return new DateTime(1900, 01, 01);
      else
        return Convert.ToDateTime(n);

    }
    catch
    {
      return new DateTime(1900, 01, 01);
    }
  }


  public static string SqlDataReaderToJson(SqlDataReader r)
  {
    var dataTable = new DataTable();
    try
    {
      dataTable.Load(r);
    }
    catch (Exception ex)
    {
      return ex.Message;
    }
    return Newtonsoft.Json.JsonConvert.SerializeObject(dataTable);
  }









}