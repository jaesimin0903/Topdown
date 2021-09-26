using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    // Start is called before the first frame update
    //� ��簡 ����
    Dictionary<int, string[]> talkData;//id, ���
    Dictionary<int, Sprite> portraitData;//�ʻ�ȭ ������
    Dictionary<int, string> nameData;
    public Sprite[] portraitArr;
    

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        nameData = new Dictionary<int, string>();
        GenerateData();
    }

    void GenerateData(){
        talkData.Add(1000, new string[] { "�ȳ�?:0", "����;���.:3" });//npc A :number -> index
        talkData.Add(2000, new string[] { "���翵�� ���� �ٺ����:3", "��������:2" });//npc A :number -> index
        talkData.Add(100, new string[] { "���� å���̾�" });//desk
        talkData.Add(200, new string[] { "���� �ڽ���!" });//box
        //quest talk
        talkData.Add(10 + 1000, new string[] { "�翵�� ���� ȭ����.:1", "�������� ��ġ��.:0" });
        talkData.Add(11 + 2000, new string[] { "�翵�̸� ó���� ��ȹ�� ¥���־�:2", "ȥ���� ���ٰǵ� �ʵ� �����ҷ�?:3" });

        talkData.Add(20 + 2000, new string[] { "���� �����̸� ��� ��������:3", "���� ������ž�:3" });
        talkData.Add(20 + 5000, new string[] { "����� ���ſ� ���̴�." });
        talkData.Add(21 + 2000, new string[] { "�������:1" });




        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);

        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);

        nameData.Add(1000, "����");
        nameData.Add(2000, "����");
    }

    public string GetTalk(int id,int talkIndex)//id, ��ȭ���� ������ ���� index
    {
        if (!talkData.ContainsKey(id))//
        {
            //����Ʈ ������� �� ��簡 ���� ��.
            //����Ʈ �� ó�� ��縦 ������ �´�. 
            if (!talkData.ContainsKey(id - id % 10))
            {
                return GetTalk(id - id % 100, talkIndex);
                
            }
            else
            {
                return GetTalk(id - id % 10, talkIndex);
            }

                //����Ʈ �� ó�� ��縶�� ���� ��
                //�⺻��縦 ������ ���� ��
        }//�ȿ� ������ �ִϾ���
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }

    public string GetName(int id)
    {
        return nameData[id];
    }
}
