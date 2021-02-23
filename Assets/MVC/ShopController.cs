using System;
using System.Linq;
using UnityEngine;
using ReferenceAndEventDemo;

namespace MVC
{
    public class ShopController : MonoBehaviour, IObserver<EventPayload>, MonoEventListener
    {
        private ShopModel model = null;
        private IDisposable shopDisposable = null;

        void Start()
        {
            model = new ShopModel();
            model.Subscribe(this);

            // 모델의 데이터를 가져와서 뷰를 갱신
            GetComponentsInChildren<ShopTabButton>().ToList().ForEach((shopTabButton) => shopTabButton.Refresh(model.SelectedTab));

            // 모델의 변경을 감시하는 Shop는 뷰 컨트롤러? 아니면 뷰? 모델의 변경을 감시한다면 컨트롤러, 아니라면 뷰
            var shop = GetComponentInChildren<Shop>();
            shopDisposable = model.Subscribe(shop);
        }

        public void OnEventHandle(ReferenceAndEventDemo.Event param)
        {
            if ( param is ClickedShopTabEvent clickedShopTab )
            {
                model.ChangedShopTab(clickedShopTab.ClickedShopTab);
            }
            else if ( param is DestroyedShop && shopDisposable != null )
            {
                shopDisposable.Dispose();
            }
        }

        public void OnNext(EventPayload value)
        {
            if ( value.Event is ChangedShopModelEvent )
            {
                GetComponentsInChildren<ShopTabButton>().ToList().ForEach((shopTabButton) => shopTabButton.Refresh(model.SelectedTab));
                // var shop = GetComponentInChildren<Shop>();
                // shop.Refresh(model.ShopTitle);
            }
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }
    }
}