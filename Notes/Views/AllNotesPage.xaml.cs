using Microsoft.UI.Xaml.Controls;

using Notes.Models;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Notes.Views;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class AllNotesPage : Page
{
    private readonly AllNotes _notesModel = new();

    public AllNotesPage()
    {
        InitializeComponent();
    }

    private void NewNoteButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
    {
        Frame.Navigate(typeof(NotePage));
    }

    private void ItemsView_ItemInvoked(ItemsView sender, ItemsViewItemInvokedEventArgs args)
    {
        Frame.Navigate(typeof(NotePage), args.InvokedItem);
    }
}