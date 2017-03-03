using System;
using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;

namespace Storm.InterviewTest.Hearthstone.Core.Common.Queries
{
	public class SearchCardsQuery : CardListLinqQueryObject<ICard>
	{
        private readonly SearchModel model;

		public SearchCardsQuery(SearchModel model)
		{
            this.model = model;
		}

		protected override IEnumerable<ICard> ExecuteLinq(IQueryable<ICard> queryOver)
		{
            // Data returns case sensitive, convert to lowercase any value being queried, checking for nulls as ToLower() on null throws exception.
			return queryOver.Where(x => (x.Name == null ? x.Name.Contains(model.Query) : x.Name.ToLower().Contains(model.Query) 
                || x.Type.ToString().ToLower() == model.Query)
                && (x.PlayerClass == model.SelectedPlayerClass || !model.SelectedPlayerClass.HasValue));
		}
	}
}