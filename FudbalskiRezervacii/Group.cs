    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FudbalskiRezervacii
{
    public class Group
    {
        public string Ime { set; get; }
        public List<Team> timovi { set; get; }
        public String im1 { get {return timovi[0].image; } }
        public String im2 { get { return timovi[1].image; } }
        public String im3 { get { return timovi[2].image; } }
        public String im4 { get { return timovi[3].image; } }
        public String team1 { get { return  timovi[0].ime; } }
        public String team2 { get { return timovi[1].ime; } }
        public String team3 { get { return timovi[2].ime; } }
        public String team4 { get { return timovi[3].ime; } }
        public string id1 { get { return timovi[0].broj; } }
        public string id2 { get { return timovi[1].broj; } }
        public string id3 { get { return timovi[2].broj; } }
        public string id4 { get { return timovi[3].broj; } }
    }
}