using System;

namespace DomainWithDynamicDispatch
{
    interface IWeapon
    {
        void Attack();
    }

    abstract class Enemy
    {
        // Please note, this is usually a bad idea. 
        public void SwingWeapon(IWeapon weapon)
        {
            dynamic enemy = this;
            dynamic wep = weapon;
            enemy.ResolveSwingWeapon(wep);
        }
        public void ResolveSwingWeapon(IWeapon weapon)
        {
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

        // In this case, inside the parent classes (Enemy) base implemententation, we're bastardizing
        // the dynamic keyword to create the ability to resolve the type at runtime to call the correct method. 
        // Also, this requires the method to not be private (unless you do special reflective magic with as well in the base class)
        // yuck!
        public void ResolveSwingWeapon(Mace mace)
        {
            Console.WriteLine("Some specific mace logic here");
        }
    }
}
