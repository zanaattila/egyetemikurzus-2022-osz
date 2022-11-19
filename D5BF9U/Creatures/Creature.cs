using System.Collections.Concurrent;
using System.Diagnostics;
using D5BF9U.Containers;
using D5BF9U.Skills;
using D5BF9U.StatusAilments;

namespace D5BF9U.Creatures;

public sealed class Creature
{
    public string Name { get; init; }
    public string SpeechBox { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Haste { get; set; }
    public double DamageMultiplier { get; set; }
    public bool IsImmune { get; set; }
    public CreatureLog PersonalCombatLog { get; set; }
    public DateTime GlobalCD { get; set; }
    public ConcurrentQueue<StatusAilmentQue> StatusAilmentQues { get; set; }
    public ConcurrentQueue<SkillQue> SkillQues { get; set; }
    public Dictionary<string,IStatusAilment> StatusAilments { get; set; }
    public Dictionary<string,ISkill> SkillLists { get; set; }
    //todo implement player; todo strings init them
    
    
    
}