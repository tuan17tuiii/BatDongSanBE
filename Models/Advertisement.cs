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
>>>>>>> 4a1c9cffabd6c42272d71d3c52d10cdbcba1bc0b
