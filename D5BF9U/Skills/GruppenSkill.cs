using System.Collections.Concurrent;
using D5BF9U.Containers;
using D5BF9U.Creatures;

namespace D5BF9U.Skills;

public sealed class GruppenSkill :ISkill
{
    public string Title => "Gruppen";
    public bool AffectedByGCD => true;
    public bool IsHarmful => false;
    public string Description => "Causes the player to heal via a quickie gruppensex";
    
    
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