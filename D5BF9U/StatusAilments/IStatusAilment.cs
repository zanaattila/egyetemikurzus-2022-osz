using System.Collections.Concurrent;
using D5BF9U.Creatures;
using D5BF9U.Enums;

namespace D5BF9U.StatusAilments;

public interface IStatusAilment
{
     string Name { get; }
     int DurationMillisec { get; }
     int MaxTicks { get; set; }
     int CurrentTicks { get; set; } //duration/maxticks*currentticks -> current tick initializes at 1 and will go maxtick+1 
     bool IsHarmful { get; }
     StatusAilmentTypes Type { get; }
     DateTime TimeOfAcquisition { get; init; }


     void Activate(ConcurrentBag<IStatusAilment> buffhandler ,Creature self, Creature target);

     void TakeAction(Creature self, Creature target);

     void Deactivate(Creature self, Creature target); 


}