using System.Collections.Generic;
using System.IO;
using System.Web;
using Newtonsoft.Json.Linq;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using System.Linq;
using Newtonsoft.Json;
using System.Reflection;
using System;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services
{
	public class LocalJsonFeedHearthstoneCardCacheFactory : HearthstoneCardCacheFactory
	{
		public LocalJsonFeedHearthstoneCardCacheFactory(IHearthstoneCardParser parser) : base(parser)
		{
		}

        protected override IEnumerable<ICard> PopulateCards(IHearthstoneCardParser parser)
		{
            // My preferred way to do this would be a DTO class but found that quite difficult 
            // as what we need to query ends up as property names, alternatively we could also use a JsonConvert.DeserialiseObject with a customer converter but I couldn't get that to work either.

            JToken cardSetsAsJson;
            List<ICard> cards = new List<ICard>();
            using (var reader = File.OpenText(HttpContext.Current.Server.MapPath("~/App_Data/cards.json")))
                cardSetsAsJson = JToken.Parse(reader.ReadToEnd());

            foreach (var cardSet in new[] { cardSetsAsJson["Basic"], cardSetsAsJson["Curse of Naxxramas"], cardSetsAsJson["Classic"], cardSetsAsJson["Goblins vs Gnomes"] })
                cards.AddRange(parser.ParseArray(cardSet.ToString()));

            return cards;
		}
	}
}