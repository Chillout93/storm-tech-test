﻿using System.Collections.Generic;
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
    public class WhenSearchingHearthstoneCardsWithPlayerClassFilter : HearthstoneCardCacheContext
    {
        protected IEnumerable<ICard> _result;
        protected SearchModel query;

        protected override IEnumerable<ICard> Cards()
        {
            return new List<ICard>(base.Cards())
            {
                CreateRandomMinionCardWithId("99", minion =>
                {
                    minion.Name = "my special card";
                    minion.Faction = FactionTypeOptions.Alliance;
                    minion.Rarity = RarityTypeOptions.Legendary;
                    minion.PlayerClass = PlayerClass.NoClass;
                })
            };
        }

        protected override void Context()
        {
            query = new SearchModel()
            {
                Query = "special",
                SelectedPlayerClass = PlayerClass.NoClass
            };
        }

        protected override void Because()
        {
            _result = _hearthstoneCardCache.Query(new SearchCardsQuery(query));
        }

        [Test]
        public void ShouldReturnExpectedSearchResults()
        {
            _result.Count().ShouldEqual(1);
            _result.First().Name.ShouldEqual("my special card");
        }
    }
}