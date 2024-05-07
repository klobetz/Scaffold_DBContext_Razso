using System;
using System.Collections.Generic;

namespace BlazorApp.Model;

public partial class Kutyafajtum
{
    public int Id { get; set; }

    public string Fajta { get; set; } = null!;

    public virtual ICollection<Kutya> Kutyas { get; set; } = new List<Kutya>();
}
