using System.Collections.Concurrent;
using System.Data;
using System.Xml.Schema;
using D5BF9U.Containers;
using D5BF9U.Creatures;
using D5BF9U.Enums;

namespace D5BF9U.StatusAilments;

public sealed class BlockBuff : IStatusAilment
{
    public string Name => "Block";
    public int DurationMillisec => 200;
    public int? MaxTicks => 1;
    public int CurrentTicks { get; set; }
    public bool IsHarmful => false;
    public bool IsDisplayed => true;

    //damn, took me long enough to get this
    public StatusAilmentTypes[] Types => new[] { StatusAilmentTypes.WhenStruck, StatusAilmentTypes.ActionIntegerValueRequired };

    public DateTime TimeOfAcquisition { get; init; }

    public BlockBuff()
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
        
        self.IsInvicible = true; //as i see it shouldnt need a lock statement
    }

    public void TakeAction(Creature self, Creature target)
    {
        throw new NotImplementedException("Wrong Take Action function in BlockBuff");
    }

    /// <summary>
    /// so the was as is follows: buffs and skills will be operated through a designated class
    /// that class will also ask the creature self to roll a damage number, and the creature target to take the damage
    /// so all the damage taken will be made by the creature -> this way this function can be invoked via the creature
    /// inside a take damage function where it checks for buffs and various flags
    ///
    /// summary:
    /// step 1 :requested by creatured
    /// step 2 :initiated by designated serverlike class -> Skill.CastMe(self,target)
    /// step 3 : in case creature takes dmg or heals or gets buffed or something like that -> those are taken inside its method Creature.takedmg Creature.TakeHealing
    /// Creature.DealDmg(string spellNameCast){} will also have flags like OnSkillUse
    /// Creature.DealDmg(string spellnamecast){ Where Skilllists.key=spellnamcast. cast it
    ///
    /// i should just go to sleep
    ///
    /// 
    /// </summary>
    /// <param name="self"></param>
    /// <param name="target"></param>
    /// <param name="value"></param>
    public void TakeAction(Creature self, Creature target, ref double? value) //todo consider TakeAction to make it a bool instead of a void so can check on the success of it in the caller, yes i will do this, tomorrow
    {
        CounterBuff buffUp = new CounterBuff(value is not null ? (int)value : 0);//and now 
        ProtectorsFrenzyBuff frenzyBuff = new ProtectorsFrenzyBuff();
        buffUp.RequestAction(self,target);
        frenzyBuff.RequestAction(self,target);
        value = 0;//just in case;  and i think i was right 
        Deactivate(self,target);
    }

    public void TakeAction(Creature self, Creature target, string value)
    {
        throw new NotImplementedException("Wrong Take Action function in BlockBuff ");
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