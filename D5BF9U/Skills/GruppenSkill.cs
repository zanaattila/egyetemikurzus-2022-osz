using System.Collections.Concurrent;
using D5BF9U.Containers;
using D5BF9U.Creatures;

namespace D5BF9U.Skills;

public sealed class GruppenSkill :ISkill
{
    public string Title => "Gruppen";
    public bool AffectedByGCD => true;
    public int? Value => 3;
    public double EffectiveRate => 0.69;
    public bool IsHarmful => false;
    public string Description => "Causes the player to heal via a quickie gruppensex";
    
    
    public void RequestAction( Creature self, Creature target)
    {
        SkillQue queMe = new SkillQue(this, self, target);
        self.SkillQues.Enqueue(queMe);
    }

    public void CastMe(Creature self, Creature target)
    {
        //it would be fun to play sound effects based on skills like this isnt it?
        self.TakeHealing(self.DealHealing(Title));
        self.SetLastGCDTrigger();
    }
}