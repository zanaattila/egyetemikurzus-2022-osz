using D5BF9U.Containers;
using D5BF9U.Creatures;

namespace D5BF9U.AutoTasks;

public sealed class SkillTasker
{
    
    //id like to really use list
    /// <summary>
    /// returns the winning creature
    /// </summary>
    /// <param name="player"></param>
    /// <param name="npc"></param>
    /// <returns></returns>
    public async Task<Creature> SkillExecuter(Creature player, Creature npc)
    {
        SkillQue swapper = new SkillQue(null,null,null); 
        while (player.GetHealth() > 0 && npc.GetHealth() > 0)
        {
            if (player.SkillQues.TryDequeue(out swapper))
            {
                swapper.Skill.CastMe(swapper.Self,swapper.Target);
            }

            if (npc.SkillQues.TryDequeue(out swapper))
            {
                swapper.Skill.CastMe(swapper.Self, swapper.Target);
            }
        }
        return (npc.GetHealth() == 0 ? player : npc );
    }
}