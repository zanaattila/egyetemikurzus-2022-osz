using System.Diagnostics;
using D5BF9U.Skills;
using D5BF9U.StatusAilments;

namespace D5BF9U.Creatures;

public sealed class Creature
{
    public string Name { get; init; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Haste { get; set; }
    public bool IsImmune { get; set; }
    public DateTime GlobalCD { get; set; }
    public Dictionary<string,IStatusAilment> StatusAilments { get; set; }
    public Dictionary<string,ISkill> skillLists { get; set; }
    //todo implement player
    public void valami()
    {
        
    }
}