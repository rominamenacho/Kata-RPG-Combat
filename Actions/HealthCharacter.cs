namespace combat_kata.Actions
{
    public class HealthCharacter
    {
        public void Healed(int healthReceive, Character character)
        {
            if (character.IsAlive)
            {
                character.HealthMe(healthReceive);
            }
        }


    }
}
