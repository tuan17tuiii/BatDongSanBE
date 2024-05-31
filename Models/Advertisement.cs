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

    public double? Price { get; set; }

    public string? Describe { get; set; }

    public DateOnly? Time { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
>>>>>>> 4800974bf50f7deef1b2e6627bc174e7390dae23
