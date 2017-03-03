using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Domain;
using System.Collections;
using System.Collections.Generic;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Models
{
    public class SearchModel
    {
        private string query = "";
        public string Query { get { return query == null ? "" : query.ToLower(); } set { query = value; } }
        public PlayerClass? SelectedPlayerClass { get; set; }
        public IEnumerable<CardModel> Cards { get; set; }
    }
}