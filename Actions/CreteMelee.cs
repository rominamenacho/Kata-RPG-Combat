

namespace combat_kata.Actions
{
    public class CreteMelee : IActionCreate
    {
        public Character CreateCharacter()
        {
            return new Melee();
        }
    }
}
