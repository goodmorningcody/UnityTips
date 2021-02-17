using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace OOPWithGeneric
{
    // # 낚시 용품을 판매하는 제니릭/인터페이스를 이용한 상점 클래스
    // 1. generic 문법 살펴보기
    //      - 제네릭 클래스와 제니릭 클래스의 Where Constraint
    //      - 제네릭 클래스의 타입 인자를 이용한 제네릭 프로퍼티
    //      - 제네릭 클래스의 타입 인자를 이용한 제네릭 메소드와 제네릭 타입의 아규먼트
    //      - 제네릭 메소드의 타입 인자를 메소드의 반환값으로 사용하기
    // 2. generic 사용하기
    //      - var fishingRodShop = new GenericShop<FishingRod>();
    //      - var fishingLineShop = new GenericShop<FishingLine>();
    //      - var fishingWheelShop = new GenericShop<FishingWheel>();
    //      - fishingWheelShop.Add(new FishingWheel()); // ok
    //      - fishingWheelShop.Add(new FishingRod()); // error
    //      - var items = fishingWheelShop.GetItems(); // items is List<FishingWheel>, So we dont need to cast from IFishingGadget to FishingWheel
    // 3. 그런데 MonoBehaviour를 상속받은 클래스에서 제네릭을 사용할 수 있을까? > ShopModel 클래스를 보자
    public class GenericMonoShop<T> : MonoBehaviour where T : class, IFishingGadget
    {
        [SerializeField] private List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public List<T> GetItems()
        {
            return items;
        }

        public int TotalPrice => items
            .Select((item) => item.Price)
            .Aggregate(0, (sum, price) => sum + price);
    }
}