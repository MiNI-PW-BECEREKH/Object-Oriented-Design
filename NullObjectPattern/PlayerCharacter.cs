namespace GameConsole
{   
    public class PlayerCharacter
    {
        private readonly ArmorDefence _armorDefence;

        public PlayerCharacter(ArmorDefence armorDefence)
        {
            _armorDefence = armorDefence;
        }

        public string Name { get; set; }
        public int Health { get; set; } = 100;

        public void Hit(int damage)
        {
            int damageReduction = _armorDefence.Defend(damage);

            int takenDamage = damage - damageReduction;

            Health -= takenDamage;

            System.Console.WriteLine($"{Name}'s health has been reduced by {takenDamage} to {Health}, {_armorDefence.GetType().Name} blocked {damageReduction} damage");
        }
    }
}