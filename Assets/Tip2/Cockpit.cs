using UnityEngine;
using UnityEngine.UI;

namespace ReferenceAndEventDemo
{
    public class Cockpit : MonoBehaviour
    {
        [SerializeField] private Button toggleButton = null;
        [SerializeField] private Text stateText = null;

        void Awake()
        {
        }
    }
}
