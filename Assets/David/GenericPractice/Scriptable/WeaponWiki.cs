using UnityEngine;
using System.Collections.Generic;

namespace DavidPractice
{
    [CreateAssetMenu(fileName = "WeaponWiki", menuName = "DavidPratcie/Wiki")]
    public class WeaponWiki : ScriptableObject
    {
        [SerializeField] private List<Sword> swords;
        public List<Sword> Swords => swords;

        [SerializeField] private List<Bow> bows;
        public List<Bow> Bows => bows;

        [SerializeField] private List<Ax> axes;
        public List<Ax> Axes => axes;

        [SerializeField] private List<Wand> wands;
        public List<Wand> Wands => wands;

        public Sword FindSwordByIndex(int index)
        {
            return swords.Count > index ? swords[index] : null;
        }

        public Bow FindBowByIndex(int index)
        {
            return bows.Count > index ? bows[index] : null;
        }

        public Ax FindAxByIndex(int index)
        {
            return axes.Count > index ? axes[index] : null;
        }

        public Wand FindWandByIndex(int index)
        {
            return wands.Count > index ? wands[index] : null;
        }
    }
}
