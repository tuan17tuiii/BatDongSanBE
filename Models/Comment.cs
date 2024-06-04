<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? BatdongsanId { get; set; }

    public string? Content { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public virtual User? User { get; set; }
}
=======
﻿using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? BatdongsanId { get; set; }

    public string? Content { get; set; }

    public DateOnly? CreatedAt { get; set; }

    public virtual User? User { get; set; }
}
>>>>>>> ba65ba174d7a7e9bf726f0ca6c072c7375676028
