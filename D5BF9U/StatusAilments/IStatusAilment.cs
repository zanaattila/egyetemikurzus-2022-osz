using System.Collections.Concurrent;
using D5BF9U.Containers;
using D5BF9U.Creatures;
using D5BF9U.Enums;

namespace D5BF9U.StatusAilments;

public interface IStatusAilment
{
     string Name { get; }
     int DurationMillisec { get; }
     int MaxTicks { get; }
     int CurrentTicks { get; set; } //duration/maxticks*currentticks -> current tick initializes at 1 and will go maxtick+1 
     bool IsHarmful { get; }
     bool IsDisplayed { get; } //should it show up on screen?
     StatusAilmentTypes[] Types { get; }
     DateTime TimeOfAcquisition { get; init; }


     void RequestAction(ConcurrentQueue<StatusAilmentQue> statusAilmentQues ,Creature self, Creature target);

     void Activate(Creature self, Creature target);
     void TakeAction(Creature self, Creature target);

     void Deactivate(Creature self, Creature target); 


}