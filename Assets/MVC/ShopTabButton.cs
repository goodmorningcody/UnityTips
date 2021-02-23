using ReferenceAndEventDemo;
using UnityEngine;
using UnityEngine.UI;

namespace MVC
{
    public struct ClickedShopTabEvent : ReferenceAndEventDemo.Event
    {
        public ShopTab ClickedShopTab { get; private set; }
        public ClickedShopTabEvent(ShopTab clickedShopTab)
        {
            ClickedShopTab = clickedShopTab;
        }
    }


    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Button))]
    public class ShopTabButton : MonoBehaviour
    {
        [SerializeField] private ShopTab shopTab;

        void Awake()
        {
            GetComponent<Button>().onClick.AddListener(() => {
                this.Emit(new ClickedShopTabEvent(shopTab));
            });
        }

        public void Refresh(ShopTab selectedShopTab)
        {
            GetComponent<Image>().color = selectedShopTab == shopTab ? new Color(0.86f, 0.84f, 0.52f) : Color.white;
        }
    }
}