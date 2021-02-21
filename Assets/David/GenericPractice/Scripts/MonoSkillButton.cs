using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DavidPractice
{
    public class MonoSkillButton : MonoBehaviour
    {
        [SerializeField] private Text txt_skillName;

        public void ButtonInit(string skill)
        {
            txt_skillName.text = skill;

            GetComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log(string.Format("스킬 {0} 발사!!!", skill));
            });
        }

    }
}

