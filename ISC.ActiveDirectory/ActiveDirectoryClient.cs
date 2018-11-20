using System;
using System.Configuration;
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
                ChangeMyPassword(domain, username, currentPassword, newPassword);
            }
        }

        public void ChangeMyPassword(string domainName, string userName, string currentPassword, string newPassword)
        {
            var adminUser = ConfigurationManager.AppSettings["LDAPAdminUser"];
            var adminPass = ConfigurationManager.AppSettings["LDAPAdminPass"];

            var de = new DirectoryEntry(LdapConnectionString, domainName + "\\" + adminUser, adminPass);
            var deSearch = new DirectorySearcher(de)
            {
                Filter = "(SAMAccountName=" + userName + ")"
            };

            var directoryEntry = deSearch.FindOne();

            var item = directoryEntry.GetDirectoryEntry();
            item.Invoke("SetPassword", new object[] { newPassword });

            item.Close();
        }
    }
}