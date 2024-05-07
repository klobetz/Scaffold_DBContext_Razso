using System;
using System.Collections.Generic;

namespace BlazorApp.Model;

public partial class Kutyatulajdono
{
    public int Id { get; set; }

    public string Gazdinev { get; set; } = null!;

    public virtual ICollection<Kutya> Kutyas { get; set; } = new List<Kutya>();
}
