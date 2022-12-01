using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    Dictionary<string, int> Inv = new Dictionary<string, int>
{
    {"55200" , 1},
    {"4638" , 10},
    {"9337" , 10},
    {"9843" , 10},
    {"4620" , 1},
    {"4672" , 10},
    {"4642" , 10},
    {"4639" , 10},
    {"4637" , 10},
    {"4633" , 10},
    {"4645" , 10},
    {"4618" , 10}
};
    Button btn;

    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       foreach(var item in Inv)
        {
            GameObject.Find(item.Key).GetComponent<InventoryControl>().updatenum(item.Value);
        }
    }


    public void changenum(string ID, int num)
    {
        Inv[ID] = num;
        GameObject.Find(ID).GetComponent<InventoryControl>().updatenum(num);
        
    }

    public void addnum(string ID, int num)
    {
        Inv[ID] += num;
        GameObject.Find(ID).GetComponent<InventoryControl>().updatenum(Inv[ID]);
    }
    public int  minusnum(string ID, int num)
    {
        if (Inv[ID] >= num)
        {
            Inv[ID] -= num;
            GameObject.Find(ID).GetComponent<InventoryControl>().updatenum(Inv[ID]);
            return 0;
        }
        else return 1;
    }
    public int getnum(string ID)
    {
        return Inv[ID];
    }


}