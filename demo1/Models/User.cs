using System;
using System.Collections.Generic;

namespace demo1.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public string? Position { get; set; }

    public DateTime Created { get; set; }
}
