using System;
using System.Collections.Generic;

namespace ObsWepApp.Models;

public partial class DersAlma
{
    public int DersAlmaId { get; set; }

    public int DersAcmaId { get; set; }

    public int OgrenciId { get; set; }

    public int SecilmeDurumuId { get; set; }
}
