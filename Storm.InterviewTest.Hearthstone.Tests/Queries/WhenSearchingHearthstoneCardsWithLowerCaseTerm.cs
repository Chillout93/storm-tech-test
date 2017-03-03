using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Storm.InterviewTest.Hearthstone.Core.Common.Queries;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using Storm.InterviewTest.Hearthstone.Tests.Base;
using Storm.InterviewTest.Hearthstone.Tests.Specification;

namespace Storm.InterviewTest.Hearthstone.Tests.Queries
{
    [Category("Cache")]
    public class WhenSearchingHearthstoneCardsWithLowerCaseTerm : HearthstoneCardCacheContext
    {
        protected IEnumerable<ICard> _result;
        protected string query;

        protected override IEnumerable<ICard> Cards()
        {
            return new List<ICard>(base.Cards())
            {
                CreateRandomMinionCardWithId("99", minion =>
                {
                    minion.Name = "acidic swamp ooze";
                    minion.Faction = FactionTypeOptions.Alliance;
                    minion.PlayerClass = "Mage";
                    minion.Rarity = RarityTypeOptions.Legendary;
                })
            };
        }

        protected override void Context()
        {
            query = "mage";
        }

        protected override void Because()
        {
            _result = _hearthstoneCardCache.Query(new SearchCardsQuery(query));
        }

        [Test]
        public void ShouldReturnExpectedSearchResults()
        {
            _result.Count().ShouldEqual(1);
            _result.First().Name.ShouldEqual("acidic swamp ooze");
            _result.First().PlayerClass.ShouldEqual("Mage");
        }
    }
}
