using System;

namespace DomainWithVisitorPattern
{
    interface IWeapon
    {
        void Attack();
    }

    abstract class Enemy
    {
        public abstract void Accept(WeaponVisitor visitor);
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
        public override void Accept(WeaponVisitor visitor)
        {
            throw new NotImplementedException();
        }
    }

    class Murloc : Enemy
    {
        public override void Accept(WeaponVisitor visitor)
        {
            throw new NotImplementedException();
        }
    }

    interface WeaponVisitor
    {
        void Visit(Mace mace);
        void Visit(Sword mace);
    }
}
