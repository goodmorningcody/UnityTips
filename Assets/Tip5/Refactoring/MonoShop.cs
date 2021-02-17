using UnityEngine;
using UnityEngine.UI;

namespace OOPWithGeneric
{
    public class MonoShop : MonoBehaviour
    {
        [SerializeField] private Text shopTitle = null;

        IShop shopModel = null;
        public void Init<T>() where T : IShop, new()
        {
            shopModel = new T();
            shopTitle.text = shopModel.Title;
        }

        public void OnClickedClose()
        {
            Destroy(gameObject);
        }
    }
}