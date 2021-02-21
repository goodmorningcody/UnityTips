using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DavidPractice
{
    public class WeaponSelector : MonoBehaviour, EventListener
    {
        [Header("Weapon Wiki")]
        [SerializeField] private WeaponWiki weaponWiki;

        [Header("Display")]
        [SerializeField] private Image weaponImage;

        [Header("Bottom")]
        [SerializeField] private WeaponTypeSelector weaponTypeSelector;
        [SerializeField] private MonoWeaponButton monoWeaponButton;
        [SerializeField] private ScrollRect scrollRect_weaponGadget;

        [Header("Right")]
        [SerializeField] private Text skillTitle;

        [SerializeField] private MonoSkillButton monoSkillButton;
        [SerializeField] private ScrollRect scrollRect_skill;

        //Initialize weapons
        TypeSword typeSword;
        TypeBow typeBow;
        TypeAx typeAx;
        TypeWand typeWand;

        private void Start()
        {
            Initialize();
        }

        void Initialize()
        {
            typeSword = new TypeSword(weaponWiki.Swords);
            typeBow = new TypeBow(weaponWiki.Bows);
            typeAx = new TypeAx(weaponWiki.Axes);
            typeWand = new TypeWand(weaponWiki.Wands);
        }

        public void OnEventHandle(Event param)
        {
            if (param is WeaponTypeEvent)
            {
                HandleWeaponTypeEvent(param);
            }
            else if (param is WeaponGadgetEvent)
            {
                HandleWeaponGadgetEvent(param);
            }
            else if (param is BackButtonEvent)
            {
                StartCoroutine(ResetButtons<MonoSkillButton>(scrollRect_skill));
                StartCoroutine(ResetButtons<MonoWeaponButton>(scrollRect_weaponGadget));

                skillTitle.text = "";
                weaponImage.sprite = null;
                weaponTypeSelector.ShowWeaponTypeDisplay();
            }
        }

        void HandleWeaponTypeEvent(Event param)
        {
            if (param is SelectWeaponTypeEvent<TypeSword>)
            {
                InstantiateMonoWeaponButtons<SwordGadget>(typeSword);
            }
            else if (param is SelectWeaponTypeEvent<TypeBow>)
            {
                InstantiateMonoWeaponButtons<BowGadget>(typeBow);
            }
            else if (param is SelectWeaponTypeEvent<TypeAx>)
            {
                InstantiateMonoWeaponButtons<AxGadget>(typeAx);
            }
            else if (param is SelectWeaponTypeEvent<TypeWand>)
            {
                InstantiateMonoWeaponButtons<WandGadget>(typeWand);
            }

            weaponTypeSelector.ShowWeaponDisplay();
        }

        void InstantiateMonoWeaponButtons<T>(IWeaponType type) where T : IWeaponGadget
        {
            foreach (T item in type.Items)
            {
                var button = Instantiate<MonoWeaponButton>(monoWeaponButton, scrollRect_weaponGadget.content);
                button.ButtonInit<T>(item);
            }
        }

        //ScrollRect.content 아래에 생성된 <T>Button들 삭제
        IEnumerator ResetButtons<T>(ScrollRect scrollRect) where T : MonoBehaviour
        {
            var buttons = scrollRect.content.GetComponentsInChildren<T>();
            foreach (var button in buttons)
            {
                Destroy(button.gameObject);
            }
            yield return null;
        }

        void HandleWeaponGadgetEvent(Event param)
        {
            StartCoroutine(ResetButtons<MonoSkillButton>(scrollRect_skill));

            if (param is SelectWeaponGadgetEvent<SwordGadget>)
            {
                int index = ((SelectWeaponGadgetEvent<SwordGadget>)param).Index;
                Sword selectedSword = weaponWiki.FindSwordByIndex(index);
                ShowInfo(selectedSword);
            }
            else if (param is SelectWeaponGadgetEvent<BowGadget>)
            {
                int index = ((SelectWeaponGadgetEvent<BowGadget>)param).Index;
                Bow selectedBow = weaponWiki.FindBowByIndex(index);
                ShowInfo(selectedBow);
            }
            else if (param is SelectWeaponGadgetEvent<AxGadget>)
            {
                int index = ((SelectWeaponGadgetEvent<AxGadget>)param).Index;
                Ax selectedAx = weaponWiki.FindAxByIndex(index);
                ShowInfo(selectedAx);
            }
            else if (param is SelectWeaponGadgetEvent<WandGadget>)
            {
                int index = ((SelectWeaponGadgetEvent<WandGadget>)param).Index;
                Wand selectedWand = weaponWiki.FindWandByIndex(index);
                ShowInfo(selectedWand);
            }
        }

        void ShowInfo(IWeapon selectedWeapon)
        {
            skillTitle.text = string.Format("{0} Skills", selectedWeapon.WeaponName);
            weaponImage.sprite = selectedWeapon.Image;

            foreach (var skill in selectedWeapon.Skills)
            {
                var skillBtn = Instantiate<MonoSkillButton>(monoSkillButton, scrollRect_skill.content);
                skillBtn.ButtonInit(skill);
            }
        }
    }
}
