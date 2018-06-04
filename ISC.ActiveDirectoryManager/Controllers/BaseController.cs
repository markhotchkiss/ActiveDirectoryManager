using ISC.ActiveDirectoryManager.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ISC.ActiveDirectoryManager.Controllers
{
    public class BaseController : Controller
    {
        public void Success(string message, bool dismissable = false, bool permanent = false)
        {
            AddAlert(AlertHelper.AlertStyles.Success, message, dismissable, permanent);
        }

        public void Information(string message, bool dismissable = false, bool permanent = false)
        {
            AddAlert(AlertHelper.AlertStyles.Information, message, dismissable, permanent);
        }

        public void Warning(string message, bool dismissable = false, bool permanent = false)
        {
            AddAlert(AlertHelper.AlertStyles.Warning, message, dismissable, permanent);
        }

        public void Danger(string message, bool dismissable = false, bool permanent = false)
        {
            AddAlert(AlertHelper.AlertStyles.Danger, message, dismissable, permanent);
        }

        private void AddAlert(string alertStyle, string message, bool dismissable, bool permanent)
        {
            var alerts = TempData.ContainsKey(AlertHelper.Alert.TempDataKey)
                ? (List<AlertHelper.Alert>)TempData[AlertHelper.Alert.TempDataKey]
                : new List<AlertHelper.Alert>();

            alerts.Add(new AlertHelper.Alert
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable,
                Permanent = permanent
            });

            TempData[AlertHelper.Alert.TempDataKey] = alerts;
        }

    }
}