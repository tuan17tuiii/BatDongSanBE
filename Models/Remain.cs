using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class Remain
{
    public int Id { get; set; }

    public int? IdUser { get; set; }

    public int? IdAdv { get; set; }

    public int? Remaining { get; set; }

    public DateTime Createdend { get; set; }

    public virtual Advertisement? IdAdvNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}
