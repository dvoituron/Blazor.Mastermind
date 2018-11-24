using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Mastermind.Game
{
    public class Engine
    {
        public static string NO_COLOR = "white";
        public static string[] COLORS_PALETTE = new[] { "red", "blue", "green", "orange", "black" };

        public Engine()
        {
            Start();
        }

        public Row ComputerChoice { get; set; } = new Row(noColors: true) { IsComputerChoice = true };

        public List<Row> Rows { get; set; } = new List<Row>();

        public bool HasWon { get; set; }

        public void Start()
        {
            var palette = RandomizedPalette();
            //var palette = COLORS_PALETTE;
            for (int i = 0; i < 4; i++)
            {
                ComputerChoice.Colors[i] = palette[i];
            }

            Rows.Clear();
            Rows.Add(new Row(noColors: true));
        }

        public bool Check()
        {
            var userRow = Rows.Last();
            var userColors = userRow.Colors;
            var computerColors = ComputerChoice.Colors;

            userRow.IsChecked = true;
            userRow.Goods = computerColors.Where((item, index) => userColors[index] == item).Count();
            userRow.Bads  = computerColors.Where((item, index) => userColors.Contains(item)).Count() - userRow.Goods;

            if (userRow.Goods == userColors.Length)
            {
                HasWon = true;
                return true;
            }
            else
            {
                HasWon = false;
                Rows.Add(new Row(noColors: true));
                return false;
            }
        }

        public string[] RandomizedPalette()
        {
            var rng = new Random();
            var palette = new List<string>(COLORS_PALETTE);

            int n = palette.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                var value = palette[k];
                palette[k] = palette[n];
                palette[n] = value;
            }

            return palette.ToArray();
        }
    }
}
