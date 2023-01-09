using System.Collections.Concurrent;
using D5BF9U.Creatures;
using D5BF9U.StatusAilments;

namespace D5BF9U.Containers;

public sealed class StatusAilmentQue
{
    public IStatusAilment StatusAilment { get;  } 
    public Creature Self { get; }
    public Creature Target { get; }

    public StatusAilmentQue(IStatusAilment statusAilment, Creature self, Creature target)
    {
        StatusAilment = statusAilment;
        Self = self;
        Target = target;
    }
}