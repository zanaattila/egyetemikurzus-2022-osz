using System.Collections.Concurrent;
using D5BF9U.Containers;
using D5BF9U.Creatures;
using D5BF9U.StatusAilments;

namespace D5BF9U.Skills;

public interface ISkill
{
    //todo, skills are not implemented, but in order to test they were implemented as default
    string Title { get; }
    string Description { get; }

    //and i just realized what i left out is the most important... values...
    int? Value { get; }
    
    double EffectiveRate { get; } //an easy way to nerf stuff, like from 90% it goes down to 60% and hit 33% less hahaha

    ///so dmg done could go like:
    /// give the skills value to SELF.DEALDMG
    /// magic happens there with numbers like dmg multiplier and such
    /// then effectiveness reduces that number and gives it to the TARGET.TAKEDMG
    /// so it can get damage
    /// ahaha, genius... wish...
    
    
    
    bool AffectedByGCD { get; }
    bool IsHarmful { get; }


    /*Console.WriteLine(" ms "+aD2ate.Subtract(aDate).TotalMilliseconds);
    Console.WriteLine("egyik"+(aD2ate.Subtract(aDate).TotalMilliseconds>4000));
    Console.WriteLine("egyik"+(aD2ate.Subtract(aDate).TotalMilliseconds>9000)); implement DateTime timestamp instead of stopwatch*/
    //DateTime LastUsed { get; set; } //For the project requires an immutable class, im going to keep these commented, and everything will depend on gcd
    //int InnerCD { get; } //given in millisec 

    void RequestAction(Creature self, Creature target);
    void CastMe(Creature self, Creature target);
}