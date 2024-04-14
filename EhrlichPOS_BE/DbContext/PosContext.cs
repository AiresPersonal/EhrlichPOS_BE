using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace EhrlichPOS_BE;

public partial class PosContext : DbContext
{

    public PosContext()
    {
    }

    public PosContext(DbContextOptions<PosContext> options) : base(options)
    {

    }

}


