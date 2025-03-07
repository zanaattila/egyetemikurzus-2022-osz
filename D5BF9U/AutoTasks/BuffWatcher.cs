using System.Collections;
using D5BF9U.Creatures;
using D5BF9U.Enums;

namespace D5BF9U.AutoTasks;

public sealed class BuffWatcher
{
    
    
    public async Task<Creature> BuffTakeAction(Creature player, Creature npc)
    {
        await Task.Run(() =>
        {
            while (player.GetHealth() > 0 && npc.GetHealth() > 0)
            {
                if (!player.StatusAilments.IsEmpty)
                {
                    foreach (var key in player.StatusAilments.Keys)
                    {
                        if (player.StatusAilments[key].MaxTicks is not null)
                        {
                            if (player.StatusAilments[key].Types.Contains(StatusAilmentTypes.OverTimeEffect))
                            {
                                if ((player.StatusAilments[key].DurationMillisec / player.StatusAilments[key].MaxTicks) *
                                    player.StatusAilments[key].CurrentTicks
                                    < DateTime.Now.Subtract(player.StatusAilments[key].TimeOfAcquisition).TotalMilliseconds)
                                {
                                    if (player.StatusAilments[key].CurrentTicks <= player.StatusAilments[key].MaxTicks)
                                    {
                                        player.StatusAilments[key].TakeAction(player, player.Target);
                                    }
                                    else
                                    {
                                        //doesnt deactivate
                                        // player.StatusAilments[key].Deactivate(player, player.Target);
                                    }


                                    //todo i just now realized that since i store the target, it should no longer be needed to pass it as param...
                                }
                            }
                            
                        }

                        if ( player.StatusAilments.ContainsKey(key))
                        {
                            if ( (player.StatusAilments[key].DurationMillisec < DateTime.Now.Subtract(player.StatusAilments[key].TimeOfAcquisition).TotalMilliseconds ))
                            {
                                player.StatusAilments[key].Deactivate(player, player.Target);
                            }else if (player.StatusAilments[key].MaxTicks is not null )
                            {
                                if(player.StatusAilments[key].MaxTicks< player.StatusAilments[key].CurrentTicks)
                                {
                                    player.StatusAilments[key].Deactivate(player, player.Target);
                                }
                            }
                        }
                    }
                }

                //this is ugly, todo -> refactor later
                if (!npc.StatusAilments.IsEmpty)
                {
                    foreach (var key in npc.StatusAilments.Keys)
                    {
                        if (npc.StatusAilments[key].MaxTicks is not null)
                        {
                            if (npc.StatusAilments[key].Types.Contains(StatusAilmentTypes.OverTimeEffect))
                            {
                                if ((npc.StatusAilments[key].DurationMillisec / npc.StatusAilments[key].MaxTicks) *
                                    npc.StatusAilments[key].CurrentTicks
                                    < DateTime.Now.Subtract(npc.StatusAilments[key].TimeOfAcquisition).TotalMilliseconds)
                                {
                                    if (npc.StatusAilments[key].CurrentTicks <= npc.StatusAilments[key].MaxTicks)
                                    {
                                        npc.StatusAilments[key].TakeAction(npc, npc.Target);
                                    }
                                    else
                                    {
                                        //npc.StatusAilments[key].Deactivate(npc, npc.Target);
                                    }
                                }
                            }
                        }

                        if (npc.StatusAilments.ContainsKey(key))
                        {
                            if ( (npc.StatusAilments[key].DurationMillisec < DateTime.Now.Subtract(npc.StatusAilments[key].TimeOfAcquisition).TotalMilliseconds ))
                            {
                                npc.StatusAilments[key].Deactivate(npc, npc.Target);
                            }else if (npc.StatusAilments[key].MaxTicks is not null )
                            {
                                if(npc.StatusAilments[key].MaxTicks< npc.StatusAilments[key].CurrentTicks)
                                {
                                    npc.StatusAilments[key].Deactivate(npc, npc.Target);
                                }
                            }
                        }
                    }
                }
                
                
                //problem might be it no longer exists and bugs
                /*foreach (var VARIABLE in COLLECTION)
                {
                    
                }*/
            }
            
        });
        return (npc.GetHealth() == 0 ? player : npc );
    }
}