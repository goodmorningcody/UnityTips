using UnityEngine;
using System.Collections.Generic;

namespace DavidPractice
{
    [CreateAssetMenu(fileName = "Sword", menuName = "DavidPratcie/Weapons/Sword")]
    public class Sword : ScriptableObject, IWeapon
    {
        [SerializeField] private int index;
        public int Index => index;
        [SerializeField] private string weaponName;
        public string WeaponName => weaponName;

        [SerializeField] private List<string> skills;
        public List<string> Skills => skills;

        [SerializeField] private Sprite image;
        public Sprite Image => image;
    }
}
