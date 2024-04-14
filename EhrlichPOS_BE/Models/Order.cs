using System;
using System.Collections.Generic;

namespace EhrlichPOS_BE.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime Date { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
