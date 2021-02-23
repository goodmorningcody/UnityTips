using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DavidPractice
{
    public class WeaponTypeSelector : MonoBehaviour
    {
        [SerializeField] private GameObject weaponTypeDisplay;
        [SerializeField] private GameObject weaponDisplay;
        // Start is called before the first frame update

        public void ShowWeaponTypeDisplay()
        {
            weaponDisplay.SetActive(false);
            weaponTypeDisplay.SetActive(true);
        }

        public void ShowWeaponDisplay()
        {
            weaponTypeDisplay.SetActive(false);
            weaponDisplay.SetActive(true);
        }
        public void OnClickWeaponTypeSword()
        {
            EventDispatcher.Emit(this, new SelectWeaponTypeEvent<WeaponSword>());
        }

        public void OnClickWeaponTypeBow()
        {
            EventDispatcher.Emit(this, new SelectWeaponTypeEvent<WeaponBow>());
        }

        public void OnClickWeaponTypeAx()
        {
            EventDispatcher.Emit(this, new SelectWeaponTypeEvent<WeaponAx>());
        }

        public void OnClickWeaponTypeWand()
        {
            EventDispatcher.Emit(this, new SelectWeaponTypeEvent<WeaponWand>());
        }

        public void OnClickBack()
        {
            EventDispatcher.Emit(this, new BackButtonEvent());
        }
    }

}
