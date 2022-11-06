using D5BF9U.Creatures;

namespace D5BF9U.Skills;

public class InsultSkill : ISkill
{
    public string Title { get; }
    public string Description { get; }
    public void CastMe(Creature self, Creature target)
    {
        throw new NotImplementedException();
    }
}