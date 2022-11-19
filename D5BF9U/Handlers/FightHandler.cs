using System.Collections.Concurrent;
using D5BF9U.Containers;

namespace D5BF9U.Handlers;

public sealed class FightHandler
{
    public ConcurrentQueue<SkillQue> SkillQues { get; set; }
    public ConcurrentQueue<StatusAilmentQue> BuffQues { get; set; }
    //todo this will handle the fight between 2 creatures: skills in ConcurrectQueue, and buffs on a constant watch, 
    
    
}