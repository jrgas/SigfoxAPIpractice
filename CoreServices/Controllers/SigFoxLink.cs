using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureMessageQueue;
using Microsoft.AspNetCore.Mvc;

namespace CoreServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SigFoxLinkController : ControllerBase
    {
        // TRY running this this website in debug mode and then open this url (https://localhost:44307/api/sigfoxlink/1223)
        // Can use this to test if you api is working
        // GET api/SigFoxLink/{id}   <-- replace the id with value you want 
        [HttpGet("{id}")]
        public  ActionResult<string> Test(string id)
        {
            string serviceBusConnectionString = "Endpoint=sb://sigfoxpractice.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=cOktybDv9Z0wxCj+XUTAW5E1CqtpvcNPHH1BJ9+XNiI=";
            string queueName = "sigfoxpracticequeue";
            var messageBussHandler = new AzureMessageBussHandler(serviceBusConnectionString, queueName);
            messageBussHandler.QueueMessage(id).GetAwaiter();
            return "value:" + id;
        }

        // This is the one that sig fox will send message to as it a post
        // POST api/SigFoxLink/{id}
        [HttpPost("{id}")]
        public void Post(string id)
        {
            using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
            {
                string body = stream.ReadToEnd();
            }
        }
    }
}
