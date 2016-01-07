namespace SeleniumTestConsole.Interfaces
{
    public interface ILogin
    {
        void openDefaultURL();

        void doLogin(string username, string password);

        bool IsSuccessful();
        bool IsValidAccount();
    }
}