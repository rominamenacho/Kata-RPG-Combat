using System;

namespace combat_kata.Actions
{
    public class DealDamage
    {
        public void Attack(int damage, Character attacker, Character target)
        {
            if (CanAttack(attacker, target))
            {
                ImpactOnHealth(damage, attacker, target);
            }
        }

        private bool CanAttack(Character attacker, Character target)
        {
            return AreDifferentCharacters(attacker, target)
                    && IsTargetInRange(attacker, target)
            && !IsAlly(attacker, target);
        }

        private bool IsAlly(Character attacker, Character target)
        {

            foreach (var item in attacker.Factions)
            {
                if (target.Factions.Find(f => f.Id == item.Id) != null)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsTargetInRange(Character attacker, Character target)
        {
            int distance = GetManhattanDistance(attacker, target);

            return (distance <= attacker.MaxRangeAttack);
        }

        private static int GetManhattanDistance(Character attacker, Character target)
        {
            return Math.Abs(attacker.Position.Item1 - target.Position.Item1) +
                             Math.Abs(attacker.Position.Item2 - target.Position.Item2);
        }

        private bool AreDifferentCharacters(Character attacker, Character target)
        {
            return attacker.Id != target.Id;
        }
        private void ImpactOnHealth(int damage, Character attacker, Character target)
        {
            /////////strategy ?
            if (AttackedIs5LevelsOrMoreAboveAttacker(attacker, target))
            {
                target.Reduce50PercentDamage(damage);
            }
            else
            {
                target.Increase50PercentDamage(damage);
            }
        }

        private bool AttackedIs5LevelsOrMoreAboveAttacker(Character attacker, Character target)
        {
            return target.Level - attacker.Level >= 5;
        }



    }
}
