using System;
using System.Linq;
using UnityEngine;
using ReferenceAndEventDemo;

namespace MVC
{
    public class SimpleShopController : MonoBehaviour, MonoEventListener, ModelObserverable<SimpleShopModelGetter>
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

        public void OnChanged(SimpleShopModelGetter getter)
        {
            //WARN : model.ChangeShopTab 호출 할 수 있는데 어떻게 고치면 좋을까?
            var shop = GetComponentInChildren<Shop>();
            shop.Refresh(getter.ShopTitle);
            GetComponentsInChildren<ShopTabButton>().ToList().ForEach((shopTabButton) => shopTabButton.Refresh(getter.SelectedTab));
        }
    }
}