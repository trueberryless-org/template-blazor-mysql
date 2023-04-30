namespace View.Services;

public class BrowserService
{
    private IJSRuntime JSRuntime = null;
    public event EventHandler<bool> Resize;

    public bool IsPortrait;
    
    public async void Init(IJSRuntime js) {
        // enforce single invocation            
        if (JSRuntime == null) {
            this.JSRuntime = js;
            await JSRuntime.InvokeAsync<string>("resizeListener", DotNetObjectReference.Create(this));
        }
    }
        
    [JSInvokable]
    public void SetBrowserDimensions(int jsBrowserWidth, int jsBrowserHeight)
    {
        IsPortrait = jsBrowserHeight > jsBrowserWidth;
        this.Resize?.Invoke(this,IsPortrait);
    }
}