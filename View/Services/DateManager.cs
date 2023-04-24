namespace View.Services;

public class DateManager
{
    private readonly EventProvider _eventProvider;

    public DateManager(EventProvider eventProvider)
    {
        _eventProvider = eventProvider;
        Today = DateTime.Today;
        SelectedDate = Today;

        _eventProvider.SelectedDateChanged += new EventHandler(HandleDateChangeAsync);
    }
    
    private DateTime? _selectedDate;
    public DateTime? SelectedDate
    {
        get => _selectedDate ??= DateTime.Today;
        set
        {
            _selectedDate = value;
            
            // raise event
            _eventProvider.OnSelectedDateChanged();
        }
    }

    public bool MaxDateReached { get; private set; } = true;

    public readonly DateTime Today;
    
    public MudDatePicker? DatePicker { get; set; }


    public void HandleDateChangeAsync(object? sender, EventArgs e)
    {
        MaxDateReached = SelectedDate == Today;
    }

    public void PrevDate()
    {
        SelectedDate = SelectedDate?.AddDays(-1);
    }

    public void NextDate()
    {
        SelectedDate = SelectedDate?.AddDays(1);
    }
    
    public async Task DatePickerToday()
    {
        await DatePicker!.GoToDate(DateTime.Today);
        DatePicker.Close();
    }
}