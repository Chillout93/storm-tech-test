using NUnit.Framework;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;
using Storm.InterviewTest.Hearthstone.Tests.Specification;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.InterviewTest.Hearthstone.Tests.Services
{
    public class WhenReadingIncorrectFileReturnNull : ContextSpecification
    {
        private string filename;
        private IMediaService mediaService;
        private bool result;

        protected override void Context()
        {
            filename = "EX1_066.png";
            mediaService = new MediaService(Directory.GetCurrentDirectory());
        }

        protected override void Because()
        {
            result = mediaService.ReadFileFromLocalOrSource(filename, false);
        }

        [Test]
        public void ShouldReturnExpectedSearchResults()
        {
            result.ShouldBeTrue();
        }
    }
}
