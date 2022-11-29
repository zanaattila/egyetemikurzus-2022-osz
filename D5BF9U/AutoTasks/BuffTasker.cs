using D5BF9U.Containers;
using D5BF9U.Creatures;

namespace D5BF9U.AutoTasks;

public sealed class BuffTasker
{
    
    public async Task<Creature> BuffExecuter(Creature player, Creature npc)
    {
        StatusAilmentQue swapper = new StatusAilmentQue(null,null,null); //hope you work
        while (player.GetHealth() > 0 && npc.GetHealth() > 0)
        {
            if (player.StatusAilmentQues.TryDequeue(out swapper))
            {
                swapper.StatusAilment.Activate(swapper.Self,swapper.Target);
            }

            if (npc.StatusAilmentQues.TryDequeue(out swapper))
            {
                swapper.StatusAilment.Activate(swapper.Self, swapper.Target);
            }
        }
        return (npc.GetHealth() == 0 ? player : npc );
    }
    
}