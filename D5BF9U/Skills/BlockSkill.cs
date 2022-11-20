using System.Collections.Concurrent;
using D5BF9U.Containers;
using D5BF9U.Creatures;
using D5BF9U.StatusAilments;

namespace D5BF9U.Skills;

public class BlockSkill : ISkill
{
    public string Title => "Block";
    public bool AffectedByGCD => true;
    public bool IsHarmful => false;

    public int? Value => null; //could've been null tho..., nah nvm
    public double EffectiveRate => 0;

    public string Description =>
        "I'm a fan of Devil May Cry, so I tried to make a skill like royal guard, but unlike in dmc3," +
        " you will have double the time (0.2 sec) to perform a perfect block and theres no penalty for miss timing," +
        " your block \"buff\" will just simply expire.  On a successful counter it will increase your haste (reduce global cooldown by 50%)" +
        " for 4.2 seconds and will enter a trance like state where damage done is increases by 400% and if block pressed again, it will return" +
        " the amount of damage blocked threefold when pressed and trigger no global cooldown ";
    
    public void RequestAction(Creature self, Creature target)
    {
        //in theory since they all are from the same interface then they should be able to be stored, but i hope conversion will go smooth and nut just throw a random null exception at me
        SkillQue queMe = new SkillQue(this, self, target);
        self.SkillQues.Enqueue(queMe);
    }
    
    public void CastMe(Creature self, Creature target)
    {
        BlockBuff buffUp = new BlockBuff();
        buffUp.RequestAction(self,target);
    }
}