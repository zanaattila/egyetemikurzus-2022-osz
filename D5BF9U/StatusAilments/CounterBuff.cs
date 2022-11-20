using System.Collections.Concurrent;
using System.Data.SqlTypes;
using D5BF9U.Containers;
using D5BF9U.Creatures;
using D5BF9U.Enums;

namespace D5BF9U.StatusAilments;

public sealed class CounterBuff : IStatusAilment
{
    public string Name => "Counter";
    public int DurationMillisec => 1000;
    public int? MaxTicks => 1;
    public int CurrentTicks { get; set; }
    public int CounterValue { get; }
    public bool IsHarmful => false;
    public bool IsDisplayed => true;
    public StatusAilmentTypes[] Types => new[] { StatusAilmentTypes.OnSkillUse, StatusAilmentTypes.ActionStringValueRequired };
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
        if (self.StatusAilments.ContainsKey(Name))
        {
            lock (self.StatusAilments)
            {
                self.StatusAilments[Name] = this;
            }
        }
        else
        {
            lock (self.StatusAilments)
            {
                self.StatusAilments.TryAdd(Name, this);
            }
        }
    }

    public void TakeAction(Creature self, Creature target)
    {
        throw new NotImplementedException("Wrong Take Action function in CounterBuff");
    }

    public void TakeAction(Creature self, Creature target,ref double? value)
    {
        //how am i going to implement this....
        throw new NotImplementedException("Wrong Take Action function in CounterBuff");
    }

    public void TakeAction(Creature self, Creature target, string value)
    {
        if (value.Equals("Block"))
        {
            target.TakeDmg(CounterValue);
        }
        
        Deactivate(self,target);
    }

    public void Deactivate(Creature self, Creature target)
    {
        if (self.StatusAilments.ContainsKey(Name))
        {
            lock (self.StatusAilments)
            {
                self.StatusAilments.Remove(Name);
            }
        }
    }
}