using System;

namespace campeonato.Models
{
    public class Game
    {
        public int Id { get; set; }
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        public DateTime Date { get; set; }
    }
}