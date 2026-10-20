/// Author : Raagam Parmar
/// Date   : 18-10-2026

using System;

namespace Noted.Models.Interfaces;

public interface INote
{
    /// <summary>
    /// The title of the note
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// The body of the note
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// Unique identifier of the note
    /// </summary>
    public Guid GetGuid { get; }
}