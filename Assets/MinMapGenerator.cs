using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMapGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject cell;

    //cellList is consisted of 'field' which is a cell.
    private GameObject[,] cellList = new GameObject[3, 4];

    [SerializeField]
    private GameObject skillCard;

    private float[]

            minMapX,
            minMapY;

    private float[]

            skillCardX,
            skillCardY;

    public int availableEN;
    
    // Start is called before the first frame update
    void Start()
    {
        GameMaster.p1Skills = new GameObject[3];
        GameMaster.p1Size = 0;
        GameMaster.p2Skills = new GameObject[3];
        GameMaster.p2Size = 0;
        minMapX = new float[] { 2.3f, 3.8f, 5.3f, 6.8f };
        minMapY = new float[] { -2.9f, -3.6f, -4.3f };

        //increase this if size of skill list reaches certain amount
        float xLocationHelper = GameMaster.p1SkillList.Length == 10 ? 0.0f : (GameMaster.p1SkillList.Length <13 ? 1.8f: 3.6f ) ;
        skillCardX = new float[] { -3.6f, -1.8f, 0.0f, 1.8f, 3.6f };
        skillCardY = new float[] { 0.8f, -1.3f };

        availableEN = GameMaster.p1c.getEN();

        GameObject p1MinProfile = GameMaster.p1c.getMinProfile();
        GameObject p1min =
            Instantiate(p1MinProfile,
            new Vector3(minMapX[GameMaster.p1x] - 0.5f,
                minMapY[GameMaster.p1y],
                -2),
            Quaternion.identity);
        p1min.transform.parent = gameObject.transform;
        p1min.transform.localScale = new Vector3(0.5f, 0.5f, 1);

        GameObject p2MinProfile = GameMaster.p2c.getMinProfile();
        GameObject p2min =
            Instantiate(p2MinProfile,
            new Vector3(minMapX[GameMaster.p2x] + 0.5f,
                minMapY[GameMaster.p2y],
                -2),
            Quaternion.identity);
        p2min.transform.parent = gameObject.transform;
        p2min.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                GameObject minMapCell =
                    Instantiate(cell,
                    new Vector3(minMapX[j], minMapY[i], -1),
                    Quaternion.identity);
                cellList[i, j] = minMapCell;
                minMapCell.transform.parent = gameObject.transform;
            }
        }

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject skillcard =
                    Instantiate(skillCard,
                    new Vector3(skillCardX[j] -xLocationHelper, skillCardY[i], -1),
                    Quaternion.identity);
                skillcard
                    .GetComponent<SkillCardManager>()
                    .setImage(1,
                    5 * i + j, true);
                skillcard.transform.parent = gameObject.transform;
            }
        }

        //count for adding additional skills
        int count = 0;
        float additionalX = 1.8f;
        while( count < GameMaster.p1SkillList.Length - 10){
            Debug.Log("c" + (GameMaster.p1SkillList.Length - 10));
             GameObject skillcard =
                    Instantiate(skillCard,
                    new Vector3( skillCardX[4] -xLocationHelper + additionalX, skillCardY[count%2], -1),
                    Quaternion.identity);
                skillcard
                    .GetComponent<SkillCardManager>()
                    .setImage(1,
                    10+count, true);
                skillcard.transform.parent = gameObject.transform;
            count ++; 
            if(count == 2){
                additionalX *=2;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public int getAvailableEN()
    {
        return availableEN;
    }

    public void setAvailableEN(int a)
    {
        availableEN = a;
    }
}
