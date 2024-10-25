using System;

namespace AtletaApi.Models;

public class Atleta
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public Double Altura { get; set; }
    public Double Peso { get; set; }
}
