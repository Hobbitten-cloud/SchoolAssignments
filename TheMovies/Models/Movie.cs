using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TheMovies.Model
{
    public class Movie
    {

        public string Name { get; set; }
        public double PlayingTime { get; set; }
        public double Duration { get; set; }
        public string Genre { get; set; }
        public string MovieDirector { get; set; }
        public string Premieredate { get; set; }
        //consructor

        public Movie(string name, double playingTime, double duration, string genre, string movieDirector, string premierDate)
        {
            Name = name;
            PlayingTime = playingTime;
            Duration = duration;
            Genre = genre;
            MovieDirector = movieDirector;
            Premieredate = premierDate;
        }
    }

}

