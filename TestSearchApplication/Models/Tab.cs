using System;
using System.Collections.Generic;

namespace TestSearchApplication.Models;

public partial class Tab
{
    public int? Id { get; set; }

    public int Mno { get; set; }

    public string? MhNass { get; set; }

    public string? Nassx { get; set; }

    public int? Musnad { get; set; }

    public bool? Mtn { get; set; }

    public bool? Tmam { get; set; }
}
