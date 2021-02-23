using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DavidPractice
{
    public static class IWeaponExtension
    {
        public static int GetIndex(this IWeapon weapon) { return weapon.Index; }
        public static string GetWeaponName(this IWeapon weapon)
        {
            return weapon.WeaponName;
        }

    }
}

