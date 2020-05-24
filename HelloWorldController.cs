using System.Web.Mvc;
using TCAdmin.SDK.Web.MVC.Controllers;

namespace Game
{
    public class HelloWorldModel
    {
        public string Message { get; set; }
        public string ServiceStartedOn { get; set; }
        public TCAdmin.GameHosting.SDK.Objects.Service Service { get; set; }
    }

    public class HelloWorldController : BaseServiceController
    {
        [HttpGet]
        [ParentAction("Service", "Home")]
        public ActionResult Index(int id)
        {
            //Make sure the user has permission this feature
            EnforceFeaturePermission("FileManager");

            var model = new HelloWorldModel();
            //Gets the current service
            model.Service = TCAdmin.GameHosting.SDK.Objects.Service.GetSelectedService();
            //Sets the message variable
            model.Message = "Hello World!";
            //Gets information about the service startup
            model.ServiceStartedOn = string.Format($"{model.Service.ConnectionInfo} was started on {TCAdmin.SDK.Misc.Dates.UniversalTimeToCurrentTimeZone(model.Service.Status.StartTime)} with process id {model.Service.Status.ProcessId}");


            return View("HelloWorld", model);
        }
    }
}
