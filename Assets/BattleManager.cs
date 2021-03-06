using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject

            battleField,
            skillCard,
            switchSceneButtonToCombatPlanner,
            switchSceneButtonToMatchingBattle; //fieldGenerator 소유

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

    private bool

            p1guard,
            p2guard; // 0  = player 1 guards, 1 = player 2 guards.

    private GameObject[]

            p1skillCards,
            p2skillCards;

    private float[] skillCardXs;

    private float skillCardY;

    [SerializeField]
    private GameObject updateStatText;

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
        p1guard = false;
        p2guard = false;
        p1skillCards = new GameObject[3];
        p2skillCards = new GameObject[3];

        //sc: skill card
        skillCardXs = new float[3] { 6.0f, 4.25f, 2.5f };
        skillCardY = -4.0f;

        //display skillcards that will be used in this round
        for (int i = 0; i < 3; i++)
        {
            p1skillCards[i] =
                Instantiate(skillCard,
                new Vector3(-skillCardXs[i], skillCardY, -2),
                Quaternion.identity);
            p1skillCards[i]
                .GetComponent<SkillCardManager>()
                .setImage(1,
                System
                    .Array
                    .IndexOf(GameMaster.p1SkillList, GameMaster.p1Skills[i]),
                false);
            p1skillCards[i].GetComponent<SkillCardManager>().tailOfCard();
            p2skillCards[i] =
                Instantiate(skillCard,
                new Vector3(skillCardXs[i], skillCardY, -2),
                Quaternion.identity);
            p2skillCards[i]
                .GetComponent<SkillCardManager>()
                .setImage(2,
                System
                    .Array
                    .IndexOf(GameMaster.p2SkillList, GameMaster.p2Skills[i]),
                false);
            p2skillCards[i].GetComponent<SkillCardManager>().tailOfCard();
        }
        StartCoroutine(activateSkill());
    }

    private IEnumerator activateSkill()
    {
        for (int i = 0; i < 3; i++)
        {
            //if one of them dies, stop casting skills
            if (GameMaster.p1HP <= 0 || GameMaster.p2HP <= 0)
            {
                break;
            }

            yield return new WaitForSeconds(1);
            if (i != 0)
            {
                Destroy(p1skillCards[i - 1]);
                Destroy(p2skillCards[i - 1]);
            }
            p1skillCards[i]
                .GetComponent<SkillCardManager>()
                .setDestination(-0.8f, skillCardY);
            p1skillCards[i].GetComponent<SkillCardManager>().headOfCard();
            p2skillCards[i]
                .GetComponent<SkillCardManager>()
                .setDestination(0.8f, skillCardY);
            p2skillCards[i].GetComponent<SkillCardManager>().headOfCard();
            int count = 0;
            for (int j = i + 1; j < 3; j++)
            {
                p1skillCards[j]
                    .GetComponent<SkillCardManager>()
                    .setDestination(-skillCardXs[count], skillCardY);
                p2skillCards[j]
                    .GetComponent<SkillCardManager>()
                    .setDestination(skillCardXs[count], skillCardY);
                count++;
            }

            yield return new WaitForSeconds(2);

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
                p2controll,
                GameMaster.p1SkillList));
                yield return new WaitForSeconds(2.5f);
                StartCoroutine(activateHelper(i,
                GameMaster.p2Skills,
                p2character,
                p2controll,
                p1controll,
                GameMaster.p2SkillList));
            }
            else
            {
                StartCoroutine(activateHelper(i,
                GameMaster.p2Skills,
                p2character,
                p2controll,
                p1controll,
                GameMaster.p2SkillList));
                yield return new WaitForSeconds(2.5f);
                StartCoroutine(activateHelper(i,
                GameMaster.p1Skills,
                p1character,
                p1controll,
                p2controll,
                GameMaster.p1SkillList));
            }
            yield return new WaitForSeconds(2);
            StartCoroutine(endPhase());
        }

        //display switchScenebutton (from battleField to combatPlanner)
        yield return new WaitForSeconds(1.5f);
        if (GameMaster.match != 3)
        {
            GameObject nextSceneButton =
                (p1controll.getHP() <= 0 || p2controll.getHP() <= 0)
                    ? switchSceneButtonToMatchingBattle
                    : switchSceneButtonToCombatPlanner;

            GameObject button =
                (GameObject)
                Instantiate(nextSceneButton);
        }
    }

    //required time : 0.75s
    private IEnumerator
    activateHelper(
        int i,
        GameObject[] skills,
        characterSetting character,
        playerControll activatercontroll,
        playerControll opponentcontroll,
        GameObject[] skillList
    )
    {
        //attack or additonal skills
        GameObject skill = null;

        //adjust x coordinate depending on player.
        float ax = (activatercontroll == p1controll) ? -0.5f : +0.5f;
        if (skills[i] == skillList[0])
        {
            activatercontroll.moveUp();
            float adjustedX = x[activatercontroll.getX()] + ax;
            float adjustedY = y[activatercontroll.getY()] + 0.8f;

            character.move (adjustedX, adjustedY);

            // p2character.move (adjustedX, adjustedY);
        }
        if (skills[i] == skillList[1])
        {
            activatercontroll.moveDown();
            float adjustedX = x[activatercontroll.getX()] + ax;
            float adjustedY = y[activatercontroll.getY()] + 0.8f;
            character.move (adjustedX, adjustedY);
        }
        if (skills[i] == skillList[2])
        {
            activatercontroll.moveLeft();

            float adjustedX = x[activatercontroll.getX()] + ax;
            float adjustedY = y[activatercontroll.getY()] + 0.8f;
            character.move (adjustedX, adjustedY);
        }
        if (skills[i] == skillList[3])
        {
            activatercontroll.moveRight();

            float adjustedX = x[activatercontroll.getX()] + ax;
            float adjustedY = y[activatercontroll.getY()] + 0.8f;
            character.move (adjustedX, adjustedY);
        }
        if (skills[i] == skillList[4])
        {
            character.guard (activatercontroll);
             instantiateStatText(activatercontroll.getX(),
                activatercontroll.getY(),
                15,
                "DEF +");
            //   p2character.guard (p2controll);
        }

        if (skills[i] == skillList[5])
        {
            skill = character.useSkill(activatercontroll, 1);
        }
        if (skills[i] == skillList[6])
        {
            skill = character.useSkill(activatercontroll, 2);
        }
        if (skills[i] == skillList[7])
        {
            skill = character.useSkill(activatercontroll, 3);
        }
        if (skills[i] == skillList[8])
        {
            skill = character.useSkill(activatercontroll, 4);
        }
        if (skills[i] == skillList[9])
        {
            character.heal (activatercontroll);
            instantiateStatText(activatercontroll.getX(),
            activatercontroll.getY(),
            15,
            "EN UP ");
            int playerCode = (activatercontroll == p1controll) ? 0 : 1;
        }

        //additional skill test
        if (skillList.Length > 10)
        {
            if (skills[i] == GameMaster.additionalSkillList[0])
            {
                character.restore (activatercontroll);
                instantiateStatText(activatercontroll.getX(),
                activatercontroll.getY(),
                30,
                "HP UP ");
            } //defense
            else if (skills[i] == GameMaster.additionalSkillList[1])
            {
                character.defense (activatercontroll);
                instantiateStatText(activatercontroll.getX(),
                activatercontroll.getY(),
                1000,
                "DEF +");
            } //missile
            else if (skills[i] == GameMaster.additionalSkillList[2])
            {
                skill = character.missile(activatercontroll, opponentcontroll);
            } //smash
            else if (skills[i] == GameMaster.additionalSkillList[3])
            {
                skill = character.smash(activatercontroll);
            } //up left
            else if (skills[i] == GameMaster.additionalSkillList[4])
            {
                activatercontroll.moveUp();
                activatercontroll.moveLeft();
                float adjustedX = x[activatercontroll.getX()] + ax;
                float adjustedY = y[activatercontroll.getY()] + 0.8f;

                character.move (adjustedX, adjustedY);
            } //up right
            else if (skills[i] == GameMaster.additionalSkillList[5])
            {
                activatercontroll.moveUp();
                activatercontroll.moveRight();
                float adjustedX = x[activatercontroll.getX()] + ax;
                float adjustedY = y[activatercontroll.getY()] + 0.8f;

                character.move (adjustedX, adjustedY);
            } //down left
            else if (skills[i] == GameMaster.additionalSkillList[6])
            {
                activatercontroll.moveDown();
                activatercontroll.moveLeft();
                float adjustedX = x[activatercontroll.getX()] + ax;
                float adjustedY = y[activatercontroll.getY()] + 0.8f;

                character.move (adjustedX, adjustedY);
            } //down right
            else if (skills[i] == GameMaster.additionalSkillList[7])
            {
                activatercontroll.moveDown();
                activatercontroll.moveRight();
                float adjustedX = x[activatercontroll.getX()] + ax;
                float adjustedY = y[activatercontroll.getY()] + 0.8f;

                character.move (adjustedX, adjustedY);
            }
        }

        //if skill is attack skill,
        if (skill != null)
        {
            int[] targetArea =
                skill.GetComponent<skillManager>().getTargetArea();
            StartCoroutine(applyAttackSkill(skill,
            targetArea,
            activatercontroll,
            opponentcontroll));
        }
        skills[i].GetComponent<skillManager>().setIsUsed(false);

        yield return new WaitForSeconds(0.75f);

        //if current skill is not guard, then actioncomplete
        if (
            skills[i] == skillList[4] ||
            skills[i] == GameMaster.additionalSkillList[1]
        )
        {
            if (activatercontroll == p1controll)
            {
                p1guard = true;
            }
            else
            {
                p2guard = true;
            }
        }
    }

    //required time: 2s
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

        //react if it hits
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

            //updatePlayerInfoBar(attacker, playerCode2, false);
            //if opponent is located in targeted area, reduce its hp by skill damage.
            if (skillX == opponentX && skillY == opponentY)
            {
                int dm =
                    skill.GetComponent<skillManager>().getDamage() -
                    attackee.getDEF();
                if (dm < 0)
                {
                    dm = 0;
                }
                attackee.setHP(attackee.getHP() - dm);

                instantiateStatText(opponentX, opponentY, -dm, "HP ");

                //update HP bar of opponent of a skill caster.
                int playerCode = (attackee == p2controll) ? 1 : 0;

                //  updatePlayerInfoBar(attackee, playerCode, true);
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
        }

        //return the color of cell to white . return the cell color to its original state.
        // StartCoroutine(changeColorBack(coordinateList));.
        yield return new WaitForSeconds(1.5f);
        for (int j = 0; j < coordinateList.Count; j++)
        {
            int[] cell = coordinateList[j];
            int skillX = cell[1];
            int skillY = cell[0];

            list[skillY, skillX].GetComponent<SpriteRenderer>().color =
                new Color(255, 255, 255, 0.5f);
        }
    }

    //count: # of target cells.
    private IEnumerator changeColorBack(List<int[]> coordinateList)
    {
        yield return new WaitForSeconds(1.5f);
        for (int j = 0; j < coordinateList.Count; j++)
        {
            int[] cell = coordinateList[j];
            int skillX = cell[1];
            int skillY = cell[0];

            list[skillY, skillX].GetComponent<SpriteRenderer>().color =
                new Color(255, 255, 255, 0.5f);
        }
    }

    private void instantiateStatText(int playerX, int playerY, int dm, string t)
    {
        GameObject text =
            Instantiate(updateStatText,
            new Vector3(x[playerX], y[playerY], -2),
            Quaternion.identity);
        text
            .GetComponent<MoveToDestination>()
            .setDestination(x[playerX], y[playerY] + 2, 0, true);
        text.GetComponent<MoveToDestination>().setSpeed(3);
        text.GetComponent<textColorManager>().setTextAndColor(dm, t);
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
        if (p1guard)
        {
            p1character.actionComplete();
            p1controll.setDEF(0);
            p1guard = false;
        }
        if (p2guard)
        {
            p2character.actionComplete();
            p2controll.setDEF(0);
            p2guard = false;
        }

        yield return new WaitForSeconds(0.5f);
        updatePlayerInfoBar(p1controll, 0, true);
        updatePlayerInfoBar(p1controll, 0, false);
        updatePlayerInfoBar(p2controll, 1, true);
        updatePlayerInfoBar(p2controll, 1, false);

        //at least one of them is dead.
        if (p1controll.getHP() <= 0 || p2controll.getHP() <= 0)
        {
            AudioMaster.playMainAudio();
            if (p1controll.getHP() <= 0)
            {
                p1character.die();
                p2character.isVictory();
            }
            if (p2controll.getHP() <= 0)
            {
                p2character.die();
                p1character.isVictory();
                if (p1controll.getHP() > 0)
                {
                    GameMaster.match++;
                }

                if (GameMaster.match == 3)
                {
                    yield return new WaitForSeconds(3f);
                    SceneManager.LoadScene("Victory");
                }
            }
        }
    }
}
