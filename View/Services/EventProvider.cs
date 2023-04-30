namespace View.Services;

public sealed class EventProvider
{
    public event EventHandler? SelectedDateChanged;

    public void OnSelectedDateChanged()
    {
        SelectedDateChanged?.Invoke(this, EventArgs.Empty);
    }
    
    public event EventHandler? ProfileMenuOpened;

    public void OnProfileMenuOpened()
    {
        ProfileMenuOpened?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler? ProfileMenuClosed;

    public void OnProfileMenuClosed()
    {
        ProfileMenuClosed?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler? NavMenuOpened;

    public void OnNavMenuOpened()
    {
        NavMenuOpened?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler? NavMenuClosed;

    public void OnNavMenuClosed()
    {
        NavMenuClosed?.Invoke(this, EventArgs.Empty);
    }
}