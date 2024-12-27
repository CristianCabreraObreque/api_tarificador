class Config
{
  public IConfiguration leer { get; set; }
  public Config()
  {
    leer = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();
  }

  public string Leer(String Seccion)
  {
    return leer[Seccion]!;
  }
}
