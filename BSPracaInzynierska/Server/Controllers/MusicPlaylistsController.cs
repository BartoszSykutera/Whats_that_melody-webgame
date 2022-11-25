﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BSPracaInzynierska.Server.DB;
using BSPracaInzynierska.Shared;

namespace BSPracaInzynierska.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicPlaylistsController : ControllerBase
    {
        private readonly DataContext _context;

        public MusicPlaylistsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MusicPlaylists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicPlaylist>>> GetMusicPlaylists()
        {
            return await _context.MusicPlaylists.Include(p => p.Songs).ToListAsync();
        }

        // GET: api/MusicPlaylists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MusicPlaylist>> GetMusicPlaylist(Guid id)
        {
            var musicPlaylist = await _context.MusicPlaylists.Include(p => p.Songs).Where(p => p.Id == id).FirstOrDefaultAsync();

            if (musicPlaylist == null)
            {
                return NotFound();
            }

            return musicPlaylist;
        }

        // PUT: api/MusicPlaylists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusicPlaylist(Guid id, MusicPlaylist musicPlaylist)
        {
            if (id != musicPlaylist.Id)
            {
                return BadRequest();
            }

            _context.Entry(musicPlaylist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicPlaylistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MusicPlaylists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MusicPlaylist>> PostMusicPlaylist(MusicPlaylist musicPlaylist)
        {
            User user = _context.Uzytkownicy.Where(u => u.Id == musicPlaylist.UserId).FirstOrDefault();
            musicPlaylist.Creator = user;
            _context.MusicPlaylists.Add(musicPlaylist);
            _context.Songs.AddRange(musicPlaylist.Songs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusicPlaylist", new { id = musicPlaylist.Id }, musicPlaylist);
        }

        // DELETE: api/MusicPlaylists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusicPlaylist(Guid id)
        {
            var musicPlaylist = _context.MusicPlaylists.Include(p => p.Songs).Where(p => p.Id == id).FirstOrDefault();
            if (musicPlaylist == null)
            {
                return NotFound();
            }
            foreach(var song in musicPlaylist.Songs)
            {
                _context.Songs.Remove(song);
            }
            _context.MusicPlaylists.Remove(musicPlaylist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusicPlaylistExists(Guid id)
        {
            return _context.MusicPlaylists.Any(e => e.Id == id);
        }
    }
}