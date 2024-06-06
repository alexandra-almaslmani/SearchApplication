using System;
using System.Collections.Generic;

namespace TestSearchApplication.Models;

public partial class B010105
{
    public int? Id { get; set; }

    public double? Tno { get; set; }

    public int? Mno { get; set; }

    public string? Nass { get; set; }

    public string? Nassx { get; set; }

    public int? Part { get; set; }

    public int? Page { get; set; }

    public int? Hno { get; set; }

    public string? TabNo { get; set; }

    public virtual Tab? MnoNavigation { get; set; }
}
