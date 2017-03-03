using System.Collections.Generic;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards
{
	public interface ICardSearchService
	{
		CardModel FindById(string id);
		SearchModel Search(SearchModel model);
		IEnumerable<CardModel> GetHeroes();
	}
}