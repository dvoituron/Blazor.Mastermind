using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using System;

namespace Blazor.Mastermind.Pages
{
    public class GamePageModel : BlazorComponent
    {
        [Inject]
        public Game.Engine Engine { get; set; }

        [Inject]
        public IUriHelper UriHelper { get; set; }

        public void Check()
        {
            var won = Engine.Check();

            if (won)
            {
                Game.JsInterop.Alert("You win!");
                UriHelper.NavigateTo("/winner");
            }
        }
    }
}