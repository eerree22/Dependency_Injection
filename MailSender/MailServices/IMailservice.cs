namespace MailServices
{
    public interface IMailservice
    {
        void Send(string title, string to, string body);
    }
}