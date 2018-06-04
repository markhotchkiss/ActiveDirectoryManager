using System;
using System.DirectoryServices;

namespace ISC.ActiveDirectory
{
    public class ActiveDirectoryClient : IActiveDirectoryClient
    {
        public string LdapConnectionString { get; set; }

        public void RestPassword(string domain, string username, string currentPassword, string newPassword)
        {
            try
            {
                //var ldapPath = "LDAP://192.168.1.xx";
                var directionEntry = new DirectoryEntry(LdapConnectionString, domain + "\\" + username, currentPassword);
                if (directionEntry != null)

                {
                    var search = new DirectorySearcher(directionEntry);
                    search.Filter = "(SAMAccountName=" + username + ")";

                    var result = search.FindOne();

                    var userEntry = result?.GetDirectoryEntry();

                    if (userEntry != null)
                    {
                        userEntry.Invoke("ChangePassword", new object[] { currentPassword, newPassword });
                        userEntry.CommitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}