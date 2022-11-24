using System.Collections.Concurrent;
using System.Diagnostics;
using D5BF9U.Containers;
using D5BF9U.Enums;
using D5BF9U.Exceptions;
using D5BF9U.Skills;
using D5BF9U.StatusAilments;

namespace D5BF9U.Creatures;

public sealed class Creature
{
    //damn, do i have to make everything interlocked? hope im on the right track
    //once again writing all getters and setter by hand
    public string Name { get; init; }
    public int BaseGlobalCoolDownMs { get; init; } //tbh i should just make it get only
    public bool IsAutoAttacking { get; init; }
    public string SpeechBox;
    public int MaxHealth;
    public int Health;
    public int Strength;
    public int Haste;//value is 1 on default, with 50% increase it gets 0.5, 0 mean no gcd at all
    //for methods like these ill make a setter so it doesnt go below 0
    public double DamageDoneMultiplier;
    public double DamageTakenMultiplier; //default = 1; doesnt go below zero 
    public double HealingDoneMultiplier;
    public double HealingTakenMultiplier;

    // default is false, set 1 for true.
    private int _threadSafeBoolBackValue = 0;

    
    public bool IsInvicible
    {
        get { return (Interlocked.CompareExchange(ref _threadSafeBoolBackValue, 1, 1) == 1); }
        set
        {
            if (value) Interlocked.CompareExchange(ref _threadSafeBoolBackValue, 1, 0);
            else Interlocked.CompareExchange(ref _threadSafeBoolBackValue, 0, 1);
        }
    }

    //public DateTime LastGCDTrigger;
    //people online said to use date time as interlocked its wiser to use it as .tobinary and long
    public long LastGCDTrigger;

    public Creature Target { get; set; }

    public CreatureLog PersonalCombatLog { get; set; }
    public ConcurrentQueue<StatusAilmentQue> StatusAilmentQues { get; set; }
    public ConcurrentQueue<SkillQue> SkillQues { get; set; }
    public ConcurrentDictionary<string,IStatusAilment> StatusAilments { get; set; }
    public ConcurrentDictionary<string,ISkill> SkillLists { get; set; }


    //public int  GlobalCD { get; init; } //in millisec
    
    //todo set speechbox
    public Creature(string name, int baseGlobalCoolDownMs, bool isAutoAttacking, int maxHealth, int strength, int haste,ConcurrentDictionary<string,ISkill> skillLists)
    {
        Name = name;
        BaseGlobalCoolDownMs = baseGlobalCoolDownMs;
        IsAutoAttacking = isAutoAttacking;
        MaxHealth = maxHealth;
        Health = MaxHealth;
        Strength = strength;
        Haste = haste;

        DamageDoneMultiplier = 1;
        DamageTakenMultiplier = 1;
        HealingDoneMultiplier = 1;
        HealingTakenMultiplier = 1;

        PersonalCombatLog = new CreatureLog();
        StatusAilmentQues = new ConcurrentQueue<StatusAilmentQue>();
        SkillQues = new ConcurrentQueue<SkillQue>();
        StatusAilments = new ConcurrentDictionary<string, IStatusAilment>();
        SkillLists = new ConcurrentDictionary<string, ISkill>(skillLists);
        
        SetLastGCDTrigger();
        IsInvicible = false;
        
    }
    
    public double GetDamageDoneMultiplier()
    {
        return Interlocked.CompareExchange(ref DamageDoneMultiplier, 0, 0);
    }
    public void SetDamageDoneMultiplier( double value)
    {
        double tmp = Math.Max(GetDamageDoneMultiplier() + value,0);
        Interlocked.CompareExchange(ref DamageDoneMultiplier, tmp,DamageDoneMultiplier );
    }

    public double GetDamageTakenMultiplier()
    {
        return Interlocked.CompareExchange(ref DamageTakenMultiplier, 0, 0);
    }
    
    public void SetDamageTakenMultiplier( double value)
    {
        double tmp = Math.Max(GetDamageTakenMultiplier() + value,0);
        Interlocked.CompareExchange(ref DamageTakenMultiplier, tmp,DamageTakenMultiplier );
    }

    public double GetHealingDoneMultiplier()
    {
        return Interlocked.CompareExchange(ref HealingDoneMultiplier, 0, 0);
    }

    
    public void SetHealingDoneMultiplier( double value)
    {
        double tmp = Math.Max(GetHealingDoneMultiplier() + value,0);
        Interlocked.CompareExchange(ref HealingDoneMultiplier, tmp,HealingDoneMultiplier );
    }
    
    
    public double GetHealingTakenMultiplier()
    {
        return Interlocked.CompareExchange(ref HealingTakenMultiplier, 0, 0);
    }
    
    public void SetHealingTakenMultiplier( double value)
    {
        double tmp = Math.Max(GetHealingTakenMultiplier() + value,0);
        Interlocked.CompareExchange(ref HealingTakenMultiplier, tmp,HealingTakenMultiplier );
    }
    
    

    public int GetHaste()
    {
        return Interlocked.CompareExchange(ref Haste, 0, 0);
    }
    
    public void SetHaste( int value)
    {
        int tmp = Math.Max(GetHaste() + value,0);
        Interlocked.CompareExchange(ref Haste, tmp,Haste );
    }
    
    public int GetStrength()
    {
        return Interlocked.CompareExchange(ref Strength, 0, 0);
    }
    
    public void SetStrength( int value)
    {
        int tmp = Math.Max(GetStrength() + value,0);
        Interlocked.CompareExchange(ref Strength, tmp,Strength );
    }
    public int GetMaxHealth()
    {
        return Interlocked.CompareExchange(ref MaxHealth, 0, 0);
    }


    public void SetLastGCDTrigger()
    {
        Interlocked.Exchange(ref LastGCDTrigger, DateTime.Now.ToBinary());
    }
    
    public DateTime GetLastGCDTrigger()
    {
        return DateTime.FromBinary(Interlocked.CompareExchange(ref LastGCDTrigger, 0, 0));
    }

    public void SetMaxHealth( int value)
    {
        int tmp = Math.Max(GetMaxHealth() + value,0);
        Interlocked.CompareExchange(ref MaxHealth, tmp,MaxHealth );
    }


    public string GetSpeechBox()
    {
        return Interlocked.CompareExchange(ref SpeechBox, "", "");
    }

    public void SetSpeech(string value)
    {
        Interlocked.CompareExchange(ref SpeechBox, value, SpeechBox);
    }

    /*public void SetSpeechBox(string value)
    {
        Interlocked.Exchange(ref SpeechBox, value);
    }*/


    public int GetHealth()
    {
        //return Thread.VolatileRead(ref Health);
        // john skeet says not to do this
        //@opc: I think the basic point is that it's guaranteed that anything else you read afterwards will be at least as fresh. So you can make sensible decisions, if you get your reads and writes in the right order. It's possible that the memory barrier is achieved precisely by reading/writing freshly - but it's not guaranteed by the spec :( – 
        //Jon Skeet
        //Nov 21, 2009 at 21:01
        return Interlocked.CompareExchange(ref Health, 0, 0);
        //everyone says i should use this way to read it, tho i have no idea what the last 2 zeros are, what kind of comparison is this? you compare 2 values with 3? its like javascripts boolean -> true or false? the answer is -> undefined
    }

    public void SetHealth( int value)
    {
        int tmp = Math.Min(Math.Max(GetHealth() + value, 0), GetMaxHealth());
        Interlocked.CompareExchange(ref Health, tmp,Health );
    }


    public void TakeDmg(double? value)// might need to be boolean
    {
        double? damageTake = value * GetDamageTakenMultiplier();
        //CheckForStatusAilment(StatusAilmentTypes.Immune,"_NONE_", ref damageTake); i think ill just remove the immune type
        CheckForStatusAilment(StatusAilmentTypes.WhenStruck,"_NONE_", ref damageTake);
        CheckForStatusAilment(StatusAilmentTypes.Absorb,"_NONE_", ref damageTake);
        if (damageTake is not null  && damageTake !=0)
        {
            int dmg = (int)damageTake;
            //so ive read up about it, and it says nullables are not atomic, so ill ask next time how to use these, or are these thread safe at all
            //oh fuck now i get it, it must not have properties because it must be reached via interlocked!
            /*Interlocked.Increment(ref this.Health);
            Interlocked.Exchange(ref Health, tmpHp);*/
            //Interlocked.Add(ref Health,-Math.Max(0, dmg));
            SetHealth(-dmg);
            PersonalCombatLog.LogAction(Name,dmg,true);
        }
    }

    public void AilmentTakeAction(IStatusAilment  buff,string whichSkill, ref double? damageDeal) //this breaks the pattern cos called in here and not by its scheduler
    {
        if (buff.Types.Contains(StatusAilmentTypes.ActionIntegerValueRequired))
        {
            buff.TakeAction(this,Target,ref  damageDeal );
            //what could take a value during initiating dmg when the class itself gets passed too?
            //todo, figure out where this fails
        }else if (buff.Types.Contains(StatusAilmentTypes.ActionStringValueRequired))
        {
            buff.TakeAction(this,Target,whichSkill);
        }
        else //else, call the default take action
        {
            buff.TakeAction(this,Target);
        }
    }

    public void CheckForStatusAilment(StatusAilmentTypes ailmentType, string whichSkill, ref double? damageDeal)
    {
        if (StatusAilments.Any( sa => sa.Value.Types.Contains(ailmentType)))
        {
            var buffs2Activate =
                StatusAilments.Values.Where(sa => sa.Types.Contains(ailmentType));

            foreach (var buff in buffs2Activate)
            {
                AilmentTakeAction(buff, whichSkill, ref damageDeal);
            }
        }

    }

    public double? DealDmg(string whichSkill)
    {

        if (SkillLists.Keys.Contains(whichSkill))
        {
            double? damageDeal = (SkillLists[whichSkill].Value is not null
                ? SkillLists[whichSkill].Value * SkillLists[whichSkill].EffectiveRate * GetStrength() * GetDamageDoneMultiplier()
                : 0);

            CheckForStatusAilment(StatusAilmentTypes.OnSkillUse, whichSkill, ref damageDeal);

            /*if (StatusAilments.Any( sa => sa.Value.Types.Contains(StatusAilmentTypes.OnSkillUse)))
            {
                var buffs2Activate =
                    StatusAilments.Values.Where(sa => sa.Types.Contains(StatusAilmentTypes.OnSkillUse));

                foreach (var buff in buffs2Activate)
                {
                    if (buff.Types.Contains(StatusAilmentTypes.ActionIntegerValueRequired))
                    {
                        buff.TakeAction(this,Target,ref  damageDeal );
                        //what could take a value during initiating dmg when the class itself gets passed too?
                        //todo, delete it later when its tested and works
                        
                    }else if (buff.Types.Contains(StatusAilmentTypes.ActionStringValueRequired))
                    {
                        buff.TakeAction(this,Target,whichSkill);
                    }
                    else //else, call the default take action
                    {
                        buff.TakeAction(this,Target);
                    }
                    //todo, make this a function? i guess
                }
            }
            */

            return damageDeal;
        }
        else
        {
            throw new DealDmgError(whichSkill);
            return null;
        }
    }

    public bool ActionRequester(string whichSkill)
    {
        
        if ( (DateTime.Now.Subtract(GetLastGCDTrigger()).TotalMilliseconds>BaseGlobalCoolDownMs*Haste || !SkillLists[whichSkill].AffectedByGCD )
            && SkillLists.Keys.Contains(whichSkill))
        {
            SkillLists[whichSkill].RequestAction(this,Target);
            return true;
        }
        else
        {
            //todo log its on cooldown
            return false;
        }
    }

    public void TakeHealing(double? value)
    {
        double? healTake = value * GetDamageTakenMultiplier();
        if (healTake is not null  && healTake !=0)
        {
            int heal = (int)healTake;
            SetHealth(heal);
            PersonalCombatLog.LogAction(Name,heal,true);
        }
    }

    public double? DealHealing(string whichSkill)
    {
        if (SkillLists.Keys.Contains(whichSkill))
        {
            double? healindDone = (SkillLists[whichSkill].Value is not null 
                ? SkillLists[whichSkill].Value * GetStrength() * GetHealingDoneMultiplier()
                : 0);

            CheckForStatusAilment(StatusAilmentTypes.OnSkillUse, whichSkill, ref healindDone);
            

            return healindDone;
        }
        else
        {
            //todo log on error line, that it has no skill as such
            return null;
        }
    }
    
    
    
}