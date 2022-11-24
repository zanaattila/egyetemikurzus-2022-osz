using System.Collections.Concurrent;
using System.Data;
using System.Xml.Schema;
using D5BF9U.Containers;
using D5BF9U.Creatures;
using D5BF9U.Enums;
using D5BF9U.Exceptions;

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
        self.StatusAilments.AddOrUpdate(Name,this, (key,value) =>
        {
            //well this is a syntax i didnt expect
            return this;
        });
        
    }

    /// <summary>
    /// since this buffs takeaction is called in take dmg with a parameter, but will also be called by the buff watcher
    /// takeaction here will call the deactivate method
    /// </summary>
    /// <param name="self"></param>
    /// <param name="target"></param>
    /// <exception cref="BuffTakeActionError"></exception>
    public void TakeAction(Creature self, Creature target)
    {
        Deactivate(self,target);
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
        self.PersonalCombatLog.LogAction(String.Empty, 0,false,false,$"BLOCKED ~( {value} )~");
        value = 0;//just in case;  and i think i was right 
        Deactivate(self,target);
    }

    public void TakeAction(Creature self, Creature target, string value)
    {
        throw new BuffTakeActionError(Name);
    }

    public void Deactivate(Creature self, Creature target)
    {
        self.StatusAilments.TryRemove(Name, out _);
        //maybe i should log if it wasnt successful to remove
    }
}