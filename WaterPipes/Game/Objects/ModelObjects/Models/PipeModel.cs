using System;
using WaterPipes.OutputProviders;

namespace WaterPipes.Game.Objects.ModelObjects.Models
{
    internal sealed class PipeModel : Model
    {
        public PipeModel() : base('O', Color.White)
        {
        }

        public void UpdateColor(object sender, EventArgs args)
        {
            if (color == Color.White)
            {
                color = Color.Blue;
            }
        }
    }
}