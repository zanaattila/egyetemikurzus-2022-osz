using D5BF9U.Creatures;

namespace D5BF9U.Skills;

public interface ISkill
{
    //todo, skills are not implemented, but in order to test they were implemented as default, please do it later and dont forget it
    string Title { get; }
    string Description { get; }
    bool AffectedByGCD { get; }

    /*Console.WriteLine(" ms "+aD2ate.Subtract(aDate).TotalMilliseconds);
    Console.WriteLine("egyik"+(aD2ate.Subtract(aDate).TotalMilliseconds>4000));
    Console.WriteLine("egyik"+(aD2ate.Subtract(aDate).TotalMilliseconds>9000)); todo implement DateTime timestamp instead of stopwatch*/
    bool IsHarmful { get; }

    //DateTime LastUsed { get; set; } //For the project requires an immutable class, im going to keep these commented, and everything will depend on gcd
    //int InnerCD { get; } //given in millisec 
    void CastMe(Creature self, Creature target);
}