using System;
using Newtonsoft.Json;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain
{
	public abstract class Card : ICard
	{
		public string Id { get; private set; }
		public string Name { get; set; }
		public CardTypeOptions Type { get; private set; }
		public int Cost { get; set; }
		public int Attack { get; set; }
		public PlayerClass PlayerClass { get; set; }
		public string Text { get; set; }
		public RarityTypeOptions Rarity { get; set; }
		public FactionTypeOptions Faction { get; set; }

		public Uri ImageUrl
		{
			get { return new Uri(string.Format("/media/card/{0}", Id), UriKind.Relative); }
		}

		protected Card(string id, CardTypeOptions type)
		{
			Id = id;
			Type = type;
		}
	}
}
