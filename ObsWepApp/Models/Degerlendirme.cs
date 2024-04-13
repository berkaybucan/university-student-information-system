using System;
using System.Collections.Generic;

namespace ObsWepApp.Models;

public partial class Degerlendirme
{
    public int DegerlendirmeId { get; set; }

    public int SinavId { get; set; }

    public int OgrenciId { get; set; }

    public float SinavNotu { get; set; }
}
