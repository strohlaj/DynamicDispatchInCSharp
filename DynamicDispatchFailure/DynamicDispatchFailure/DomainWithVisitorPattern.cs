using static System.Console;
using System;

namespace DomainWithVisitorPattern
{

    abstract class WeaponVisitor
    {
        internal abstract void Visit(Ogre ogre);

        internal abstract void Visit(Murloc murloc);

        protected internal void BaseVisit (IEnemy enemy)
        {
            WriteLine("base swing weapon logic.");
        }

    }

    /// <summary>
    /// The 'Visitor'
    /// </summary>
    interface IEnemy
    {
        void SwingWeapon(WeaponVisitor weaponVisitor);
    }

    class Sword : WeaponVisitor
    {
        internal override void Visit(Murloc murloc)
        {
            Visit(murloc);
        }

        internal override void Visit(Ogre ogre)
        {
            Visit(ogre);
        }
    }

    class Mace : WeaponVisitor
    {
        internal override void Visit(Murloc murloc)
        {
            WriteLine("Some specific mace logic here");
        }

        internal override void Visit(Ogre ogre)
        {
            BaseVisit(ogre);
            WriteLine("swung mace");
        }
    }

    /// <summary>
    /// Depending on how we decide the 'visitor' 
    /// </summary>
    class Ogre : IEnemy
    {
        // The 'IEnemy.SwingWeapon(WeaponVisitor visitor)' method is bound at run time and is considered the first dispatch. 
        // However the calling visit(ogre) instead of visit(murloc) is determined at compile time and is 
        // considered the 'second' dispatch. 
        public void SwingWeapon(WeaponVisitor weaponVisitor)
        {
            weaponVisitor.Visit(this);
        }
    }

    class Murloc : IEnemy
    {
        public void SwingWeapon(WeaponVisitor weaponVisitor)
        {
            weaponVisitor.Visit(this);
        }
    }
}
