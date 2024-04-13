using System;
using System.Collections.Generic;

namespace ObsWepApp.Models;

public partial class Bolum
{
    public int BolumId { get; set; }

    public string BolumAdi { get; set; } = null!;

    public int ProgramTuruId { get; set; }

    public int OgretimTuruId { get; set; }

    public int OgrenimDiliId { get; set; }

    public string? WebAdresi { get; set; }
}
