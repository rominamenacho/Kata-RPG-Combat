using combat_kata.Domain;

namespace combat_kata.Actions
{
    public class JoinFaction
    {
        public void Invoke(Faction faction, Character character)
        {
            character.Factions.Add(faction);
        }
    }
}
