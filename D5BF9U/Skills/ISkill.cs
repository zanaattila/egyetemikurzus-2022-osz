using D5BF9U.Creatures;

namespace D5BF9U.Skills;

public interface ISkill
{
    //todo, skills are not implemented, but in order to test they were implemented as default, please do it later and dont forget it
    string Title { get; }
    string Description { get; }
    void CastMe(Creature self, Creature target);
}