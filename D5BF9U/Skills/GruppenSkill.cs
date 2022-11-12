using D5BF9U.Creatures;

namespace D5BF9U.Skills;

public sealed class GruppenSkill :ISkill
{
    public string Title => "Gruppen";
    public string Description => "Causes the player to heal via a quickie";
    public void CastMe(Creature self, Creature target)
    {
        ISkill[] valami = new ISkill[5];
        throw new NotImplementedException();
    }
}