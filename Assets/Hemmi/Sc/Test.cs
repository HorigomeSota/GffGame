using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Test : MonoBehaviour
{
    public GameObject listButtonPrefab;
    GameObject list;
    int n;
    void Start()
    {
        list = GameObject.Find("List");
        Transform listTrs = list.transform;
        for (int i = 0; i < 5; i++)
        {
            //プレハブからボタンを生成
            GameObject listButton = Instantiate(listButtonPrefab) as GameObject;
            //Vertical Layout Group の子にする
            listButton.transform.SetParent(listTrs, false);
            listButton.transform.Find("StageName").GetComponent<Text>().text = "STAGE"+(i+1).ToString();
            //以下、追加---------
            n = i;
            //引数に何番目のボタンかを渡す
            listButton.GetComponent<Button>().onClick.AddListener(() => MyOnClick(n));
        }
    }
    void MyOnClick(int index)
    {
        print(index);
    }
}