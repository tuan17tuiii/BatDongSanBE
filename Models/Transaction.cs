﻿using System;
using System.Collections.Generic;

namespace BatDongSan.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public int? BuyerId { get; set; }

    public int? SellerId { get; set; }

    public string? TransactionType { get; set; }

    public DateOnly? TransactionDate { get; set; }

    public double? Amount { get; set; }

    public int? IdBatdongsan { get; set; }

    public virtual User? Buyer { get; set; }

    public virtual Batdongsan? IdBatdongsanNavigation { get; set; }

    public virtual User? Seller { get; set; }
}