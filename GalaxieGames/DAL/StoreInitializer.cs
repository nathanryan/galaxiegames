using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GalaxieGames.Models;

/*
* StoreInitializer.cs
*
* v1.0
*
* 08/12/2015
*
* @author Nathan Ryan, x13448212
*/

namespace GalaxieGames.DAL
{
    public class StoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var platforms = new List<Platform>
            {
                new Platform{PlatformID=1,PlatformName="Xbox"},
                new Platform{PlatformID=2,PlatformName="Playstation"},
                new Platform{PlatformID=3,PlatformName="Nintendo"},
            };

            platforms.ForEach(s => context.Platforms.Add(s));
            context.SaveChanges();

            var studios = new List<Studio>
            {
                new Studio{StudioName="Activision",Country="USA"},
                new Studio{StudioName="Bethesda",Country="USA"},
                new Studio{StudioName="Capcom",Country="Canada"},
                new Studio{StudioName="Konami",Country="Japan"},
                new Studio{StudioName="Level 5",Country="Japan"},
                new Studio{StudioName="Maxis Software",Country="USA"},
                new Studio{StudioName="Microsoft Game Studios",Country="USA"},
                new Studio{StudioName="PopCap Games",Country="USA"},
                new Studio{StudioName="Rockstar North",Country="Scotland"},
                new Studio{StudioName="Sega",Country="USA"}
            };

            studios.ForEach(s => context.Studios.Add(s));
            context.SaveChanges();

            var genres = new List<Genre>
            {
                new Genre{GenreID=1,GenreName="Action",GenreDescription="The action game is a video game genre that emphasizes physical challenges, including hand–eye coordination and reaction-time."},
                new Genre{GenreID=2,GenreName="Adventure",GenreDescription="An adventure game is a video game in which the player assumes the role of protagonist in an interactive story driven by exploration and puzzle-solving."},
                new Genre{GenreID=3,GenreName="Casual",GenreDescription="A casual game is a video game targeted at or used by a mass audience of casual gamers. Casual games can have any type of gameplay, and fit in any genre."},
                new Genre{GenreID=4,GenreName="Indie",GenreDescription="Independent video games (commonly referred to as indie games) are video games created by individuals or small teams generally without video game publisher financial support."},
                new Genre{GenreID=5,GenreName="Massively Multiplayer",GenreDescription="A massively multiplayer online game (MMO or MMOG) is a video game which is capable of supporting large numbers of players simultaneously in the same instance (or world). By necessity, they are played over a network, such as the Internet."},
                new Genre{GenreID=6,GenreName="Racing",GenreDescription="The racing video game genre is the genre of video games, either in the first-person or third-person perspective, in which the player partakes in a racing competition with any type of land, air, or sea vehicles. They may be based on anything from real-world racing leagues to entirely fantastical settings."},
                new Genre{GenreID=7,GenreName="Simulation",GenreDescription="A simulation game attempts to copy various activities from real life in the form of a game for various purposes such as training, analysis, or prediction."},
                new Genre{GenreID=8,GenreName="Sports",GenreDescription="A sports game is a video game that simulates the practice of sports. Most sports have been recreated with a game, including team sports, Track and field, extreme sports and combat sports."},
                new Genre{GenreID=9,GenreName="RPG",GenreDescription="A role-playing video game (commonly referred to as role-playing game or RPG, as well as computer RPG or CRPG) is a video game genre where the player controls the actions of a protagonist (or several adventuring party members) immersed in a fictional world."},
                new Genre{GenreID=10,GenreName="Strategy",GenreDescription="Strategy video game is a video game genre that focuses on skillful thinking and planning to achieve victory.It emphasizes strategic, tactical, and sometimes logistical challenges. Many games also offer economic challenges and exploration."}
            };

            genres.ForEach(s => context.Genres.Add(s));
            context.SaveChanges();

            var videogames = new List<VideoGame>
            {
                new VideoGame{VideoGameID=1,Title="Fez",Year="2013",Price=30,PlatformID=1,StudioID=2,GenreID=4},
                new VideoGame{VideoGameID=2,Title="Limbo",Year="2012",Price=20,PlatformID=2,StudioID=1,GenreID=2},
                new VideoGame{VideoGameID=3,Title="FIFA 16",Year="2015",Price=50,PlatformID=2,StudioID=1,GenreID=8},
                new VideoGame{VideoGameID=4,Title="Grand Theft Auto V",Year="2014",Price=50,PlatformID=1,StudioID=9,GenreID=1},
                new VideoGame{VideoGameID=5,Title="Little Big Planet",Year="2014",Price=20,PlatformID=2,StudioID=3,GenreID=10},
                new VideoGame{VideoGameID=6,Title="Tearaway",Year="2015",Price=25,PlatformID=2,StudioID=3,GenreID=10},
                new VideoGame{VideoGameID=7,Title="Yoshi's Island",Year="2010",Price=30,PlatformID=3,StudioID=4,GenreID=3},
                new VideoGame{VideoGameID=8,Title="Nintendogs",Year="2011",Price=20,PlatformID=3,StudioID=4,GenreID=7},
                new VideoGame{VideoGameID=9,Title="Minecraft",Year="2012",Price=30,PlatformID=1,StudioID=8,GenreID=7},
                new VideoGame{VideoGameID=10,Title="Terraria",Year="2011",Price=20,PlatformID=1,StudioID=10,GenreID=7},
                new VideoGame{VideoGameID=11,Title="Fallot 4",Year="2015",Price=50,PlatformID=1,StudioID=10,GenreID=1},
                new VideoGame{VideoGameID=12,Title="The Last Of Us",Year="2013",Price=25,PlatformID=2,StudioID=4,GenreID=1},
                new VideoGame{VideoGameID=13,Title="Witcher 3",Year="2015",Price=30,PlatformID=2,StudioID=4,GenreID=4},
                new VideoGame{VideoGameID=14,Title="BioShock",Year="2007",Price=32,PlatformID=2,StudioID=10,GenreID=7},
                new VideoGame{VideoGameID=15,Title="Legend of Zelda",Year="1998",Price=20,PlatformID=3,StudioID=1,GenreID=7},
                new VideoGame{VideoGameID=16,Title="Skyrim",Year="2011",Price=28,PlatformID=2,StudioID=10,GenreID=2},
                new VideoGame{VideoGameID=17,Title="Mass Effect 2",Year="2010",Price=15,PlatformID=1,StudioID=6,GenreID=6},
                new VideoGame{VideoGameID=18,Title="Destiny",Year="2014",Price=40,PlatformID=1,StudioID=10,GenreID=1},
                new VideoGame{VideoGameID=19,Title="Mario Kart 8",Year="2014",Price=20,PlatformID=3,StudioID=8,GenreID=8},
                new VideoGame{VideoGameID=20,Title="Red Dead Redemption",Year="2010",Price=35,PlatformID=2,StudioID=10,GenreID=7},
                new VideoGame{VideoGameID=21,Title="Hotline Miami",Year="2012",Price=10,PlatformID=3,StudioID=10,GenreID=1},
                new VideoGame{VideoGameID=22,Title="Dark Souls",Year="2011",Price=50,PlatformID=1,StudioID=10,GenreID=1},
                new VideoGame{VideoGameID=23,Title="Journey",Year="2012",Price=25,PlatformID=2,StudioID=4,GenreID=7},
                new VideoGame{VideoGameID=24,Title="Super Smash Bros",Year="2014",Price=30,PlatformID=3,StudioID=4,GenreID=8},
                new VideoGame{VideoGameID=25,Title="Rock Band 3",Year="2010",Price=40,PlatformID=2,StudioID=10,GenreID=7},
                new VideoGame{VideoGameID=26,Title="Sim City",Year="2000",Price=20,PlatformID=3,StudioID=1,GenreID=7},
                new VideoGame{VideoGameID=27,Title="Pokemon X",Year="2013",Price=28,PlatformID=3,StudioID=10,GenreID=2},
                new VideoGame{VideoGameID=28,Title="Half Life",Year="2010",Price=15,PlatformID=1,StudioID=2,GenreID=6},
                new VideoGame{VideoGameID=29,Title="Portal",Year="2005",Price=40,PlatformID=1,StudioID=10,GenreID=1},
                new VideoGame{VideoGameID=30,Title="Super Mario Galaxy",Year="2012",Price=20,PlatformID=3,StudioID=8,GenreID=8},
            };

            videogames.ForEach(s => context.VideoGames.Add(s));
            context.SaveChanges();
        }
    }
}