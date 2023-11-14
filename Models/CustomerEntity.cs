﻿using System;
using System.Collections.Generic;

namespace Examen.Models;

public partial class CustomerEntity
{
    public Guid DocumentNumber { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Age { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public bool Estado { get; set; }

    public DateTime DateC { get; set; }

    public virtual ICollection<BookingEntity> BookingEntity { get; set; } = new List<BookingEntity>();
}
