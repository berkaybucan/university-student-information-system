using System;
using System.Collections.Generic;

namespace ObsWepApp.Models;

public partial class Ogrenci
{
    public int OgrenciId { get; set; }

    public int BolumId { get; set; }

    public string OgrenciNo { get; set; } = null!;

    public int DurumId { get; set; }

    public DateTime KayitTarihi { get; set; }

    public DateTime? AyrilmaTarihi { get; set; }

    public string Adi { get; set; } = null!;

    public string Soyadi { get; set; } = null!;

    public string Tcno { get; set; } = null!;

    public int? CinsiyetId { get; set; }

    public DateTime DogumTarihi { get; set; }

    public int KullaniciId { get; set; }
}
