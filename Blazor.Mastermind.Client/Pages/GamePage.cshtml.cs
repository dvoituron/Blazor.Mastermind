using System;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;

namespace Blazor.Mastermind.Client.Pages
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
                UriHelper.NavigateTo("/WinnerPage");
            }

        }
    }
}