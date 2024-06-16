﻿using SGT.Domain.Entities.Common;

namespace SGT.Domain.Entities;

public class Category : BaseEntity
{

    public string Name { get; set; }
    public ICollection<Blog> Blogs { get; set; }
}