using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DavidPractice
{
    public interface IWeaponGadget
    {
        int Index { get; }
        string ItemName { get; }
    }

    public class SwordGadget : IWeaponGadget
    {
        public int Index { get; private set; }

        public string ItemName { get; private set; }

        public SwordGadget(IWeapon sword)
        {
            this.Index = sword.Index;
            this.ItemName = sword.WeaponName;
        }
    }

    public class BowGadget : IWeaponGadget
    {
        public int Index { get; }
        public string ItemName { get; private set; }

        public BowGadget(IWeapon bow)
        {
            this.Index = bow.Index;
            this.ItemName = bow.WeaponName;
        }
    }

    public class AxGadget : IWeaponGadget
    {
        public int Index { get; private set; }

        public string ItemName { get; private set; }

        public AxGadget(IWeapon ax)
        {
            this.Index = ax.Index;
            this.ItemName = ax.WeaponName;
        }
    }

    public class WandGadget : IWeaponGadget
    {
        public int Index { get; private set; }

        public string ItemName { get; private set; }

        public WandGadget(Wand wand)
        {
            this.Index = wand.Index;
            this.ItemName = wand.WeaponName;
        }
    }
}