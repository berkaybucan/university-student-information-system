﻿using System;
using System.Collections.Generic;

namespace ObsWepApp.Models;

public partial class Sinav
{
    public int SinavId { get; set; }

    public int DersAcmaId { get; set; }

    public int SinavTuruId { get; set; }

    public int EtkiOrani { get; set; }

    public DateTime SinavTarihi { get; set; }

    public TimeSpan SinavSaati { get; set; }

    public int DerslikId { get; set; }

    public int OgrElmId { get; set; }
}
