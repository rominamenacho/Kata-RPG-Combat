using System;

namespace combat_kata.Domain
{
    public class Faction
    {
        private int _id;

        public int Id { get => _id; }

        public Faction()
        {
            _id = new Random().Next(500);
        }
    }
}
