using System.Collections.Concurrent;
using D5BF9U.Containers;
using D5BF9U.Creatures;

namespace D5BF9U.Skills;

public sealed class MagicSkill : ISkill
{
    public string Title => "Magic";
    public bool AffectedByGCD => true;
    public bool IsHarmful => true;

    public string Description =>
        "Getsugatensho! Fayar bollo! Shadow Bolt! Pyroblast! Lightning bolt! Soulfiya! Kamehameha! You name it, i got it, i cast it. " +
        "And just like all the time in games like these, ill just call it \'\'magic\'\' get away with it.";
    
    public void RequestAction(ConcurrentQueue<SkillQue> skillQues, Creature self, Creature target)
    {
        //in theory since they all are from the same interface then they should be able to be stored, but i hope conversion will go smooth and nut just throw a random null exception at me
        SkillQue queMe = new SkillQue(this, self, target);
        skillQues.Enqueue(queMe);
    }
    
    public void CastMe(Creature self, Creature target)
    {
        throw new NotImplementedException();
    }
}