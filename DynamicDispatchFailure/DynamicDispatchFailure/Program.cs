using static System.Console;

namespace DynamicDispatchFailure
{
    class Program
    {
        static void Main(string[] args)
        {
            Enemy ogre = new Ogre();
            Enemy murloc = new Murloc();

            IWeapon sword = new Sword();
            IWeapon mace = new Mace();

            ogre.SwingWeapon(mace);
            murloc.SwingWeapon(mace);

            DomainWithDynamicDispatch.Enemy specialOgre = new DomainWithDynamicDispatch.Ogre();
            DomainWithDynamicDispatch.Enemy specialMurloc = new DomainWithDynamicDispatch.Murloc();

            DomainWithDynamicDispatch.IWeapon specialSword = new DomainWithDynamicDispatch.Sword();
            DomainWithDynamicDispatch.IWeapon specialMace = new DomainWithDynamicDispatch.Mace();

            specialOgre.SwingWeapon(specialMace);
            specialMurloc.SwingWeapon(specialMace);

            ReadLine(); 
        }
    }
}
