//using UnityEngine;
//using System.Collections.Generic;
//using System.Linq;

//public class CatManager : MonoBehaviour
//{
//    private Queue<int> catQueue = new Queue<int>(); // ќчередь дл€ хранени€ пор€дка выдачи котиков
//    private int catQueueLength = 3;
//    private int lastCat = 0; // ѕоследний выданный котик
//    private HashSet<int> availableCats = new HashSet<int> { 1 }; // ƒоступные котики (изначально только первый)
//    private int lastMax;


//    private void Start()
//    {
//        InitializeCatQueue(); // »нициализаци€ очереди котиков
//        lastMax = availableCats.Max();
//    }

//    private void Update()
//    {
//      if(lastMax != availableCats.Max())
//        {
//            lastCat = availableCats.Max();

//            switch (availableCats.Max())
//            {
//                case 0:
//                case 1:
//                    catQueueLength = 3;
//                    break;
//                case 2:
//                    catQueueLength = 4;
//                    break;
//                case 3:
//                    catQueueLength = 5;
//                    break;
//                case 4:
//                    catQueueLength = 7;
//                    break;
//                default:
//                    catQueueLength = 7;
//                    break;
//            }          
//        } 
//    }

//    private void InitializeCatQueue()
//    {
//        for (int i = 0; i < catQueueLength; i++) // «аготовленные наперед котики
//        {
//            int cat = GetNextCat();
//            catQueue.Enqueue(cat);
//        }
//    }

//    private int GetNextCat()
//    {
//        while (catQueue.Count > catQueueLength)
//        {
//            switch (availableCats.Max())
//            {
//                case 1:
//                    return 1;
//                case 2:
//                    return Random.Range(1, 3);
//                case 3:
//                    int randomNumber = Random.Range(0, 100);

//                    // 60% шанс, что следующим будет lastCat
//                    if (randomNumber < 60)
//                    {
//                        return lastCat;
//                    }
//                    else
//                    {
//                        // 40% шанс, что следующим будет другое случайное число, не равное lastCat
//                        // —генерировать случайное число от 1 до 3 (исключа€ значение lastCat)
//                        return (lastCat + Random.Range(1, 3)) % 3 + 1;
//                    }
//                case 4:
//                    return 4;
//                case 5:
//                    return 5;
//                case 6:
//                    return 6;
//            }

//            return 1;
//        }
//    }

//    public int GetNextCatFromQueue()
//    {
//        if (catQueue.Count == 0)
//        {
//            int cat = GetNextCat();
//            catQueue.Enqueue(cat);
//        }

//        return catQueue.Dequeue();
//    }


//}
