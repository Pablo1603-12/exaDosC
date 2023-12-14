using System;
using System.Collections.Generic;

namespace pmarnez.DAL;

public partial class Vajilla
{
    public int IdElementoVajilla { get; set; }

    public int CantidadElemento { get; set; }

    public string CodigoElemento { get; set; } = null!;

    public string? DescripcionElemento { get; set; }

    public string? NombreElemento { get; set; }
}
