using System.Collections.Generic;
using AutoMapper;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;
using System.Linq;
using System.Web.Mvc;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services
{
	public class CardSearchService : ICardSearchService
	{
		private readonly IHearthstoneCardCache _cardCache;

		public CardSearchService(IHearthstoneCardCache cardCache)
		{
			_cardCache = cardCache;
		}

		public CardModel FindById(string id)
		{
			var card = _cardCache.GetById<ICard>(id);
			return Mapper.Map<ICard, CardModel>(card);
		}

		public SearchModel Search(SearchModel model)
		{
			var cards = _cardCache.Query(new SearchCardsQuery(model));

            var searchModel = new SearchModel()
            {
                CardCount = cards.Count(),
                TotalPages = cards.Count() / model.PageSize,
                Page = model.Page,
                PageSize = model.PageSize,
                Cards = Mapper.Map<IEnumerable<ICard>, IEnumerable<CardModel>>(cards.Skip(model.PageSize * model.Page).Take(model.PageSize)),
                SelectedPlayerClass = model.SelectedPlayerClass,
                Query = model.Query
            };

            return searchModel;
		}

		public IEnumerable<CardModel> GetHeroes()
		{
			var heroes = _cardCache.Query(new FindPlayableHeroCardsQuery());
			return Mapper.Map<IEnumerable<ICard>, IEnumerable<CardModel>>(heroes);
		}
	}
}
