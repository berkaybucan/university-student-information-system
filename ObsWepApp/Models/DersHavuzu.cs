using System;
using System.Collections.Generic;

namespace ObsWepApp.Models;

public partial class DersHavuzu
{
    public int DersId { get; set; }

    public string DersKodu { get; set; } = null!;

    public string DersAdi { get; set; } = null!;

    public int OgrenimDiliId { get; set; }

    public int DersSeviyesiId { get; set; }

    public int DersTuruId { get; set; }

    public int Teorik { get; set; }

    public int Uygulama { get; set; }

    public float Kredi { get; set; }

    public int Ects { get; set; }
}
