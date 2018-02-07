﻿using System;
using System.Collections.Generic;

namespace FakeBet.Models
{
    public enum MatchStatus
    {
        NonStarted,
        OnGoing,
        Ended
    }


    public class Match
    {
        public Guid MatchId { get; set; }

        public string Category { get; set; }

        public DateTime MatchTime { get; set; }

        public MatchStatus Status { get; set; }
        
        public string TeamAName { get; set; }

        public int TeamAPoints { get; set; }

        public string TeamBName { get; set; }

        public int TeamBPoints { get; set; }

        public float PointsRatio { get; set; }
        
        public IEnumerable<Vote> Votes { get; set; }
    }
}
