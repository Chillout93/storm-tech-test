using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services
{
    public class MediaService : IMediaService
    {
        private readonly string mediaSourceUrl = "http://wow.zamimg.com/images/hearthstone/cards/enus/medium/{0}.png";
        private readonly string localBaseDirectory;
        public MediaService(string localBaseDirectory)
        {
            this.localBaseDirectory = localBaseDirectory;
            if (!Directory.Exists(localBaseDirectory)) Directory.CreateDirectory(localBaseDirectory);
        }

        public bool ReadFileFromLocalOrSource(string cardName, bool offlineMode = false)
        { 
            var localFile = Path.Combine(localBaseDirectory, cardName);
             
            if (!File.Exists(localFile) && !offlineMode)
                return DownloadFromSource(cardName, localFile);

            return false;
        }

        private bool DownloadFromSource(string cardId, string localFile)
        {
            try
            {
                using (var client = new WebClient())
                    client.DownloadFile(string.Format(mediaSourceUrl, cardId), localFile);
            }
            catch(Exception ex)
            {
                // Log exception in event viewer.
                return false;
            }

            return true;        
        }
    }
}