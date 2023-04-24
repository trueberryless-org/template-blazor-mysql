namespace View.Services;

public class EventProvider
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

    public virtual void OnProfileMenuClosed()
    {
        ProfileMenuClosed?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler? NavMenuOpened;

    public virtual void OnNavMenuOpened()
    {
        NavMenuOpened?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler? NavMenuClosed;

    public virtual void OnNavMenuClosed()
    {
        NavMenuClosed?.Invoke(this, EventArgs.Empty);
    }
}