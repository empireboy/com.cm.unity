using System.Collections.Generic;
using Zenject;

namespace CM.Unity.Infrastructure
{
    public class TickableAdapter : ITickable
    {
        private readonly List<Core.Domain.ITickable> _tickables;

        public TickableAdapter(List<Core.Domain.ITickable> tickables)
        {
            _tickables = tickables;
        }

        public void Tick()
        {
            foreach (Core.Domain.ITickable tickable in _tickables)
                tickable.Tick();
        }
    }
}