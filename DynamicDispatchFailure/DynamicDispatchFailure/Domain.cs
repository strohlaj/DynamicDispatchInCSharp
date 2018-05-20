
using System;

namespace DynamicDispatchFailure
{
    interface IWeapon
    {
        void Attack();
    }

    abstract class Enemy
    {
        public virtual void SwingWeapon(IWeapon weapon)
        {
            dynamic wep = weapon;

            Console.WriteLine("base swing weapon logic.");
            weapon.Attack();
        }
    }

    class Sword : IWeapon
    {
        public void Attack()
        {
            Console.WriteLine("Swung Sword");
        }
        public void Attack(string specialText)
        {
            Console.WriteLine("special Sword swing text");
        }
    }

    class Mace : IWeapon
    {
        public void Attack()
        {
            Console.WriteLine("Swung Mace");
        }
    }

    class Ogre : Enemy
    {
        // Does not implement anything special for swinging a sword or a mace.
    }

    class Murloc : Enemy
    {
        // *Note this method uses pre C# 7 pattern matching*
        // In a language that supports dynamic dispatch this logic would be totally unnecessary.
        // At runtime the correct 'specific' method associated with this class would be called i.e. swing weapon(Mace mace) 
        // e.g. an IWeapon of type mace and an Enemy of type murloc are called on one another like so: (enemy.SwingWeapon(weapon)) 
        // In C# 7.1 Generic Pattern Matching may make this code slightly better by using a case-switch statement with
        // a generic constraint on the method, whose signature will change to SwingWeapon<T>(T weapon) where T : IWeapon 
        public override void SwingWeapon(IWeapon weapon)
        {
            if (weapon is Mace)
            {
                SwingWeapon((Mace)weapon);
            }
            else
            {
                base.SwingWeapon(weapon);
            }
        }

        // *Special logic specifically for maces.* In a language that supports dynamic dispatch, 
        // given a Mace as the IWeapon the following method would be called instead of SwingWeapon(IWeapon) because the 
        // IWeapon is resolved as a mace prior to going to the lookup table to find which method to call. 
        public void SwingWeapon(Mace mace)
        {
            Console.WriteLine("Some specific mace logic here");
        }
    }
}
