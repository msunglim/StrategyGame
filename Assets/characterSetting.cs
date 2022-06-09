using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSetting : MonoBehaviour
{
    [SerializeField]
    private Sprite sp;

    [SerializeField]
    private Sprite characterProfile;

    private SpriteRenderer spr;

    private int direction;

    [SerializeField]
    private GameObject[] skillList;

    private GameObject currSkill;

    [SerializeField]
    private GameObject minProfile;

    //private GameObject skill1Effect;
    private Animator anime;

    [SerializeField]
    private string characterName;

    private float

            moveDirectionX,
            moveDirectionY,
            adjustedX,
            adjustedY;

    // Start is called before the first frame update
    void Awake()
    {
        anime = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        spr.sprite = sp;
    }

    void Update()
    {
        if (anime.GetBool(characterName + "isMove") == true)
        //if(transform.position.x != adjustedX && transform.position.y != adjustedY)
        {
            int speed = (transform.position.x == adjustedX) ? 2 : 5; //2: move vertically 5: move horizontally
            transform.position =
                Vector3
                    .MoveTowards(transform.position,
                    new Vector3(adjustedX, adjustedY, -2),
                    Time.deltaTime * speed);
            if (
                transform.position.x == adjustedX &&
                transform.position.y == adjustedY
            )
            {
                anime.SetBool(characterName + "isMove", false);
            }
            // transform.position += new Vector3(moveDirectionX, moveDirectionY, 0)* 4* Time.deltaTime;
        }
    }

    public void setAnime(Animator ani)
    {
        anime = ani;
    }

    public Sprite getCharacterProfile()
    {
        return characterProfile;
    }

    public GameObject[] getSkillList()
    {
        return skillList;
    }

    public GameObject getMinProfile()
    {
        return minProfile;
    }

    public void setDirection(int d)
    {
        direction = d;
    }

    //return SKill object for instantiating skill effect in battle field
    public GameObject useSkill(playerControll pc, int skillindex)
    {
        //use skill if it has enough energy to cast.
        if (
            pc.getEN() >=
            skillList[4 + skillindex].GetComponent<skillManager>().getCost()
        )
        {
            anime.SetInteger(characterName + "useSkill", skillindex);
            pc
                .setEN(pc.getEN() -
                skillList[4 + skillindex]
                    .GetComponent<skillManager>()
                    .getCost());
            currSkill = skillList[4 + skillindex];
            return skillList[4 + skillindex];
        }
        else
        {
            return null;
        }
    }

    //animation에서 사용됨
    //go to 1 direction
    public void effect1()
    {
        currSkill
            .GetComponent<skillManager>()
            .effect(direction,
            transform.position.x,
            transform.position.y,
            15,
            0);
    }

    //go to 8 directions
    public void effect2()
    {
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if (i == 0 && j == 0) continue;
                currSkill
                    .GetComponent<skillManager>()
                    .effect(direction,
                    transform.position.x,
                    transform.position.y,
                    5 * i,
                    5 * j);
            }
        }
    }

    public void effect3()
    {
        currSkill
            .GetComponent<skillManager>()
            .effect(direction,
            transform.position.x,
            transform.position.y + 10,
            0,
            -15);
    }

    public GameObject heal(playerControll pc)
    {
        pc.setEN(pc.getEN() + 15);
        anime.SetBool(characterName + "isHeal", true);
        return skillList[9];
    }

    public GameObject guard(playerControll pc)
    {
        pc.setDEF(15);
        anime.SetBool(characterName + "isGuard", true);
        return skillList[4];
    }

    public void getHit()
    {
        anime.SetBool(characterName + "isHit", true);
    }

    public void die()
    {
        anime.SetBool(characterName + "isDead", true);
    }

    public Sprite getSprite()
    {
        return sp;
    }

    public void actionComplete()
    {
        anime.SetInteger(characterName + "useSkill", 0);
        anime.SetBool(characterName + "isHit", false);
        anime.SetBool(characterName + "isHeal", false);
        anime.SetBool(characterName + "isGuard", false);
        currSkill = null;
    }

    public void changeDirection()
    {
        direction = -direction;
        transform.Rotate(new Vector3(0, 180, 0));
    }

    //return which direction move is used.
    //aX,aY: destination of character location.
    public GameObject move(float aX, float aY)
    {
        anime.SetBool(characterName + "isMove", true);
        adjustedX = aX;
        adjustedY = aY;

        float currX = transform.position.x;
        float currY = transform.position.y;

        if (currX == adjustedX)
        {
            if (currY < adjustedY)
            {
                return skillList[0];
            }
            else
            {
                return skillList[1];
            }
        }
        else
        {
            if (currX < adjustedX)
            {
                return skillList[2];
            }
            else
            {
                return skillList[3];
            }
        }
    }
}
