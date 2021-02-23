using System.Collections.Generic;
using UnityEngine;

namespace DavidPractice
{
    public interface IWeapon
    {
        int Index { get; }
        string WeaponName { get; }
        List<string> Skills { get; }
        Sprite Image { get; }
    }
}