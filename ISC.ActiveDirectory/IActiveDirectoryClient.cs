namespace ISC.ActiveDirectory
{
    public interface IActiveDirectoryClient : IADConnection
    {
        void RestPassword(string domain, string username, string currentPassword, string newPassword);
    }
}
