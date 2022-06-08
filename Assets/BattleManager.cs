using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject battleField; //fieldGenerator 소유

    private GameObject

            p1,
            p2; //현재 필드위에올라가 있는 player

    private GameObject playerInfo; //HP, EN창

    private characterSetting

            p1character,
            p2character; //player의 character 정보들 조작

    private playerControll

            p1controll,
            p2controll; //player 정보, 위치조작

    private float[]

            x,
            y;

    private GameObject[,] list;

    // Start is called before the first frame update
    void Start()
    {
        list = battleField.GetComponent<FieldGenerator>().getCellList();
        p1 = battleField.GetComponent<FieldGenerator>().getPlayer1();
        p2 = battleField.GetComponent<FieldGenerator>().getPlayer2();

        p1controll =
            battleField.GetComponent<FieldGenerator>().getPlayer1Controll();
        p2controll =
            battleField.GetComponent<FieldGenerator>().getPlayer2Controll();

        //p1을 조종하기위해선 그안에있는 character에 접근필요.
        x = battleField.GetComponent<FieldGenerator>().getXList();
        y = battleField.GetComponent<FieldGenerator>().getYList();
        p1character = p1.GetComponent<characterSetting>();
        p2character = p2.GetComponent<characterSetting>();
        playerInfo = GameObject.Find("PlayerInfo");

        StartCoroutine(activateSkill());
    }

    private IEnumerator activateSkill()
    {
        for (int i = 0; i < 3; i++)
        {
            if (
                GameMaster
                    .p1Skills[i]
                    .GetComponent<skillManager>()
                    .getSkillPriority() <=
                GameMaster
                    .p2Skills[i]
                    .GetComponent<skillManager>()
                    .getSkillPriority()
            )
            {
                StartCoroutine(activateHelper(i,
                GameMaster.p1Skills,
                p1character,
                p1controll,
                p2controll));
                yield return new WaitForSeconds(2);
                StartCoroutine(activateHelper(i,
                GameMaster.p2Skills,
                p2character,
                p2controll,
                p1controll));
                yield return new WaitForSeconds(2);
            }else{
                StartCoroutine(activateHelper(i,
                GameMaster.p2Skills,
                p2character,
                p2controll,
                p1controll));
                yield return new WaitForSeconds(2);
                StartCoroutine(activateHelper(i,
                GameMaster.p1Skills,
                p1character,
                p1controll,
                p2controll));
                yield return new WaitForSeconds(2);
                
            }
        }
    }

    private IEnumerator
    activateHelper(
        int i,
        GameObject[] skills,
        characterSetting character,
        playerControll activatercontroll,
        playerControll opponentcontroll
    )
    {
        if (skills[i] == character.getSkillList()[0])
        {
            activatercontroll.moveUp();

            //  p2controll.moveUp();
            float adjustedX = x[activatercontroll.getX()] - 0.5f;
            float adjustedY = y[activatercontroll.getY()] + 0.8f;

            character.move (adjustedX, adjustedY);

            // p2character.move (adjustedX, adjustedY);
            Debug.Log("move move");
        }
        if (skills[i] == character.getSkillList()[1])
        {
            activatercontroll.moveDown();

            float adjustedX = x[activatercontroll.getX()] - 0.5f;
            float adjustedY = y[activatercontroll.getY()] + 0.8f;
            character.move (adjustedX, adjustedY);
            Debug.Log("move move");
        }
        if (skills[i] == character.getSkillList()[2])
        {
            activatercontroll.moveLeft();

            float adjustedX = x[activatercontroll.getX()] - 0.5f;
            float adjustedY = y[activatercontroll.getY()] + 0.8f;
            character.move (adjustedX, adjustedY);
            Debug.Log("move move");
        }
        if (skills[i] == character.getSkillList()[3])
        {
            activatercontroll.moveRight();

            float adjustedX = x[activatercontroll.getX()] - 0.5f;
            float adjustedY = y[activatercontroll.getY()] + 0.8f;
            character.move (adjustedX, adjustedY);
            Debug.Log("move move");
        }
        if (skills[i] == character.getSkillList()[4])
        {
            character.guard (p1controll);

            //   p2character.guard (p2controll);
            Debug.Log("guard guard");
        }

        //attack skills
        GameObject skill = null;
        if (skills[i] == character.getSkillList()[5])
        {
            skill = character.useSkill(activatercontroll, 1);

            //   p2character.useSkill(p2controll, 1);
            Debug.Log("attack attack");
        }
        if (skills[i] == character.getSkillList()[6])
        {
            skill = character.useSkill(activatercontroll, 2);
            Debug.Log("attack attack");
        }
        if (skills[i] == character.getSkillList()[7])
        {
            skill = character.useSkill(activatercontroll, 3);
            Debug.Log("attack attack");
        }
        if (skills[i] == character.getSkillList()[8])
        {
            skill = character.useSkill(activatercontroll, 4);
            Debug.Log("attack attack");
        }
        if (skills[i] == character.getSkillList()[9])
        {
            character.heal (activatercontroll);

            //  p2character.heal (p2controll);
            // updatePlayerInfoBar(p1controll, 0, false);
            Debug.Log("heal heal");
        }

        if (skill != null)
        {
            int[] targetArea =
                skill.GetComponent<skillManager>().getTargetArea();
            StartCoroutine(applyAttackSkill(skill,
            targetArea,
            activatercontroll,
            opponentcontroll));

            StartCoroutine(endPhase());
        }

        yield return new WaitForSeconds(2);
    }

    private IEnumerator
    applyAttackSkill(
        GameObject skill,
        int[] targetArea,
        playerControll attacker,
        playerControll attackee
    )
    {
        List<int[]> coordinateList = new List<int[]>();
        for (int i = 0; i < targetArea.Length; i++)
        {
            int x = attacker.getX();
            int y = attacker.getY();
            try
            {
                switch (targetArea[i])
                {
                    case 0:
                        list[y - 1, x - 1]
                            .GetComponent<SpriteRenderer>()
                            .color = new Color(255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y - 1, x - 1 });
                        break;
                    case 1:
                        list[y - 1, x].GetComponent<SpriteRenderer>().color =
                            new Color(255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y - 1, x });
                        break;
                    case 2:
                        list[y - 1, x + 1]
                            .GetComponent<SpriteRenderer>()
                            .color = new Color(255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y - 1, x + 1 });
                        break;
                    case 3:
                        list[y, x - 1].GetComponent<SpriteRenderer>().color =
                            new Color(255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y, x - 1 });
                        break;
                    case 4:
                        list[y, x].GetComponent<SpriteRenderer>().color =
                            new Color(255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y, x });
                        break;
                    case 5:
                        list[y, x + 1].GetComponent<SpriteRenderer>().color =
                            new Color(255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y, x + 1 });
                        break;
                    case 6:
                        list[y + 1, x - 1]
                            .GetComponent<SpriteRenderer>()
                            .color = new Color(255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y + 1, x - 1 });
                        break;
                    case 7:
                        list[y + 1, x].GetComponent<SpriteRenderer>().color =
                            new Color(255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y + 1, x });
                        break;
                    case 8:
                        list[y + 1, x + 1]
                            .GetComponent<SpriteRenderer>()
                            .color = new Color(255, 0, 0, 0.5f);
                        coordinateList.Add(new int[] { y + 1, x + 1 });
                        break;
                }
            }
            catch (System.Exception ex)
            {
                //if targeted area of skill is out of field.
                Debug.Log (ex);
                //it's ok to have outofrange exception.
            }
        }

        //return the cell color to its original state.
        yield return new WaitForSeconds(0.5f);

        int opponentX = attackee.getX();
        int opponentY = attackee.getY();

        for (int j = 0; j < coordinateList.Count; j++)
        {
            //skillXY: where skill lands, opponextXY
            int[] cell = coordinateList[j];
            int skillX = cell[1];
            int skillY = cell[0];

            GameObject playerInfo = GameObject.Find("PlayerInfo");

            //update EN bar of a skill caster.
            //p2는 피격자다. 피격자가 p2가 아닐경우에는 p2가 스킬시전자란소리.
            int playerCode2 = (attackee != p2controll) ? 1 : 0;
            updatePlayerInfoBar(attacker, playerCode2, false);

            //if opponent is located in targeted area, reduce its hp by skill damage.
            if (skillX == opponentX && skillY == opponentY)
            {
                attackee
                    .setHP((attackee.getHP() + attackee.getDEF()) -
                    skill.GetComponent<skillManager>().getDamage());

                //update HP bar of opponent of a skill caster.
                int playerCode = (attackee == p2controll) ? 1 : 0;
                updatePlayerInfoBar(attackee, playerCode, true);

                //가드일경우 하지않는다!
                //player 1 is hit by the skill
                if (playerCode == 0)
                {
                    p1character.getHit();
                }
                else
                {
                    p2character.getHit();
                }
            }

            //return the color of cell to white.
            list[skillY, skillX].GetComponent<SpriteRenderer>().color =
                new Color(255, 255, 255, 0.5f);
        }
    }

    //playercode 0 = player 1 , playercode 1 = player 2
    private void updatePlayerInfoBar(
        playerControll pc,
        int playerCode,
        bool updateHP
    )
    {
        if (updateHP)
        {
            playerInfo
                .transform
                .GetChild(playerCode)
                .GetComponent<statManager>()
                .updateHPbar(pc.getHP());
        }
        else
        {
            playerInfo
                .transform
                .GetChild(playerCode)
                .GetComponent<statManager>()
                .updateENbar(pc.getEN());
        }
    }

    //exeucte this code after any attack skill executes.
    //if player's hp is less or equal to zero, it dies.
    private IEnumerator endPhase()
    {
        yield return new WaitForSeconds(0.5f);
        if (p1controll.getHP() <= 0)
        {
            p1character.die();
        }
        if (p2controll.getHP() <= 0)
        {
            p2character.die();
        }
    }
}
