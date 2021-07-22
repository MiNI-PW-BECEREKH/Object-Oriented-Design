namespace GameConsole
{
    public class SteelArmorDefence : ArmorDefence
    {
        public override int Defend(int damage)
        {
            return (int)(damage * 0.3);

        }

    }
}