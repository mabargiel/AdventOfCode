using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Threading.Tasks;
using AdventOfCode.Days._2019.Intcode;

namespace AdventOfCode.Days._2019._13
{
    public class ArcadeCabinet
    {
        private readonly IIntcodeComputer _intcodeComputer;

        public ArcadeCabinet(IIntcodeComputer intcodeComputer)
        {
            _intcodeComputer = intcodeComputer;
        }

        public event Action<(PointF, long)> OnTileUpdated;

        public async Task RunGame()
        {
            var outputs = new BlockingCollection<long>();
            _intcodeComputer.OnOutput += l =>
            {
                outputs.Add(l);
                if (outputs.Count == 3)
                {
                    var x = outputs.Take();
                    var y = outputs.Take();
                    var tileId = outputs.Take();

                    OnTileUpdated?.Invoke((new PointF(x, y), tileId));
                }
            };

            await _intcodeComputer.StartAsync();
        }

        public void SetJoystick(int movement)
        {
            _intcodeComputer.Input(movement);
        }
    }
}