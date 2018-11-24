using System;
using System.Linq;

namespace Blazor.Mastermind.Game
{
    public class Row
    {
        public Row()
        {
            Colors = new[] { Engine.NO_COLOR, Engine.NO_COLOR, Engine.NO_COLOR, Engine.NO_COLOR };
        }

        public Row(bool defaultColors)
        {
            Colors = Engine.COLORS_PALETTE.Take(4).ToArray();
        }

        public string[] Colors { get; set; }

        public int Goods { get; set; }

        public int Bads { get; set; }

        public bool IsComputerChoice { get; set; }

        public bool IsChecked { get; set; }

        public void SetNextColor(int index)
        {
            if (IsChecked || IsComputerChoice) return;

            // Current palette index
            int currentPaletteIndex = CurrentPaletteIndex(index);

            // Next palette index
            currentPaletteIndex = currentPaletteIndex >= Engine.COLORS_PALETTE.Length - 1 
                                  ? 0 
                                  : currentPaletteIndex + 1;

            // Sets the new color
            Colors[index] = Engine.COLORS_PALETTE[currentPaletteIndex];
        }

        private int CurrentPaletteIndex(int index)
        {
            for (int i = 0; i < Engine.COLORS_PALETTE.Length; i++)
            {
                if (Engine.COLORS_PALETTE[i] == Colors[index])
                    return i;
            }

            return -1;
        }
    }
}
