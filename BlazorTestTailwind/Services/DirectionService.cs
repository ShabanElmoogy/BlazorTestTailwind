using Microsoft.JSInterop;

namespace BlazorTestTailwind.Services
{
    public class DirectionService
    {
        private readonly IJSRuntime _jsRuntime;
        private bool _isRTL;

        public DirectionService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public bool IsRTL => _isRTL;

        public event Action? OnDirectionChanged;

        public async Task InitializeAsync()
        {
            // Default to LTR
            _isRTL = false;
            await ApplyDirectionAsync();
        }

        public async Task ToggleDirectionAsync()
        {
            _isRTL = !_isRTL;
            await ApplyDirectionAsync();
            OnDirectionChanged?.Invoke();
        }

        private async Task ApplyDirectionAsync()
        {
            if (_isRTL)
            {
                await _jsRuntime.InvokeVoidAsync("eval", "document.documentElement.setAttribute('dir', 'rtl')");
            }
            else
            {
                await _jsRuntime.InvokeVoidAsync("eval", "document.documentElement.setAttribute('dir', 'ltr')");
            }
        }
    }
}