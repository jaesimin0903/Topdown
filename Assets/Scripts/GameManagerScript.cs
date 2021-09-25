using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public QuestManager questManager;
    public Image portraitImg;
    public TalkManager talkManager;
    public GameObject talkPanel;
    public Text TalkText;
    public GameObject scanObject;// �÷��̾ �����ߴ� ������Ʈ ����
    public bool isAction; // �ǳ��� ������ִ°�
    public int talkIndex;

    
     void Start()
    {
        isAction = false;
        talkPanel.SetActive(false);
        Debug.Log(questManager.checkQuest());
    }
    // Update is called once per frame
    public void Action(GameObject scanObj)
    {

            scanObject = scanObj;
            ObjData objData = scanObject.GetComponent<ObjData>();
            Talk(objData.id, objData.isNpc);
            talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);//��ȭ ����

        if(talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            Debug.Log(questManager.checkQuest(id));
            return;
        }

        if (isNpc)
        {
            TalkText.text = talkData.Split(':')[0] ;

            portraitImg.sprite = talkManager.GetPortrait(id , int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            TalkText.text = talkData;
            portraitImg.color = new Color(1, 1, 1, 0);
        }
        isAction = true;
        talkIndex++;
    }
}
