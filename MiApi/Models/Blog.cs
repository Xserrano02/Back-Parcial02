using System;
using System.Collections.Generic;

namespace MiApi.Models;

public partial class Blog
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Author { get; set; }

    public string? Url { get; set; }

    public int? Likes { get; set; }
}
