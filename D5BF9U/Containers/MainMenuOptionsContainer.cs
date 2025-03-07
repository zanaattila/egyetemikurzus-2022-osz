using D5BF9U.Enums;

namespace D5BF9U.Containers;

public sealed class MainMenuOptionsContainer
{
    public MainMenuOptions SelectedOption { get; set; }

    public MainMenuOptionsContainer()
    {
        SelectedOption = MainMenuOptions.MainMenu;
    }
}