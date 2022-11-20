using System.Collections.Concurrent;
using D5BF9U.Containers;
using D5BF9U.Creatures;
using D5BF9U.Enums;

namespace D5BF9U.StatusAilments;

public sealed class InsultSpeechAilment : IStatusAilment
{
    public string Name => "Insult Texts";
    public int DurationMillisec => 6000;
    public int? MaxTicks => 3;
    public int CurrentTicks { get; set; }
    public bool IsHarmful => false;
    public bool IsDisplayed => false;
    public string[] Speech { get; set;}
    public int SpeechIndex { get; set; } // yes really
        //public bool TakeActionOnActivation 
    public StatusAilmentTypes[] Types => new[] { StatusAilmentTypes.ScriptLike };
    public DateTime TimeOfAcquisition { get; init; }

    public InsultSpeechAilment(string[] speechList)
    {
        Speech = (string[]) speechList.Clone();
        CurrentTicks = 0;
        SpeechIndex = 0;
        TimeOfAcquisition = new DateTime();
        TimeOfAcquisition = DateTime.Now;
        
    }
    
    public void RequestAction(Creature self, Creature target)
    {
        StatusAilmentQue ailmentQue = new StatusAilmentQue(this, self, target);
        self.StatusAilmentQues.Enqueue(ailmentQue);
    }

    public void Activate(Creature self, Creature target)
    {
        throw new NotImplementedException();
    }

    public void TakeAction(Creature self, Creature target)
    {
        throw new NotImplementedException();
    }

    public void TakeAction(Creature self, Creature target, ref  double? value)
    {
        throw new NotImplementedException();
    }

    public void TakeAction(Creature self, Creature target, string value)
    {
        throw new NotImplementedException();
    }

    public void Deactivate(Creature self, Creature target)
    {
        throw new NotImplementedException();
    }
}