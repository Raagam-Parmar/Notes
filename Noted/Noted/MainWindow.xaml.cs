/// Author : Raagam Parmar
/// Date   : 18-10-2026

using System;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Automation.Peers;
using Microsoft.UI.Xaml.Controls;

using Noted.ViewModels;

namespace Noted;
/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public NoteList NoteList { get; } = new();

    private double _leftColumnRatio;
    private double _startPointerX;
    private double _startLeftWidth;
    private double _startRightWidth;
    private bool _isDragging;

    public MainWindow()
    {
        InitializeComponent();

        RootGrid.DataContext = this;
    }

    private void NewNoteButton_Click(object sender, RoutedEventArgs e)
    {
        NoteList.AddNote();
    }

    private void DeleteNoteButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.DataContext is SingleNote note)
        {
            NoteList.RemoveNote(note);
        }
    }

    private void Splitter_PointerPressed(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        Splitter.CapturePointer(e.Pointer);
        _isDragging = true;
        _startPointerX = e.GetCurrentPoint(RootGrid).Position.X;
        _startLeftWidth = ListColumn.ActualWidth;
        _startRightWidth = EditorColumn.ActualWidth;
        _leftColumnRatio = _startLeftWidth / (_startLeftWidth + _startRightWidth);
    }

    private void Splitter_PointerMoved(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        if (! _isDragging) return;

        double currX = e.GetCurrentPoint(RootGrid).Position.X;
        double deltaX = currX - _startPointerX;

        double leftWidth = _startLeftWidth + deltaX;
        double rightWidth = _startRightWidth - deltaX;

        if (leftWidth < 180)
        {
            leftWidth = 180;
            rightWidth = _startLeftWidth + _startRightWidth - leftWidth;
        }

        else if (rightWidth < 250)
        {
            rightWidth = 250;
            leftWidth = _startLeftWidth + _startRightWidth - rightWidth;
        }

        _leftColumnRatio = leftWidth / (leftWidth + rightWidth);

        ListColumn.Width = new GridLength(_leftColumnRatio, GridUnitType.Star);
        EditorColumn.Width = new GridLength(1.0 - _leftColumnRatio, GridUnitType.Star);
    }

    private void EndSplitterDrag(Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        _isDragging = false;
        Splitter.ReleasePointerCapture(e.Pointer);

    }

    private void Splitter_PointerReleased(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        EndSplitterDrag(e);
    }

    private void Splitter_PointerCanceled(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        EndSplitterDrag(e);
    }

    private void RootGrid_Loaded(object sender, RoutedEventArgs e)
    {
        if (AppWindow.Presenter is Microsoft.UI.Windowing.OverlappedPresenter presenter)
        {
            double scale = RootGrid.XamlRoot.RasterizationScale;
            presenter.PreferredMinimumWidth = (int)Math.Ceiling(500 * scale);
        }
    }
}
