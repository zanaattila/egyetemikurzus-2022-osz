using System.Collections.Concurrent;
using System.Data.SqlTypes;
using D5BF9U.Containers;
using D5BF9U.Creatures;
using D5BF9U.Enums;
using D5BF9U.Exceptions;

namespace D5BF9U.StatusAilments;

public sealed class CounterBuff : IStatusAilment
{
    public string Name => "Counter";
    public int DurationMillisec => 1500;
    public int? MaxTicks => 1;
    public int CurrentTicks { get; set; }
    public int CounterValue { get; }
    public bool IsHarmful => false;
    public bool IsDisplayed => true;
    public StatusAilmentTypes[] Types => new[] { StatusAilmentTypes.OnSkillUse, StatusAilmentTypes.ActionStringValueRequired,StatusAilmentTypes.OffGlobalInstant };
    public DateTime TimeOfAcquisition { get; init; }


    public CounterBuff(int blockedValue)
    {
        CurrentTicks = 1;
        TimeOfAcquisition = new DateTime();
        TimeOfAcquisition = DateTime.Now;
        CounterValue = blockedValue * 3;
    }
    public void RequestAction(Creature self, Creature target)
    {
        StatusAilmentQue ailmentQue = new StatusAilmentQue(this, self, target);
        self.StatusAilmentQues.Enqueue(ailmentQue);
    }

    public void Activate(Creature self, Creature target)
    {
        self.StatusAilments.AddOrUpdate(Name,this, (key,value) =>
        {
            return this;
        });
    }

    public void TakeAction(Creature self, Creature target)
    {
        throw new BuffTakeActionError(Name);
    }

    public void TakeAction(Creature self, Creature target,ref double? value)
    {
        throw new BuffTakeActionError(Name);
    }

    public void TakeAction(Creature self, Creature target, string value)
    {
        if (value.Equals("Block"))
        {
            target.TakeDmg(CounterValue);
            Deactivate(self, target);
        }
    }

    public void Deactivate(Creature self, Creature target)
    {
        self.StatusAilments.TryRemove(Name, out _); 
    }
}