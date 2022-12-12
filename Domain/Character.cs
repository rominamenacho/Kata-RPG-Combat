using System;

namespace combat_kata
{
    public abstract class Character
    {
        private double _health;
        private int _level;
        private bool _alive;
        private readonly int _id;
        private (int, int) _position;
        protected int _maxRangeAttack;

        public double Health { get => _health; }
        public int Level { get => _level; set => _level = value; }
        public bool IsAlive { get => _alive; }
        public int Id { get => _id; }
        public int MaxRangeAttack { get => _maxRangeAttack; }
        public (int, int) Position { get => _position; set => _position = value; }

        public const int MAX_HEALTH = 1000;
        public const int MIN_HEALTH = 0;
        public const int INITIAL_LEVEL = 1;
        public Character()
        {
            _health = MAX_HEALTH;
            _level = INITIAL_LEVEL;
            _alive = true;
            _id = new Random().Next(1000);
            _position = (0, 0);//(new Random().Next(50), new Random().Next(50));
        }


        public void HealthMe(int healthReceive)
        {
            _health = ((healthReceive + _health) <= MAX_HEALTH) ? (healthReceive + _health) : MAX_HEALTH;
        }

        public void Reduce50PercentDamage(int damage)
        {
            _health = (damage / 2 <= _health) ? _health - damage / 2 : 0;
            ShouldDies();
        }

        public void Increase50PercentDamage(int damage)
        {
            _health = (((damage * 0.5) + damage) <= _health) ? _health - ((damage * 0.5) + damage) : 0;
            ShouldDies();
        }

        private void ShouldDies()
        {
            _alive = _health != MIN_HEALTH;
        }
    }
}
