using System;
using System.Collections.Generic;

namespace ObsWepApp.Models;

public partial class OgretimElemani
{
    public int OgrElmId { get; set; }

    public int BolumId { get; set; }

    public string KurumSicilNo { get; set; } = null!;

    public int UnvanId { get; set; }

    public string Adi { get; set; } = null!;

    public string Soyadi { get; set; } = null!;

    public string TckimlikNo { get; set; } = null!;

    public int CinsiyetId { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public int KullaniciId { get; set; }
}
