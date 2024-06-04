<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public int? BuyerId { get; set; }

    public int? SellerId { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public double? Amount { get; set; }

    public int? RealestateId { get; set; }

    public virtual User? Buyer { get; set; }

    public virtual Realestate? Realestate { get; set; }

    public virtual User? Seller { get; set; }
}
=======
﻿using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public int? BuyerId { get; set; }

    public int? SellerId { get; set; }

    public DateTime TransactionDate { get; set; }

    public double? Amount { get; set; }

    public int? RealestateId { get; set; }

    public virtual User? Buyer { get; set; }

    public virtual Realestate? Realestate { get; set; }

    public virtual User? Seller { get; set; }
}
>>>>>>> ba65ba174d7a7e9bf726f0ca6c072c7375676028
