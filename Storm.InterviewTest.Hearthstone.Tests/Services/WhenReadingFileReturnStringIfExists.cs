using NUnit.Framework;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards;
using Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services;
using System.IO;
using Storm.InterviewTest.Hearthstone.Tests.Specification;

namespace Storm.InterviewTest.Hearthstone.Tests.Services
{
    public class WhenReadingFileReturnStringIfExists : ContextSpecification
    {
        private string filename;
        private IMediaService mediaService;
        private bool result;

        protected override void Context()
        {
            filename = "magecard.png";
            mediaService = new MediaService(Directory.GetCurrentDirectory());
        }

        protected override void Because()
        {
            result = mediaService.ReadFileFromLocalOrSource(filename, false);
        }

        [Test]
        public void ShouldReturnExpectedSearchResults()
        {
            result.ShouldBeFalse();
        }
    }
}
