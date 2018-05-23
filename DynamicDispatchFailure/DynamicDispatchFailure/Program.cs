using static System.Console;

namespace DynamicDispatchFailure
{
    class Program
    {
        /*
         * The goal of multiple dispatch is to call the proper method on two abstract types
         * whose derived type is not known until runtime.
         * In our example we use 2 abstract types (e.g. abstract class or an interface) 'Enemy' and 'Weapon'
         * Ideally we would be able to call Enemy.SwingWeapon(Weapon) whose enemy and weapon type are unknown at compile time.
         * 
         */ 
        static void Main(string[] args)
        {
            /*
             * In this example, we use the 'is' keyword as a type-check in the class
             * of the derived enemy type to determine the second dispatch at runtime 
             * in order to correctly call the method that contains our 'special' logic.
             */
            DomainWithTypeCheckApproach.Enemy ogre = new DomainWithTypeCheckApproach.Ogre();
            DomainWithTypeCheckApproach.Enemy murloc = new DomainWithTypeCheckApproach.Murloc();

            DomainWithTypeCheckApproach.IWeapon sword = new DomainWithTypeCheckApproach.Sword();
            DomainWithTypeCheckApproach.IWeapon mace = new DomainWithTypeCheckApproach.Mace();

            ogre.SwingWeapon(mace);
            murloc.SwingWeapon(mace);

            WriteLine();


            /*
             * In this example, we take advantage of the dynamic language runtime (DLR)
             * to accomplish the second dispatch at runtime in order to call the method
             * that contains our 'special' logic
             */

            DomainWithDynamicApproach.Enemy specialOgre = new DomainWithDynamicApproach.Ogre();
            DomainWithDynamicApproach.Enemy specialMurloc = new DomainWithDynamicApproach.Murloc();

            DomainWithDynamicApproach.IWeapon specialSword = new DomainWithDynamicApproach.Sword();
            DomainWithDynamicApproach.IWeapon specialMace = new DomainWithDynamicApproach.Mace();

            specialOgre.SwingWeapon(specialMace);
            specialMurloc.SwingWeapon(specialMace);

            WriteLine();

            /*
             * In this last and final approach we accomplish double dispatch through use of the visitor pattern.
             * We use compile time binding via the 'this' keyword and then runtime binding to properly
             * associate the two abstract types with the correct derived-type method call. 
             * 
             */
            DomainWithVisitorPattern.IEnemy visitorOgre = new DomainWithVisitorPattern.Ogre();
            DomainWithVisitorPattern.IEnemy visitorMurloc = new DomainWithVisitorPattern.Murloc();

            DomainWithVisitorPattern.WeaponVisitor visitorSword = new DomainWithVisitorPattern.Sword();
            DomainWithVisitorPattern.WeaponVisitor visitorMace = new DomainWithVisitorPattern.Mace();

            // Note: still calling a method on an abstract type with an abstract type as an argument.
            // e.g. IEnemy.SwingWeapon(IWeaponVisitor)
            visitorOgre.SwingWeapon(visitorMace);
            visitorMurloc.SwingWeapon(visitorMace);

            ReadLine(); 
        }
    }
}
