using System.Collections.Generic;
using Zenject;

public class TickableAdapter : ITickable
{
    private readonly List<CM.Core.Domain.ITickable> _tickables;

    public TickableAdapter(List<CM.Core.Domain.ITickable> tickables)
    {
        _tickables = tickables;
    }

    public void Tick()
    {
        foreach (CM.Core.Domain.ITickable tickable in _tickables)
            tickable.Tick();
    }
}