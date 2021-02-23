using System;
using System.Linq;
using UnityEngine;
using ReferenceAndEventDemo;

namespace MVC
{
    public class SimpleShopController : MonoBehaviour, MonoEventListener, ShopModelChangeListener
    {
        private SimpleShopModel model = null;

        void Start()
        {
            model = new SimpleShopModel(this);
        }

        public void OnEventHandle(ReferenceAndEventDemo.Event param)
        {
            if ( param is ClickedShopTabEvent clickedShopTab )
            {
                model.ChangeShopTab(clickedShopTab.ClickedShopTab);
            }
        }

        public void OnChangedShopModel(SimpleShopModel model)
        {
            //WARN : model.ChangeShopTab 호출 할 수 있는데 어떻게 고치면 좋을까?
            var shop = GetComponentInChildren<Shop>();
            shop.Refresh(model.ShopTitle);
            GetComponentsInChildren<ShopTabButton>().ToList().ForEach((shopTabButton) => shopTabButton.Refresh(model.SelectedTab));
        }
    }
}