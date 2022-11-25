﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BSPracaInzynierska.Shared
{
    public class MusicPlaylist
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string PlaylistName { get; set; } = string.Empty;
        public int NumberOfTracks { get; set; }
        public string Description { get; set; } = string.Empty;
        public Guid? UserId { get; set; }
        [JsonIgnore]
        public virtual User? Creator { get; set; }
        public virtual ICollection<Song> Songs { get; set; }

    }
}