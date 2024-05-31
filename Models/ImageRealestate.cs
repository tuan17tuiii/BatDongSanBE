<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class ImageRealestate
{
    public int Id { get; set; }

    public int? RealestateId { get; set; }

    public string UrlImage { get; set; } = null!;

    public int? Newsid { get; set; }

    public virtual News? News { get; set; }

    public virtual Realestate? Realestate { get; set; }
}
=======
﻿using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class ImageRealestate
{
    public int Id { get; set; }

    public int? RealestateId { get; set; }

    public string UrlImage { get; set; } = null!;

    public int? Newsid { get; set; }

    public virtual News? News { get; set; }

    public virtual Realestate? Realestate { get; set; }
}
>>>>>>> 4800974bf50f7deef1b2e6627bc174e7390dae23
