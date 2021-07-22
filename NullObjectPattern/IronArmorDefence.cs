using System;

namespace GameConsole
{
    public class IronArmorDefence : ArmorDefence
    {
        public override int Defend(int damage)
        {
            return (int)(damage * 0.1);
        }
    }
}