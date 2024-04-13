using System;
using System.Collections.Generic;

namespace ObsWepApp.Models;

public partial class Mufredat
{
    public int MufredatId { get; set; }

    public int BolumId { get; set; }

    public int DersId { get; set; }

    public int AkademikYilId { get; set; }

    public int AkademikDonemId { get; set; }

    public int DersDonemi { get; set; }
}
