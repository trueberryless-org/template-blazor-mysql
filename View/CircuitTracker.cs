namespace View;

public class CircuitTracker : CircuitHandler {
    private readonly ProtectedLocalStorage _local;
    private readonly ILogger<CircuitTracker> _logger;

    public CircuitTracker(ProtectedLocalStorage local, ILogger<CircuitTracker> logger) {
        _local = local;
        _logger = logger;
    }

    public override async Task OnConnectionUpAsync(Circuit circuit, CancellationToken cancellationToken) {
        
    }
}