
using static System.Console;

namespace DomainWithTypeCheckApproach
{
    interface IWeapon
    {
        void Attack();
    }

    abstract class Enemy
    {
        public virtual void SwingWeapon(IWeapon weapon)
        {
            WriteLine("base swing weapon logic.");
            weapon.Attack();
        }
    }

    class Sword : IWeapon
    {
        public void Attack()
        {
            WriteLine("Swung Sword");
        }
    }

    class Mace : IWeapon
    {
        public void Attack()
        {
            WriteLine("Swung Mace");
        }
    }

    class Ogre : Enemy
    {
        // Does not implement anything special for swinging a sword or a mace.
    }

    class Murloc : Enemy
    {
        // *Note this method uses pre C# 7 pattern matching*
        // In a language that supports multiple dispatch this logic would be totally unnecessary.
        // At runtime the correct 'specific' method associated with this class would be called i.e. swing weapon(Mace mace) 
        // e.g. an IWeapon of type mace and an Enemy of type murloc are called on one another like so: (enemy.SwingWeapon(weapon)) 
        // In C# 7 Pattern Matching may make this code slightly better by using a case-switch statement matching on the type 
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
            WriteLine("Some specific mace logic here");
        }
    }
}
