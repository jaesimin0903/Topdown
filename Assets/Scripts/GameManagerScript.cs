using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject talkPanel;
    public Text TalkText;
    public GameObject scanObject;// �÷��̾ �����ߴ� ������Ʈ ����
    public bool isAction; // �ǳ��� ������ִ°�

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
            TalkText.text = "�̰��� �̸��� " + scanObject.name + "�̶�� �Ѵ�.";
        }
        talkPanel.SetActive(isAction);
    }
}
