<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class Advertisement
{
    public int Id { get; set; }

    public string? AdvertisementName { get; set; }

    public double? Price { get; set; }

    public string? Describe { get; set; }

    public DateOnly? Time { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
=======
﻿using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class Advertisement
{
    public int Id { get; set; }

    public string? AdvertisementName { get; set; }

    public int? Price { get; set; }

    public int? Quantitydate { get; set; }

    public DateOnly? Time { get; set; }

    public bool? Status { get; set; }

    public int? Quantitynews { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
>>>>>>> ba65ba174d7a7e9bf726f0ca6c072c7375676028
