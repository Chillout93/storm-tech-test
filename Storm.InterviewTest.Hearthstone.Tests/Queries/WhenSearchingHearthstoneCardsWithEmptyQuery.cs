using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Tests.Base;
using Storm.InterviewTest.Hearthstone.Tests.Specification;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models;

namespace Storm.InterviewTest.Hearthstone.Tests.Queries
{
	[Category("Cache")]
	public class WhenSearchingHearthstoneCardsWithEmptyQuery : HearthstoneCardCacheContext
	{
		protected IEnumerable<ICard> _result;
		protected SearchModel query;

		protected override void Context()
		{
            query = new SearchModel()
            {
                Cards = null,
                Query = string.Empty,
                SelectedPlayerClass = null
            };
		}

		protected override void Because()
		{
			_result = _hearthstoneCardCache.Query(new SearchCardsQuery(query));
		}

		[Test]
		public void ShouldReturnExpectedSearchResults()
		{
			_result.Count().ShouldEqual(Cards().Count());
		}
	}
}