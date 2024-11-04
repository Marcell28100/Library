using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Library.Models;

public partial class Mark
{
    public Guid Id { get; set; }

    public int? MarkNumber { get; set; }

    public string? MarkText { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedTime { get; set; }

    public DateTime? UpdatedTime { get; set; }

    public Guid StudentId { get; set; }
    [JsonIgnore]
    public virtual Student? Student { get; set; }
}
