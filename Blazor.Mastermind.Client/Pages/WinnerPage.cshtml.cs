using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using Tiny.RestClient;

namespace Blazor.Mastermind.Client.Pages
{
    public class WinnerPageModel : BlazorComponent
    {
        [Inject]
        public Game.Engine Engine { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        [Inject]
        public IUriHelper UriHelper { get; set; }

        public Shared.Gamer Gamer { get; set; } = new Shared.Gamer();

        public async Task Send()
        {
            // Send
            Gamer.Recorded = DateTime.Now;
            await Http.SendJsonAsync(HttpMethod.Post, "api/Mastermind/Save", Gamer);

            // Alert
            Console.WriteLine("Sent");
            await Game.JsInterop.Alert("Congratulation");

            //Restart
            Engine.Start();
            UriHelper.NavigateTo("/");
        }
    }
}