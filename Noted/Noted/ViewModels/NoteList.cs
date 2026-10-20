using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Noted.ViewModels;

using Noted.Models;

/// <summary>
/// Represents a list of available notes
/// </summary>
public partial class NoteList : INotifyPropertyChanged
{
    public ObservableCollection<SingleNote> Notes { get; } = [];

    /// <summary>
    /// The currently selected note for viewing
    /// </summary>
    private SingleNote? _selectedNote;
    public SingleNote? SelectedNote
    {
        get => _selectedNote;
        set
        {
            if (_selectedNote == value) return;

            _selectedNote = value is not null && Notes.Contains(value) ? value : null;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Is there at least one note in the list?
    /// </summary>
    public bool HasAtLeastOneNote
    {
        get => Notes.Count >= 1;
    }

    /// <summary>
    /// Are there no notes in the list?
    /// </summary>
    public bool HasNoNotes
    {
        get => Notes.Count == 0;
    }

    /// <summary>
    /// Add a new note to the list?
    /// </summary>
    public void AddNote()
    {
        Note note = new();
        SingleNote singleNote = new(note);
        Notes.Add(singleNote);

        SelectedNote = singleNote;

        OnPropertyChanged(nameof(HasNoNotes));
        OnPropertyChanged(nameof(HasAtLeastOneNote));
    }

    /// <summary>
    /// Remove a note from the list
    /// </summary>
    /// <param name="note">Note to remove</param>
    public void RemoveNote(SingleNote note)
    {
        bool removeSuccess = Notes.Remove(note);

        if (removeSuccess)
        {
            OnPropertyChanged(nameof(HasNoNotes));
            OnPropertyChanged(nameof(HasAtLeastOneNote));

            if (_selectedNote == note)
            {
                SelectedNote = null;
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberNameAttribute] string name = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
