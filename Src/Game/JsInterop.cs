using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazor.Mastermind.Game
{
    public class JsInterop
    {
        public static Task<bool> Alert(string message)
        {
            // Implemented in myJsInterop.js
            return JSRuntime.Current.InvokeAsync<bool>("myJsFunctions.alert", message);
        }
    }
}
