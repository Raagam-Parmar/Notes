/// Author : Raagam Parmar
/// Date   : 18-10-2026

using System;

using Noted.Models.Interfaces;

namespace Noted.Models;

public class Note : INote
{
    /// <inheritdoc/>
    public string Title { get; set; } = "";

    /// <inheritdoc/>
    public string Body { get; set; } = "";

    /// <inheritdoc/>
    public Guid GetGuid { get; } = Guid.NewGuid();
}
