﻿using System;
using System.Collections.Generic;

namespace Odev1.Entities;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
