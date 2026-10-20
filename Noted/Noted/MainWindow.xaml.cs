/// Author : Raagam Parmar
/// Date   : 18-10-2026

using Microsoft.UI.Xaml;

using Noted.ViewModels;

namespace Noted;
/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public NoteList NoteList { get; } = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void NewNoteButton_Click(object sender, RoutedEventArgs e)
    {
        NoteList.AddNote();
    }
}
