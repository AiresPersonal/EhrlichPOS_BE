using System;
using System.Collections.Generic;

namespace EhrlichPOS_BE.Models;

public partial class OrderDetail
{
    public int OrderDetailsId { get; set; }

    public int OrderId { get; set; }

    public string PizzaId { get; set; } = null!;

    public int Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Pizza Pizza { get; set; } = null!;
}
