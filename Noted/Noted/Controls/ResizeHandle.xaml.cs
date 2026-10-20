using Microsoft.UI.Input;
using Microsoft.UI.Xaml.Controls;

namespace Noted.Controls;

public sealed partial class ResizeHandle : UserControl
{
    public ResizeHandle()
    {
        InitializeComponent();

        ProtectedCursor = InputSystemCursor.Create(
            InputSystemCursorShape.SizeWestEast);
    }
}
