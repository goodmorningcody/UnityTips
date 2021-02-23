using System;
using UnityEngine;
using UnityEngine.UI;

namespace MVC
{
    public class Shop : MonoBehaviour, IObserver<EventPayload>
    {
        [SerializeField] private Text shopTitle = null;

        public void Refresh(string shopTitle)
        {
            this.shopTitle.text = shopTitle;
        }

        // WARN : 상점을 닫으면 어떻게 될까?, IObserver는 잘 관리해줘야함
        public void OnClickedClose()
        {
            Destroy(gameObject);
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        // WARN : 상점 정보를 갱신하려면 어떻게 해야할까? EventPayload에 모델을 넘겨받지 않는 이상 이벤트 마다 처리된 값을 담고 있어야함
        public void OnNext(EventPayload value)
        {
            Debug.Log("called OnNext in Shop");
        }
    }
}