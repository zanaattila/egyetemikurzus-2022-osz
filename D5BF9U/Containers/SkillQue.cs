using D5BF9U.Creatures;
using D5BF9U.Skills;

namespace D5BF9U.Containers;

public sealed class SkillQue
{
    public ISkill Skill { get; }
    public Creature Self { get; }
    public Creature Target { get; }

    public SkillQue(ISkill skill, Creature self, Creature target)
    {
        Skill = skill;
        Self = self;
        Target = target;
    }
}