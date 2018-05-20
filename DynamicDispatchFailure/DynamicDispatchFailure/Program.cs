using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            DomainWithDynamicForDispatch.Enemy specialOgre = new DomainWithDynamicForDispatch.Ogre();
            DomainWithDynamicForDispatch.Enemy specialMurloc = new DomainWithDynamicForDispatch.Murloc();

            DomainWithDynamicForDispatch.IWeapon specialSword = new DomainWithDynamicForDispatch.Sword();
            DomainWithDynamicForDispatch.IWeapon specialMace = new DomainWithDynamicForDispatch.Mace();

            specialOgre.SwingWeapon(specialMace);

            specialMurloc.SwingWeapon(specialMace);

            Console.ReadLine();

        }
    }
}
