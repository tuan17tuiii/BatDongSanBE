<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class News
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? Tag { get; set; }

    public virtual ICollection<ImageRealestate> ImageRealestates { get; set; } = new List<ImageRealestate>();
}
=======
﻿using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class News
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? Tag { get; set; }

    public virtual ICollection<ImageRealestate> ImageRealestates { get; set; } = new List<ImageRealestate>();
}
>>>>>>> 4800974bf50f7deef1b2e6627bc174e7390dae23
