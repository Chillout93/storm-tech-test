using System;
using System.Collections.Generic;
using System.Linq;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries.Base;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;

namespace Storm.InterviewTest.Hearthstone.Core.Common.Queries
{
	public class SearchCardsQuery : CardListLinqQueryObject<ICard>
	{
		private readonly string _q;

		public SearchCardsQuery(string q)
		{
			_q = string.IsNullOrEmpty(q) ? string.Empty : q.ToLower();
		}

		protected override IEnumerable<ICard> ExecuteLinq(IQueryable<ICard> queryOver)
		{
            // Data returns case sensitive, convert to lowercase any value being queried, checking for nulls as ToLower() on null throws exception.
			return queryOver.Where(x => x.Name == null ? x.Name.Contains(_q) : x.Name.ToLower().Contains(_q) 
                || x.Type.ToString().ToLower() == _q 
                || (x.PlayerClass == null ? x.PlayerClass : x.PlayerClass.ToLower()) == _q);
		}
	}
}