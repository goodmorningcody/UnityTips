using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DavidPractice
{
    public interface IWeaponGadget
    {
        IWeapon weapon { get; }
    }

    public class SwordGadget : IWeaponGadget
    {
        public IWeapon weapon { get; private set; }

        public SwordGadget(IWeapon sword)
        {
            weapon = sword;
        }
    }

    public class BowGadget : IWeaponGadget
    {
        public IWeapon weapon { get; private set; }

        public BowGadget(IWeapon bow)
        {
            weapon = bow;
        }
    }

    public class AxGadget : IWeaponGadget
    {
        public IWeapon weapon { get; private set; }

        public AxGadget(IWeapon ax)
        {
            weapon = ax;
        }
    }

    public class WandGadget : IWeaponGadget
    {
        public IWeapon weapon { get; private set; }
        public WandGadget(IWeapon wand)
        {
            weapon = wand;
        }
    }
}