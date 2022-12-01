using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftBlock : MonoBehaviour
{
    private string ID = "";

    [SerializeField]
    CraftBlock nextbutton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ID != "")
        {
            gameObject.GetComponent<Button>().image.sprite = GameObject.Find(ID).GetComponent<Button>().image.sprite;//更新图片
        }
        else
        {
            gameObject.GetComponent<Button>().image.sprite = null;
        }
    }
    public bool filled()
    {
        if (ID != "") return true;
        else return false;
    }
    public int fill(string IDinput)//1则成功填入，0则未成功
    {
        if (filled())
        {
            ID = IDinput;
            return 1;
        }
        else if (nextbutton) return nextbutton.fill(ID);
        else return 0;
    }
    public void unfill()
    {
        if(filled())
        {
            GameObject.Find("InventoryPanel").GetComponent<InventoryManager>().addnum(ID,1);
            ID = "";

        }

    }

}
