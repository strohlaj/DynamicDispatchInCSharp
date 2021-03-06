﻿using static System.Console;

namespace DomainWithDynamicApproach
{
    interface IWeapon
    {
        void Attack();
    }

    abstract class Enemy
    {
        // This is really where the magic takes place.
        // We're using the Dynamic Runtime Language to dispatch to the second derived type.
        // The 'SwingWeapon' is responsible for the first dispatch.
        public void SwingWeapon(IWeapon weapon)
        {
            dynamic enemy = this;
            dynamic wep = weapon;
            enemy.ResolveSwingWeapon(wep);
        }
        public void ResolveSwingWeapon(IWeapon weapon)
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

        // In this case, inside the parent classes (Enemy) base implemententation, we're bastardizing
        // the dynamic keyword to create the ability to resolve the 
        // derived type of enemy at runtime as well. In the case of single dispatch like what C# has,
        // only one type is used at runtime to determine what method to call. So for 2 abstract types, only 1 of them is used for determining
        // 'what' method to call. Dynamic allows us to get around that and we'll see this method called as a result.  
        // Also, this requires the method to not be private (unless you do special reflective magic with as well in the base class)
        // yuck!
        public void ResolveSwingWeapon(Mace mace)
        {
            WriteLine("Some specific mace logic here");
        }
    }
}
