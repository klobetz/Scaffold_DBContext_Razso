using System;
using System.Collections.Generic;

namespace BlazorApp.Model;

public partial class Kutya
{
    public int Id { get; set; }

    public string? Kutyanev { get; set; }

    public int? GazdinevId { get; set; }

    public int? KutyafajtaId { get; set; }

    public virtual Kutyatulajdono? Gazdinev { get; set; }

    public virtual Kutyafajtum? Kutyafajta { get; set; }
}
