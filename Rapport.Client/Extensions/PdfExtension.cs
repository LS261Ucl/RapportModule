using Microsoft.JSInterop;

namespace Rapport.Client.Extensions
{
    public static class PdfExtension
    {
        public static ValueTask<object> SaveAs(this IJSRuntime js, string filename, byte[] data)
            => js.InvokeAsync<object>("saveAsFile", filename, Convert.ToBase64String(data));
    }
}
