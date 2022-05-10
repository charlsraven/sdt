using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace wf2
{
    [Serializable]
    public class Album
    {
        [DisplayName("AlbumName"), Category("SKZ")]
        public string AlbumName { get; set; }

        [DisplayName("ReleaseDate"), Category("SKZ")]
        public DateTime ReleaseDate { get; set; }
        [DisplayName("SongsNumber"), Category("SKZ")]
        public int SongsNumber { get; set; }
        [DisplayName("TotalDuration"), Category("SKZ")]
        public int TotalDuration { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public enum eAlbumType
        {
            single,
            ep,
            full,
            compilation
        };
        [DisplayName("AlbumType"), Category("SKZ")]
        public eAlbumType AlbumType { get; set; }
        [Browsable(false)]
        public string typeToString
        {
            get => AlbumType.ToString();
            set => AlbumType.ToString();
        }

        [DisplayName("Cover"), Category("SKZ")]
        public string Cover { get; set; }
        public Album(string name, DateTime releaseDate, int songsNumber, int totalDuration,
            eAlbumType albumType, string cover)
        {
            AlbumName = name;
            ReleaseDate = releaseDate;
            SongsNumber = songsNumber;
            TotalDuration = totalDuration;
            Minutes = totalDuration / 60;
            Seconds = totalDuration % 60;
            AlbumType = albumType;
            Cover = cover;
        }
        public Album(string name, DateTime releaseDate, int songsNumber, int minutes, int seconds,
            eAlbumType albumType)
        {
            AlbumName = name;
            ReleaseDate = releaseDate;
            SongsNumber = songsNumber;
            Minutes = minutes;
            Seconds = seconds;
            TotalDuration = minutes * 60 + seconds;
            AlbumType = albumType;
        }
        public Album(string name, DateTime releaseDate, int songsNumber, int minutes, int seconds,
            eAlbumType albumType, string cover)
        {
            AlbumName = name;
            ReleaseDate = releaseDate;
            SongsNumber = songsNumber;
            Minutes = minutes;
            Seconds = seconds;
            TotalDuration = minutes * 60 + seconds;
            AlbumType = albumType;
            Cover = cover;
        }
        public Album() { }
        public string durationToMinutes() =>
            Minutes.ToString() + " мин " + Seconds.ToString() + " сек";
    }
    class SKZAlbums
    {
        public static List<Album> skzAlbums = new List<Album>
        {
            new Album("Hellevator", new DateTime(2017, 11, 1), 1, 240, Album.eAlbumType.single, "../../hellevator.jpg"),
            new Album("Mixtape", new DateTime(2018, 1, 8), 7, 1445, Album.eAlbumType.ep, "../../mixtape.jpg"),
            new Album("I am NOT", new DateTime(2018, 3, 26), 7, 1357, Album.eAlbumType.ep, "../../iamnot.jpg"),
            new Album("I am WHO", new DateTime(2018, 8, 6), 7, 1288, Album.eAlbumType.ep, "../../iamwho.jpg"),
            new Album("I am YOU", new DateTime(2018, 10, 22), 7, 1349, Album.eAlbumType.ep, "../../iamyou.jpg"),
            new Album("Clé 1: MIROH", new DateTime(2019, 3, 25), 7, 1282, Album.eAlbumType.ep, "../../miroh.png"),
            new Album("Clé 2: Yellow Wood", new DateTime(2019, 6, 19), 7, 1531, Album.eAlbumType.ep, "../../yellowwood.jpg"),
            new Album("Double Knot", new DateTime(2019, 10, 9), 1, 189, Album.eAlbumType.single, "../../doubleknot.jpg"),
            new Album("Extraordinary You OST Part.7: Story That Won't End", new DateTime(2019, 11, 7), 2, 489, Album.eAlbumType.single, "../../extraordinaryyou.jpg"),
            new Album("Clé : LEVANTER", new DateTime(2019, 12, 9), 7, 1410, Album.eAlbumType.ep, "../../levanter.jpg"),
            new Album("Mixtape : Gone Days", new DateTime(2019, 12, 26), 1, 196, Album.eAlbumType.single, "../../gonedays.jpg"),
            new Album("Step Out of Clé", new DateTime(2020, 1, 24), 2, 385, Album.eAlbumType.single, "../../stepoutofcle.jpg"),
            new Album("SKZ2020", new DateTime(2020, 3, 18), 24, 4860, Album.eAlbumType.compilation, "../../skz2020.jpg"),
            new Album("Mixtape : On Track", new DateTime(2020, 3, 25), 1, 207, Album.eAlbumType.single, "../../ontrack.jpg"),
            new Album("TOP", new DateTime(2020, 5, 13), 2, 320, Album.eAlbumType.single, "../../top.jpg"),
            new Album("Top -English ver.-", new DateTime(2020, 5, 20), 2, 320, Album.eAlbumType.single, "../../topeng.jpg"),
            new Album("Top -Japanese ver.-", new DateTime(2020, 6, 3), 4, 649, Album.eAlbumType.single, "../../topjap.jpg"),
            new Album("GO Live", new DateTime(2020, 6, 17), 14, 2629, Album.eAlbumType.full, "../../golive.jpg"),
            new Album("POP OUT BOY! OST Part.1: Hello Stranger", new DateTime(2020, 7, 16), 2, 479, Album.eAlbumType.single, "../../hellostranger.jpg"),
            new Album("ALL IN", new DateTime(2020, 11, 4), 7, 1282, Album.eAlbumType.ep, "../../allin.jpg"),
            new Album("ALL IN (Korean ver.)", new DateTime(2020, 11, 26), 1, 184, Album.eAlbumType.single, "../../allinsingle.jpg"),
            new Album("Mixtape : OH", new DateTime(2021, 6, 26), 1, 212, Album.eAlbumType.single, "../../mixtapeoh.jpg"),
            new Album("NOEASY", new DateTime(2021, 8, 23), 14, 2794, Album.eAlbumType.full, "../../noeasy.jpg"),
            new Album("Scars", new DateTime(2021, 10, 13), 3, 553, Album.eAlbumType.single, "../../scars.jpg"),
            new Album("Christmas EveL", new DateTime(2021, 11, 29), 4, 829, Album.eAlbumType.ep, "../../christmasevel.jpeg"),
            new Album("SKZ2021", new DateTime(2021, 12, 23), 14, 3081, Album.eAlbumType.compilation, "../../skz2021.jpg"),
            new Album("ODDinary", new DateTime(2022, 3, 18), 7, 1326, Album.eAlbumType.ep, "../../oddinary.jpg")
        };
    }
}
