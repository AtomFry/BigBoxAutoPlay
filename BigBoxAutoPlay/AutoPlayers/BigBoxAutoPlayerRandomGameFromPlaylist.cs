﻿using BigBoxAutoPlay.Helpers;
using BigBoxAutoPlay.Models;
using System.Collections.Generic;
using System.Linq;
using Unbroken.LaunchBox.Plugins;
using Unbroken.LaunchBox.Plugins.Data;

namespace BigBoxAutoPlay.AutoPlayers
{
    public class BigBoxAutoPlayerRandomGameFromPlaylist : BigBoxAutoPlayer
    {
        public BigBoxAutoPlayerRandomGameFromPlaylist(BigBoxAutoPlaySettings _bigBoxAutoPlaySettings) : base(_bigBoxAutoPlaySettings)
        {
        }

        public override void AutoPlay()
        {
            IEnumerable<IPlaylist> allPlaylistsQuery = PluginHelper.DataManager.GetAllPlaylists();
            IPlaylist playlist = allPlaylistsQuery.FirstOrDefault(p => p.Name == bigBoxAutoPlaySettings.Playlist);

            if(playlist == null)
            {
                LogHelper.Log($"Random game from playlist but a playlist with name {bigBoxAutoPlaySettings.Playlist} was not found");
                return;
            }

            IEnumerable<IGame> gamesQuery = playlist.GetAllGames(false);

            if (bigBoxAutoPlaySettings.OnlyFavorites)
            {
                gamesQuery = gamesQuery.Where(g => g.Favorite);
            }

            if (!gamesQuery.Any())
            {
                return;
            }

            int gameCount = gamesQuery.Count();
            int randomIndex = random.Next(0, gamesQuery.Count());
            IGame randomGame = gamesQuery.ElementAt(randomIndex);

            if (randomGame == null)
            {
                return;
            }

            randomGame.Play();
        }
    }
}