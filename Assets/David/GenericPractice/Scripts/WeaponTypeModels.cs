using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DavidPractice
{
    public interface IWeaponType
    {
        string WeaponTypeName { get; }
        List<IWeaponGadget> Items { get; }
    }

    public abstract class BaseWeaponType<T> where T : class, IWeaponGadget
    {
        public List<IWeaponGadget> Items => items;
        protected List<IWeaponGadget> items = new List<IWeaponGadget>();
    }

    public class WeaponSword : BaseWeaponType<SwordGadget>, IWeaponType
    {
        public string WeaponTypeName => "Sword";

        public WeaponSword(List<Sword> swords)
        {
            foreach (var sword in swords)
            {
                items.Add(new SwordGadget(sword));
            }
        }
    }

    public class WeaponBow : BaseWeaponType<BowGadget>, IWeaponType
    {
        public string WeaponTypeName => "Bow";

        public WeaponBow(List<Bow> bows)
        {
            foreach (var bow in bows)
            {
                items.Add(new BowGadget(bow));
            }
        }
    }

    public class WeaponAx : BaseWeaponType<AxGadget>, IWeaponType
    {
        public string WeaponTypeName => "Ax";

        public WeaponAx(List<Ax> axes)
        {
            foreach (var ax in axes)
            {
                items.Add(new AxGadget(ax));
            }
        }
    }

    public class WeaponWand : BaseWeaponType<WandGadget>, IWeaponType
    {
        public string WeaponTypeName => "Wand";

        public WeaponWand(List<Wand> wands)
        {
            foreach (var wand in wands)
            {
                items.Add(new WandGadget(wand));
            }
        }
    }
}