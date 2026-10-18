using System.ComponentModel;
using System.Runtime.CompilerServices;

using Noted.Models.Interfaces;

namespace Noted.ViewModels;

/// <summary>
/// Represents a single note selected by the user for editing
/// </summary>
/// <param name="note">The note to view</param>
public partial class SingleNote(INote note) : INotifyPropertyChanged
{
    private readonly INote _note = note;

    public required string Title
    {
        get => _note.Title;
        set
        {
            if (_note.Title == value) return;

            _note.Title = value;
            OnPropertyChanged();
        }
    }

    public required string Body
    {
        get => _note.Body;
        set
        {
            if (_note.Body == value) return;

            _note.Body = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberNameAttribute] string name = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
