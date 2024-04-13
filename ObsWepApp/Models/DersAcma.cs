using System;
using System.Collections.Generic;

namespace ObsWepApp.Models;

public partial class DersAcma
{
    public int DersAcmaId { get; set; }

    public int AkademikYilId { get; set; }

    public int AkademikDonemId { get; set; }

    public int MufredatId { get; set; }

    public int Kontenjan { get; set; }

    public int OgrElmId { get; set; }
}
