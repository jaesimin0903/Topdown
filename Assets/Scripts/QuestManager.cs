using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int questId;
    public int questActionIndex;//quest ������ ������ ����
    public GameObject[] questObject;
    Dictionary<int, QuestData> questList;

     void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("�翵�� ����ϱ�", new int[] {1000, 2000 }));//questId, questData
        questList.Add(20, new QuestData("�翵�� ó���ϱ�", new int[] { 5000, 2000 }));//questId, questData
        questList.Add(30, new QuestData("����Ʈ �� Ŭ����", new int[] { 0 }));//questId, questData
    }

    public int GetQuestTalkIndex(int id)
    {

        return questId + questActionIndex;
    }

    public string checkQuest(int id)
    {
        

        if(id == questList[questId].npcId[questActionIndex])//quest ������� �ϱ����� 
            questActionIndex++;

        //control quest object
        controlObject();
        if (questActionIndex == questList[questId].npcId.Length)//����Ʈ ������ ���� �������� �� ����Ʈ ��ȣ ����
            nextQuest();

        return questList[questId].questName;
    }
    public string checkQuest()
    {
        return questList[questId].questName;
    }
    void nextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void controlObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex == 2)
                    questObject[0].SetActive(true);
                break;
            case 20:
                if (questActionIndex == 1)
                    questObject[0].SetActive(false);
                
                break;
        }
    }
}
