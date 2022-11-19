using System.Collections.Concurrent;
using D5BF9U.Containers;
using D5BF9U.Creatures;
using D5BF9U.Enums;

namespace D5BF9U.StatusAilments;

public sealed class ProtectorsFrenzyBuff : IStatusAilment
{
    public string Name => "Protectors Frenzy";
    public int DurationMillisec => 4200;
    public int? MaxTicks => null;
    public int CurrentTicks { get; set; }
    public bool IsHarmful => false;
    public bool IsDisplayed => true;
    public StatusAilmentTypes[] Types => new[] { StatusAilmentTypes.Buff, StatusAilmentTypes.DamageIncrease };
    public DateTime TimeOfAcquisition { get; init; }

    public ProtectorsFrenzyBuff()
    {
        TimeOfAcquisition = new DateTime();
        TimeOfAcquisition = DateTime.Now;   
    }
    public void RequestAction(ConcurrentQueue<StatusAilmentQue> statusAilmentQues, Creature self, Creature target)
    {
        StatusAilmentQue ailmentQue = new StatusAilmentQue(this, self, target);
        statusAilmentQues.Enqueue(ailmentQue);
    }

    public void Activate(Creature self, Creature target)
    {
        throw new NotImplementedException();
    }

    public void TakeAction(Creature self, Creature target)
    {
        throw new NotImplementedException();
    }

    public void Deactivate(Creature self, Creature target)
    {
        throw new NotImplementedException();
    }
}