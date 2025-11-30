using Microsoft.JSInterop;

namespace BlazorTestTailwind.Services;

public class ToastService
{
    private readonly IJSRuntime _jsRuntime;
    private readonly DirectionService _directionService;

    public ToastService(IJSRuntime jsRuntime, DirectionService directionService)
    {
        _jsRuntime = jsRuntime;
        _directionService = directionService;
    }

    public async Task ShowSuccess(string message, int duration = 3000)
    {
        await ShowToast(message, "success", duration);
    }

    public async Task ShowError(string message, int duration = 5000)
    {
        await ShowToast(message, "error", duration);
    }

    public async Task ShowWarning(string message, int duration = 4000)
    {
        await ShowToast(message, "warning", duration);
    }

    public async Task ShowInfo(string message, int duration = 3000)
    {
        await ShowToast(message, "info", duration);
    }

    private async Task ShowToast(string message, string type, int duration)
    {
        var isRtl = await _directionService.IsRtlAsync();
        await _jsRuntime.InvokeVoidAsync("showToast", message, type, duration, isRtl);
    }
}