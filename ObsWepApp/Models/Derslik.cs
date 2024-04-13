using System;
using System.Collections.Generic;

namespace ObsWepApp.Models;

public partial class Derslik
{
    public int DerslikId { get; set; }

    public string DerslikAdi { get; set; } = null!;

    public int DerslikTuruId { get; set; }

    public int Kapasite { get; set; }
}
