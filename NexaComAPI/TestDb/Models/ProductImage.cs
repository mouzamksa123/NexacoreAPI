using System;
using System.Collections.Generic;

namespace TestDb.Models;

public partial class ProductImage
{
    public int ImageId { get; set; }

    public int ProductId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public bool IsPrimary { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    public virtual Product Product { get; set; } = null!;
}
