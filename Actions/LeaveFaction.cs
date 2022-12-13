using combat_kata;
using combat_kata.Domain;

namespace TestProjectCombatKata
{
    public class LeaveFaction
    {
        public void Invoke(Faction faction, Character character)
        {
            character.Factions.Remove(faction);
        }
    }
}