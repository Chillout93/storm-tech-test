﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards
{
    public interface IMediaService
    {
        bool ReadFileFromLocalOrSource(string cardName, bool offlineMode);
    }
}