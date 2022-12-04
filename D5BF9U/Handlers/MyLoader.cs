using System.Collections.Concurrent;
using System.Diagnostics;
using D5BF9U.Enums;
using D5BF9U.Globals;
using D5BF9U.Skills;
using Spectre.Console;

namespace D5BF9U.Handlers;

public sealed class MyLoader
{
    public static void FirstLoad()
    {
        AnsiConsole.Status()
            .Start("[mediumvioletred]loading deviancy[/]", ctx => 
            {
                Globals.Globals.MySwitch = 0;
                //todo for production the value reduced
                Thread.Sleep(100);
                AnsiConsole.MarkupLine("are you sure you want to play this?");
                Thread.Sleep(200);
                AnsiConsole.MarkupLine("It contains [red]18+[/] elements");
                Thread.Sleep(200);
                AnsiConsole.MarkupLine("yes, even tho its just some ascii stuff");
                Thread.Sleep(200);
            });

        var answer = AnsiConsole.Prompt(new TextPrompt<string>("are you really want to run this game?")
            .ChoicesStyle(new Style().Foreground(Color.Orange1))
            .AddChoices(new[]
            {
                "mhmm", "nah im good", "sure", "oh hell no!"
            }));
        
        if (answer.Equals("mhmm")|| answer.Equals("sure"))
        {
            AnsiConsole.MarkupLine("[magenta]as you wish[/]");
            Thread.Sleep(1500);
            AnsiConsole.MarkupLine("[magenta]then please, cum in[/]");
            Thread.Sleep(3000);
            Globals.Globals.MySwitch = LevelAdjustingSwitch.MainMenu;
        }
        else
        {
            AnsiConsole.MarkupLine("understandable");
            Thread.Sleep(900);
            AnsiConsole.MarkupLine("have a nice day");
            Thread.Sleep(1300);
            Globals.Globals.MySwitch = LevelAdjustingSwitch.Exit;
        }
    }
    
    public static ConcurrentDictionary<string, ISkill> CreateSpellbook(string[] skillNames)
    {
        SkillLoader skillLoader = new SkillLoader();
        ConcurrentDictionary<string, ISkill> creatureSkills = new ConcurrentDictionary<string, ISkill>();
        foreach (var skill in skillNames)
        {
            if (skillLoader.Skills.ContainsKey(skill))
            {
                creatureSkills.TryAdd(skill, skillLoader.Skills[skill]);
            }
        }

        return creatureSkills;

    }

    
    
}