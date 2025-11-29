using Microsoft.JSInterop;

namespace BlazorTestTailwind.Services;

public class ThemeService
{
    private readonly IJSRuntime _jsRuntime;
    public bool IsDarkMode { get; private set; } = false;
    public bool IsRtl { get; private set; } = false;
    public event Action? OnThemeChanged;

    public ThemeService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task InitializeAsync()
    {
        try
        {
            var theme = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "theme");
            IsDarkMode = theme == "dark";

            var direction = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "direction");
            IsRtl = direction == "rtl";

            // Apply theme immediately
            if (IsDarkMode)
                await _jsRuntime.InvokeVoidAsync("eval", "document.documentElement.classList.add('dark')");
            else
                await _jsRuntime.InvokeVoidAsync("eval", "document.documentElement.classList.remove('dark')");

            // Apply direction immediately
            var dirValue = IsRtl ? "rtl" : "ltr";
            await _jsRuntime.InvokeVoidAsync("eval", $"document.documentElement.setAttribute('dir', '{dirValue}')");

            OnThemeChanged?.Invoke();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Storage access error: {ex.Message}");
            IsDarkMode = false;
            IsRtl = false;
        }
    }

    public async Task ToggleThemeAsync()
    {
        IsDarkMode = !IsDarkMode;
        var theme = IsDarkMode ? "dark" : "light";
        
        try
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "theme", theme);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Storage access error: {ex.Message}");
        }
        
        if (IsDarkMode)
            await _jsRuntime.InvokeVoidAsync("eval", "document.documentElement.classList.add('dark')");
        else
            await _jsRuntime.InvokeVoidAsync("eval", "document.documentElement.classList.remove('dark')");
            
        OnThemeChanged?.Invoke();
    }

    public async Task ToggleDirectionAsync()
    {
        IsRtl = !IsRtl;
        var direction = IsRtl ? "rtl" : "ltr";
        
        try
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "direction", direction);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Storage access error: {ex.Message}");
        }
        
        await _jsRuntime.InvokeVoidAsync("eval", $"document.documentElement.dir = '{direction}'");
        
        OnThemeChanged?.Invoke();
    }
}