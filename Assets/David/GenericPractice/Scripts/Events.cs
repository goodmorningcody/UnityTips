using UnityEngine;
using System.Collections.Generic;

namespace DavidPractice
{
    public interface Event
    {

    }

    public interface WeaponTypeEvent : Event
    {

    }

    public interface WeaponGadgetEvent : Event
    {

    }

    public struct SelectWeaponTypeEvent<T> : WeaponTypeEvent where T : IWeaponType
    {

    }

    public struct SelectWeaponGadgetEvent<T> : WeaponGadgetEvent where T : IWeaponGadget
    {
        public int Index { get; }

        public SelectWeaponGadgetEvent(int index)
        {
            Index = index;
        }

    }

    public struct BackButtonEvent : Event
    {

    }
}
