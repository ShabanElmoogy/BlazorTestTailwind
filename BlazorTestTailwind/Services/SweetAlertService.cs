using Microsoft.JSInterop;

namespace BlazorTestTailwind.Services;

public class SweetAlertService
{
    private readonly IJSRuntime _jsRuntime;
    private readonly DirectionService _directionService;

    public SweetAlertService(IJSRuntime jsRuntime, DirectionService directionService)
    {
        _jsRuntime = jsRuntime;
        _directionService = directionService;
    }

    public async Task<bool> ShowConfirm(string title, string text, string confirmText = "Yes", string cancelText = "No")
    {
        var isRtl = await _directionService.IsRtlAsync();
        return await _jsRuntime.InvokeAsync<bool>("showSweetAlert", "confirm", title, text, confirmText, cancelText, isRtl);
    }

    public async Task ShowSuccess(string title, string text = "")
    {
        var isRtl = await _directionService.IsRtlAsync();
        await _jsRuntime.InvokeVoidAsync("showSweetAlert", "success", title, text, "", "", isRtl);
    }

    public async Task ShowError(string title, string text = "")
    {
        var isRtl = await _directionService.IsRtlAsync();
        await _jsRuntime.InvokeVoidAsync("showSweetAlert", "error", title, text, "", "", isRtl);
    }

    public async Task ShowWarning(string title, string text = "")
    {
        var isRtl = await _directionService.IsRtlAsync();
        await _jsRuntime.InvokeVoidAsync("showSweetAlert", "warning", title, text, "", "", isRtl);
    }

    public async Task ShowInfo(string title, string text = "")
    {
        var isRtl = await _directionService.IsRtlAsync();
        await _jsRuntime.InvokeVoidAsync("showSweetAlert", "info", title, text, "", "", isRtl);
    }

    public async Task<string?> ShowInput(string title, string placeholder = "", string inputType = "text")
    {
        var isRtl = await _directionService.IsRtlAsync();
        return await _jsRuntime.InvokeAsync<string?>("showSweetAlertInput", title, placeholder, inputType, isRtl);
    }
}