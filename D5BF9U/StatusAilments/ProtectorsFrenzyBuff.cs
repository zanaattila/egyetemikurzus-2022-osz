using System.Collections.Concurrent;
using D5BF9U.Containers;
using D5BF9U.Creatures;
using D5BF9U.Enums;

namespace D5BF9U.StatusAilments;

public sealed class ProtectorsFrenzyBuff : IStatusAilment
{
    public string Name => "Protectors Frenzy";
    public int DurationMillisec => 4200;
    public double Value => 3.2;
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

            self.DamageMultiplier += Value;
        }

    }

    public void TakeAction(Creature self, Creature target)
    {
        throw new NotImplementedException();
    }

    public void TakeAction(Creature self, Creature target, int value)
    {
        throw new NotImplementedException();
    }

    public void TakeAction(Creature self, Creature target, string value)
    {
        throw new NotImplementedException();
    }

    public void Deactivate(Creature self, Creature target)
    {
        if (self.StatusAilments.ContainsKey(Name))
        {
            lock (self.StatusAilments)
            {
                self.StatusAilments.Remove(Name);
            }

            self.DamageMultiplier -= Value;
        }
    }
}