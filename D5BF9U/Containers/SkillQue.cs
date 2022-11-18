using D5BF9U.Creatures;
using D5BF9U.Skills;

namespace D5BF9U.Containers;


//this is an immutable class as i see it, cos the reference of the creature will not change, tho the creatures value can change, hmmmmm todo ask if this is an immutable
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