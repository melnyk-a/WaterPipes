using System;
using WaterPipes.Game.Objects.GeometricObjects;
using WaterPipes.Game.Objects.ModelObjects.Models;
using WaterPipes.OutputProviders;

namespace WaterPipes.Game.Objects.ModelObjects
{
    internal sealed class Pipe : IGameModelObject
    {
        private readonly PipeModel model = new PipeModel();
        private bool isFilled = false;

        public Pipe()
        {
            FilledChange += new EventHandler(model.UpdateColor);
        }

        public string Name { get; } = "Pipe";

        public event EventHandler FilledChange;

        public object Clone()
        {
            Pipe clone = new Pipe
            {
                IsFilled = isFilled
            };
            return clone;
        }

        public void Draw(IOutputProvider provider, Point startPosition)
        {
            model.Draw(provider, startPosition);
        }

        public bool IsFilled
        {
            get { return isFilled; }
            set
            {
                bool newValue = value;
                if (isFilled != newValue)
                {
                    isFilled = newValue;
                    OnFilledChange(EventArgs.Empty);
                }
            }
        }

        private void OnFilledChange(EventArgs e)
        {
            FilledChange?.Invoke(this, e);
        }
    }
}