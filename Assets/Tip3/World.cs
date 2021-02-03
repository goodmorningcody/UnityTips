using UnityEngine;

namespace OOPWithInterface
{
    public class World : MonoBehaviour
    {
        [SerializeField] private Light directionalLight = null;

        public void Caught()
        {
            directionalLight.color = new Color(241f/255f, 58f/255f, 58f/255f, 1);
        }

        public void Released()
        {
            directionalLight.color = Color.white;
        }

        public void Snatched()
        {
            directionalLight.color = Color.white;
        }
    }
}