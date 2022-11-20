using System.Collections.Concurrent;
using D5BF9U.Containers;
using D5BF9U.Creatures;
using D5BF9U.Enums;

namespace D5BF9U.StatusAilments;

public sealed class InsultDebuff : IStatusAilment
{
    public string Name => "Exposed to insults";
    public int DurationMillisec => 6000;
    public int? MaxTicks => 3;
    public int CurrentTicks { get; set; }
    public bool IsHarmful => true;
    public bool IsDisplayed => true;
    public StatusAilmentTypes[] Types => new[] { StatusAilmentTypes.Debuff,StatusAilmentTypes.DamageOverTime };
    public DateTime TimeOfAcquisition { get; init; }

    public InsultDebuff()
    {
        CurrentTicks = 1;
        TimeOfAcquisition = new DateTime();
        TimeOfAcquisition = DateTime.Now;
    }
    
    public void RequestAction(Creature self, Creature target)
    {
        StatusAilmentQue ailmentQue = new StatusAilmentQue(this, self, target);
        self.StatusAilmentQues.Enqueue(ailmentQue);
    }

    public void Activate(Creature self, Creature target)
    {
        throw new NotImplementedException();
    }

    public void TakeAction(Creature self, Creature target)
    {
        throw new NotImplementedException();
    }

    public void TakeAction(Creature self, Creature target,ref double? value)
    {
        throw new NotImplementedException();
    }

    public void TakeAction(Creature self, Creature target, string value)
    {
        throw new NotImplementedException();
    }

    public void Deactivate(Creature self, Creature target)
    {
        throw new NotImplementedException();
    }
}