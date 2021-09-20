using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject talkPanel;
    public Text TalkText;
    public GameObject scanObject;// 플레이어가 조사했던 오브젝트 변수
    public bool isAction; // 판넬이 띄워져있는가

    private void Start()
    {
        isAction = false;
        talkPanel.SetActive(false);
    }
    // Update is called once per frame
    public void Action(GameObject scanObj)
    {
        if (isAction)
        {
            isAction = false;
        }
        else
        {
            isAction = true;
            scanObject = scanObj;
            TalkText.text = "이것의 이름은 " + scanObject.name + "이라고 한다.";
        }
        talkPanel.SetActive(isAction);
    }
}
