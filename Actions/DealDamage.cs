namespace combat_kata.Actions
{
    public class DealDamage
    {
        public void Attack(int damage, Character attacker, Character attacked)
        {
            if (!AreSameCharacter(attacker, attacked))
            {
                ImpactOnHealth(damage, attacker, attacked);
            }
        }

        private bool AreSameCharacter(Character attacker, Character attacked)
        {
            return attacker.Id == attacked.Id;
        }
        private void ImpactOnHealth(int damage, Character attacker, Character attacked)
        {
            /////////strategy ?
            if (AttackedIs5LevelsOrMoreAboveAttacker(attacker, attacked))
            {
                attacked.Reduce50PercentDamage(damage);
            }
            else
            {
                attacked.Increase50PercentDamage(damage);
            }
        }

        private bool AttackedIs5LevelsOrMoreAboveAttacker(Character attacker, Character attacked)
        {
            return attacked.Level - attacker.Level >= 5;
        }



    }
}
