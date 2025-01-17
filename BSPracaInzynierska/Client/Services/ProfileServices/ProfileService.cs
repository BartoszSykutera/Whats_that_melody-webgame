﻿using BSPracaInzynierska.Shared;
using System.Net.Http;
using System.Net.Http.Json;

namespace BSPracaInzynierska.Client.Services.ProfileServices
{
    public class ProfileService : IProfileService
    {
        private readonly HttpClient _httpClient;
        public ProfileService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public List<MusicPlaylist> favouritePlaylists { get; set; } = new List<MusicPlaylist>();
        public List<MusicPlaylist> createdPlaylists { get; set; } = new List<MusicPlaylist>();
        public User userProfile { get; set; } = new User();

        public async Task GetUser(Guid id)
        {
            var resultUser = await _httpClient.GetAsync($"api/Auth/profile/{id}");
            var responseStatusCode = resultUser.StatusCode;
            if (responseStatusCode == System.Net.HttpStatusCode.OK)
            {
                userProfile = await resultUser.Content.ReadFromJsonAsync<User>();
                favouritePlaylists = userProfile.FavouritePlaylists.ToList();
            }
            else
            {
                userProfile = null;
            }
        }
        public async Task GetCreatedPlaylist(Guid id)
        {
            var resultCreatedPlaylist = await _httpClient.GetAsync($"api/MusicPlaylists/userId/{id}");
            if (resultCreatedPlaylist != null)
            {
                createdPlaylists = await resultCreatedPlaylist.Content.ReadFromJsonAsync<List<MusicPlaylist>>();
            }
        }

        public async Task DeletePlaylists(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"api/MusicPlaylists/{id}");
            MusicPlaylist playlistToRemove = createdPlaylists.Where(p => p.Id == id).FirstOrDefault();
            createdPlaylists.Remove(playlistToRemove);
        }
    }
}
