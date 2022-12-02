using System.ComponentModel.Design.Serialization;
using D5BF9U.Creatures;

namespace D5BF9U.Skills;

public sealed class CatClawSkill : ISkill
{
    public string Title => "CatClaw";

    public string Description =>
        "Nyanyame nyanyajyuunyanya-do no nyarabi de nyakunyaku inyanyaku nyanyahan nyanyadai nyanynaku nyarabete nyaganyagame.";

    public int? Value => 4;
    public double EffectiveRate => 0.69;
    public bool AffectedByGCD => false;
    public bool IsHarmful => true;
    public void RequestAction(Creature self, Creature target)
    {
        throw new NotImplementedException();
    }

    public void CastMe(Creature self, Creature target)
    {
        throw new NotImplementedException();
    }
}