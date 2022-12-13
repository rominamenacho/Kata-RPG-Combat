namespace combat_kata.Actions
{
    public class HealthCharacter
    {
        public void Healed(int healthReceive, Character characterToBeHealth, Character healer)
        {
            if (CanHealed(characterToBeHealth, healer))
            {
                characterToBeHealth.HealthMe(healthReceive);
            }
        }

        private bool CanHealed(Character characterToBeHealth, Character healer)
        {
            return IsAlive(characterToBeHealth) && (ItIsItself(characterToBeHealth, healer) || IsAlly(characterToBeHealth, healer));
        }

        private static bool IsAlive(Character characterToBeHealth)
        {
            return characterToBeHealth.IsAlive;
        }

        private static bool ItIsItself(Character characterToBeHealth, Character healer)
        {
            return healer.Id == characterToBeHealth.Id;
        }

        private bool IsAlly(Character characterToBeHealth, Character healer)
        {

            foreach (var item in characterToBeHealth.Factions)
            {
                if (healer.Factions.Find(f => f.Id == item.Id) != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
