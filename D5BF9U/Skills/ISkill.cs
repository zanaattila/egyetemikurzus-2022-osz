using D5BF9U.Creatures;

namespace D5BF9U.Skills;

public interface ISkill
{
    string Title { get; }
    string Description { get; }
    void CastMe(Creature self, Creature target);
}