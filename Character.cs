using System;

namespace combat_kata
{
    public abstract class Character
    {
        private double _health;
        private int _level;
        private bool _alive;
        private readonly int _id;
        protected int _maxRangeAttack;

        public double Health { get => _health; }
        public int Level { get => _level; set => _level = value; }
        public bool IsAlive { get => _alive; }

        public int MaxRangeAttack { get => _maxRangeAttack; }

        public Character()
        {
            _health = 1000;
            _level = 1;
            _alive = true;
            _id = new Random().Next(1000);
        }

        public void ReceiveDamage(int damage, Character attaker)
        {

            if (IsAttacker(attaker))
            {
                ImpactOnHealth(damage, attaker);
                ShouldDies();

            }

        }

        private bool IsAttacker(Character attaker)
        {
            return attaker._id != this._id;
        }

        private void ShouldDies()
        {
            _alive = _health != 0;
        }

        private void ImpactOnHealth(int damage, Character attacker)
        {

            if (Iam5LevelsOrMoreAboveAttacker(attacker))
            {
                Reduce50PercentDamage(damage);
            }
            else
            {
                Increase50PercentDamage(damage);
            }
        }

        private bool Iam5LevelsOrMoreAboveAttacker(Character attacker)
        {
            return this.Level - attacker.Level >= 5;
        }

        private void Reduce50PercentDamage(int damage)
        {
            _health = (damage / 2 <= _health) ? _health - damage / 2 : 0;
        }

        private void Increase50PercentDamage(int damage)
        {
            _health = (((damage * 0.5) + damage) <= _health) ? _health - ((damage * 0.5) + damage) : 0;
        }

        public void Healed(int healthReceive, Character character)
        {
            if (IsAlive && ItIsItself(character))
            {
                _health = ((healthReceive + _health) <= 1000) ? (healthReceive + _health) : 1000;
            }
        }

        private bool ItIsItself(Character character)
        {
            return character._id == this._id;
        }
    }
}
