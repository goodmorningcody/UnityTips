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

    public class TypeSword : BaseWeaponType<SwordGadget>, IWeaponType
    {
        public string WeaponTypeName => "Sword";

        public TypeSword(List<Sword> swords)
        {
            foreach (var sword in swords)
            {
                items.Add(new SwordGadget(sword));
            }
        }
    }

    public class TypeBow : BaseWeaponType<BowGadget>, IWeaponType
    {
        public string WeaponTypeName => "Bow";

        public TypeBow(List<Bow> bows)
        {
            foreach (var bow in bows)
            {
                items.Add(new BowGadget(bow));
            }
        }
    }

    public class TypeAx : BaseWeaponType<AxGadget>, IWeaponType
    {
        public string WeaponTypeName => "Ax";

        public TypeAx(List<Ax> axes)
        {
            foreach (var ax in axes)
            {
                items.Add(new AxGadget(ax));
            }
        }
    }

    public class TypeWand : BaseWeaponType<WandGadget>, IWeaponType
    {
        public string WeaponTypeName => "Wand";

        public TypeWand(List<Wand> wands)
        {
            foreach (var wand in wands)
            {
                items.Add(new WandGadget(wand));
            }
        }
    }
}