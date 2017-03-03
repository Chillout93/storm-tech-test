using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;

namespace Storm.InterviewTest.Hearthstone.Controllers
{
    public class CardsController : Controller
    {
		public ActionResult Index()
		{
            var searchService = new CardSearchService(MvcApplication.CardCache);
			var searchModel = searchService.Search(new SearchModel());

			return View(searchModel);
		}

        [HttpPost]
        public ActionResult Index(SearchModel model)
        {
            var searchService = new CardSearchService(MvcApplication.CardCache);
            var searchModel = searchService.Search(model);

            return View(searchModel);
        }
	}
}