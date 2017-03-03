using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
    public class MediaController : Controller
    {
	    private const string mediaSourceUrl = "http://wow.zamimg.com/images/hearthstone/cards/enus/medium/{0}.png";

        // GET: Media
        public ActionResult Card(string id)
        {
	        var localBaseDirectory = Server.MapPath("~/App_Data/media/");
            var mediaService = new MediaService(localBaseDirectory);

            var fileName = mediaService.ReadFileFromLocalOrSource($"{id}.png");
			return File(Path.Combine(localBaseDirectory, $"{id}.png"), "image/png");
		}
    }
}