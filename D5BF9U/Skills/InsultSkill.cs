using System.Collections.Concurrent;
using D5BF9U.Containers;
using D5BF9U.Creatures;

namespace D5BF9U.Skills;

public class InsultSkill : ISkill
{
    public string Title => "Insult";

    private string[] _insults = 
    {
        "That's a face only a mother could love.","Szop-o-matic", "I thought ogres are only a myth!"
        , "Aaaah this smell, you know modern society can help with it", "No! Santa Claus doesn't exist!", "No, you dont need more rights, you need therapy."
        , "Damn you're so hairy, you speak wookie right? whrüüüü","You look just like a condom commercial" ,"What is this nightmare that's staring at me"
    };

    private string[] _sufferings =
    {
        "Ouch, this huuuurts", "Mamaaaaa Q.Q im being huuurt", "No bully please, leave me alone!"
        ,"Im so hurt, i criie qqqqqqq","YU LIEEE, NOOO, KANT BEE!","why u do dis to me? T-T"
        ,"mamaaaaa mamaaaaa T_T_T_T_TT_T", "Im just only saying ,- FUCK YUUUU", "I dyont even deserwe dis T_T_T_T"
    };
    
    public bool AffectedByGCD => true;
    public bool IsHarmful => true;
    public string Description => "Insulting the target 3 times over 6 seconds." +
                                 " The way this works is you and the target both get buff, your buff gonna change your text you say " +
                                 "and your targets buff gon get his changed and take damage";
    

    public void RequestAction(Creature self, Creature target)
    {
        //in theory since they all are from the same interface then they should be able to be stored, but i hope conversion will go smooth and nut just throw a random null exception at me
        SkillQue queMe = new SkillQue(this, self, target);
        self.SkillQues.Enqueue(queMe);
    }

    public void CastMe(Creature self, Creature target)
    {
        throw new NotImplementedException();
    }
    
    
}