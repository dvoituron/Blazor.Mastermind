using System;
using Microsoft.AspNetCore.Blazor.Components;

namespace Blazor.Mastermind.Client.Pages
{
    public class GameRowModel : BlazorComponent
    {
        [Parameter]
        Game.Row WithColors { get; set; }

        public Game.Row Row => WithColors;

        public void Ball_Click(int ballIndex)
        {
            Row.SetNextColor(ballIndex);
        }
    }
}