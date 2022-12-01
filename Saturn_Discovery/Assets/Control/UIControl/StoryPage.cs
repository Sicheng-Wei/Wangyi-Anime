using System.Threading;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryPage : MonoBehaviour
{
    readonly string[] storyText = {
        "13年前，我与其他的革命者们因反对地球联合政府被流放至位于海王星的勒维耶监狱中...",
        "这里冰冷，孤寂，空旷，我们被迫每天工作14小时为当局开采海王星上必要的蓝锥矿与富钛矿物，以支撑当局位于地－月拉格朗日点的星环主城的建设需求...",
        "我与其他革命者之间几乎不能有任何言语上的沟通，以至于多年来我已经遗忘了如何说一段完整的话...",
        "两个月前，一个偶然的机会，我听闻狱警的交谈，了解到地球联合政府正在分崩离析，陷入了连绵不绝的分裂与内战当中...",
        "终于在刚刚，也就是12小时前，我趁看守不注意，抢夺了一辆轻量级行星际飞船，义无反顾的向地球进发。遗憾的是，逃离的过程中，微型曲率加速引擎被打坏了，核动力燃料也所剩无几，我必须找到一个地方来补充足够的燃料...",
        "而此时，土星出现了..."
    };

    private int pageOrder;
    [SerializeField]
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        pageOrder = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = storyText[pageOrder];
        if(Input.GetMouseButtonUp(0)) 
        {
            pageOrder++;
        }
        if (pageOrder == storyText.Length)
        {
            SceneManager.LoadScene("OutdoorsScene");
        }
    }
}
