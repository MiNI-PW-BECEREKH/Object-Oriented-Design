namespace GameConsole
{
    public abstract class ArmorDefence
    {
        public abstract int Defend(int damage);

        //With the nested class and property we have single instance of NullArmor 
        public static ArmorDefence Null { get; } = new NullArmorDefence();
        private class NullArmorDefence : ArmorDefence
        {
            public override int Defend(int damage)
            {
                return 0;
            }
        }
    }
}