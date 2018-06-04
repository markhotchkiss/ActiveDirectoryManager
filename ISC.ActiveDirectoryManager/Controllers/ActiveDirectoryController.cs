using ISC.ActiveDirectory;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace ISC.ActiveDirectoryManager.Controllers
{
    public class ActiveDirectoryController : BaseController
    {
        public ActionResult ResetPassword()
        {
            return View();
        }

        // GET: ActiveDirectory
        public ActionResult DoResetPassword(string domain, string username, string currentPassword, string newPassword, string verifyPassword)
        {
            try
            {
                if (newPassword != verifyPassword)
                {
                    Danger("Passwords do not match, try again.");
                    return View("ResetPassword");
                }

                var adConnect = new ActiveDirectoryClient { LdapConnectionString = ConfigurationManager.AppSettings["ActiveDirectoryLdapConnectionString"] };

                adConnect.RestPassword(domain, username, currentPassword, newPassword);

                Success("Successfully changed password.");

                return View("ResetPassword");
            }
            catch (Exception e)
            {
                Danger(e.Message + "<br />" + e.InnerException);
                return View("ResetPassword");
            }
        }
    }
}