using System;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;

namespace Blazor.Mastermind.Pages
{
    public class GameRowModel : BlazorComponent
    {
        [Parameter]
        Game.Row Row { get; set; }

        public string[] Color => Row.Colors;

        public int Goods => Row.Goods;

        public int Bads => Row.Bads;

        public bool IsChecked => Row.IsChecked;

        public void Ball_Click(int ballIndex)
        {
            if (!IsChecked)
            {
                Row.SetNextColor(ballIndex);
            }
        }
    }
}