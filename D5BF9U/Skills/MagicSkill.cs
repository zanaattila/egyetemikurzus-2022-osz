using System.Collections.Concurrent;
using D5BF9U.Containers;
using D5BF9U.Creatures;

namespace D5BF9U.Skills;

public sealed class MagicSkill : ISkill
{
    public string Title => "Magic";
    public bool AffectedByGCD => true;
    public bool IsHarmful => true;

    public int? Value => 3;

    public double EffectiveRate => 0.33;

    public string Description =>
        "Getsugatensho! Fayar bollo! Shadow Bolt! Pyroblast! Lightning bolt! Soulfiya! Kamehameha! You name it, i got it, i cast it. " +
        "And just like all the time in games like these, ill just call it \'\'magic\'\' get away with it.";
    
    public void RequestAction(Creature self, Creature target)
    {
        SkillQue queMe = new SkillQue(this, self, target);
        self.SkillQues.Enqueue(queMe);
    }
    
    public void CastMe(Creature self, Creature target)
    {
        target.TakeDmg(self.DealDmg(Title));
        self.SetLastGCDTrigger();
    }
}