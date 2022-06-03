using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject battleField;

    // Start is called before the first frame update
    void Start()
    {
        //현재 필드위에올라가 있는 player
        GameObject p1 = battleField.GetComponent<FieldGenerator>().getPlayer1();

        playerControll p1controll =
            battleField.GetComponent<FieldGenerator>().getPlayer1Controll();

        //p1을 조종하기위해선 그안에있는 character에 접근필요.
        float[] x = battleField.GetComponent<FieldGenerator>().getXList();
        float[] y = battleField.GetComponent<FieldGenerator>().getYList();
        characterSetting p1character = p1.GetComponent<characterSetting>();
        GameObject playerInfo = GameObject.Find("PlayerInfo");
            StartCoroutine(activateSkill(p1character, p1controll, x, y,playerInfo));
        
    }

    private IEnumerator
    activateSkill(
        characterSetting p1character,
        playerControll p1controll,
        float[] x,
        float[] y,
        GameObject playerInfo
      
    )
    {
        for (int i = 0; i < 3; i++)
        {
        if (GameMaster.p1Skills[i] == p1character.getSkillList()[0])
        {
            p1controll.moveUp();

            float adjustedX = x[p1controll.getX()] - 0.5f;
            float adjustedY = y[p1controll.getY()] + 0.8f;
            p1character.move (adjustedX, adjustedY);
            Debug.Log("move move");
        }
        if (GameMaster.p1Skills[i] == p1character.getSkillList()[1])
        {
            p1controll.moveDown();

            float adjustedX = x[p1controll.getX()] - 0.5f;
            float adjustedY = y[p1controll.getY()] + 0.8f;
            p1character.move (adjustedX, adjustedY);
            Debug.Log("move move");
        }
        if (GameMaster.p1Skills[i] == p1character.getSkillList()[2])
        {
            p1controll.moveLeft();

            float adjustedX = x[p1controll.getX()] - 0.5f;
            float adjustedY = y[p1controll.getY()] + 0.8f;
            p1character.move (adjustedX, adjustedY);
            Debug.Log("move move");
        }
        if (GameMaster.p1Skills[i] == p1character.getSkillList()[3])
        {
            p1controll.moveRight();

            float adjustedX = x[p1controll.getX()] - 0.5f;
            float adjustedY = y[p1controll.getY()] + 0.8f;
            p1character.move (adjustedX, adjustedY);
            Debug.Log("move move");
        }
        if (GameMaster.p1Skills[i] == p1character.getSkillList()[4])
        {
            p1character.guard (p1controll);
            Debug.Log("guard guard");
        }
        if (GameMaster.p1Skills[i] == p1character.getSkillList()[5])
        {
            p1character.useSkill(p1controll, 1);
            Debug.Log("attack attack");
        }
        if (GameMaster.p1Skills[i] == p1character.getSkillList()[6])
        {
            p1character.useSkill(p1controll, 2);
            Debug.Log("attack attack");
        }
        if (GameMaster.p1Skills[i] == p1character.getSkillList()[7])
        {
            p1character.useSkill(p1controll, 3);
            Debug.Log("attack attack");
        }
        if (GameMaster.p1Skills[i] == p1character.getSkillList()[8])
        {
            p1character.useSkill(p1controll, 4);
            Debug.Log("attack attack");
        }
        if (GameMaster.p1Skills[i] == p1character.getSkillList()[9])
        {
            p1character.heal (p1controll);
            Debug.Log("heal heal");
        }
         playerInfo
                .transform
                .GetChild(0)
                .GetComponent<statManager>()
                .updateENbar(p1controll.getEN());
            yield return new WaitForSeconds(2);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
    }
}
