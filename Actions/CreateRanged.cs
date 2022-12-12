

namespace combat_kata.Actions
{
    public class CreateRanged : IActionCreate
    {
        public Character CreateCharacter()
        {
            return new Ranged();
        }
    }
}
