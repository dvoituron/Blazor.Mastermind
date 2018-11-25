using System;

namespace Blazor.Mastermind.Shared
{
    public class Gamer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Recorded { get; set; }
        public int NumberOfRows { get; set; }
    }
}
