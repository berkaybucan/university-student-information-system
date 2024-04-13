using System;
using System.Collections.Generic;

namespace ObsWepApp.Models;

public partial class Kullanici
{
    public int KullaniciId { get; set; }

    public string KullaniciAdi { get; set; } = null!;

    public string Parola { get; set; } = null!;

    public int KullaniciTuruId { get; set; }
}
