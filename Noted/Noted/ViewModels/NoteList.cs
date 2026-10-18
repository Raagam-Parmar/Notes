using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Noted.ViewModels;

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
    /// Add a new note to the list
    /// </summary>
    /// <param name="note">Note to add</param>
    public void AddNote(SingleNote note)
    {
        Notes.Add(note);
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
