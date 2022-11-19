using System.Collections.Concurrent;
using D5BF9U.Containers;
using D5BF9U.Creatures;
using D5BF9U.Enums;

namespace D5BF9U.StatusAilments;

public interface IStatusAilment
{
     string Name { get; }
     int DurationMillisec { get; }
     int? MaxTicks { get; }
     int CurrentTicks { get; set; } //duration/maxticks*currentticks -> current tick initializes at 1 except for ones that do initial action. 
     bool IsHarmful { get; }
     bool IsDisplayed { get; } //should it show up on screens buff list with barchart?
     StatusAilmentTypes[] Types { get; }
     DateTime TimeOfAcquisition { get; init; }
     
     //public bool TakeActionOnActivation { get; } might not need it
     


     void RequestAction(Creature self, Creature target);

     void Activate(Creature self, Creature target);
     
     void TakeAction(Creature self, Creature target); //nevermind, ill just overload it 
     
     void TakeAction(Creature self, Creature target, int value); //instead of overloading, im making it optional
     void TakeAction(Creature self, Creature target, string value);
     //actually i do have to overload it, with string >< for the name of the skill, could use skill ID,..... 
     //but without db auto increment id just simply miss track of which was the last one ><

     void Deactivate(Creature self, Creature target); 


}