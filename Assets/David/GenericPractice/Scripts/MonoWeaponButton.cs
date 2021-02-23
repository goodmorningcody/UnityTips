using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DavidPractice
{
    public class MonoWeaponButton : MonoBehaviour
    {
        [SerializeField] Text txt_weaponName;
        // Start is called before the first frame update

        public void ButtonInit<T>(T weaponGadget) where T : IWeaponGadget
        {
            txt_weaponName.text = weaponGadget.weapon.GetWeaponName();

            GetComponent<Button>().onClick.AddListener(() =>
            {
                EventDispatcher.Emit(this, new SelectWeaponGadgetEvent<T>(weaponGadget.weapon.GetIndex()));
            });

        }
    }
}

