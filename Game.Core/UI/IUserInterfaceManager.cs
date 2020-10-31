namespace Game.Core.UI
{
    public interface IUserInterfaceManager
    {
        void SetInterface(UserInterface ui);
        UserInterface CreateUserInterface(bool set);
    }
}