using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject prefabUnit;
    public LeaderManager leaderManager;
    public List<Unit> enemys = new List<Unit>();
    public int enemyLv;
    public Transform[] Board;

    UnitInfo lvUnitInfo;

    public GameObject LeaderObj;
    public GameObject Jobobj;
    public GameObject Lvobj;
    public GameObject expObj;
    public GameObject HpObj;
    public GameObject Mpobj;
    public GameObject atkObj;
    public GameObject skillObj;

    enum eBoard
    {
        Leader,
        Job,
        Lv,
        Exp,
        Hp,
        Mp,
        Atk,
        Skill,
        Inv
    }

    public GameObject BackLvBox;
    // Start is called before the first frame update
    void Start()
    {
        SetPlayerTeam();

        enemyLv = 0;
        Invoke("SetEnemyTeam", 5.0f);


    }

    public void BtnSkill(int num)
    {
        switch(num)
        {
            //직업별 스킬 시작
            case 0:
            case 1:
            case 2:
            case 3:
                switch (lvUnitInfo.playerType)
                {
                    case PlayerType.Mele:
                        {
                            int tempNum = -1;
                            //스킬 배운적 있는지 확인
                            for(int i = 0; i < lvUnitInfo.meleSkill.Length; i++)
                            {
                                if (lvUnitInfo.meleSkill[i] == (MeleSkill)(num + 1))
                                {
                                    tempNum = i;
                                    break;
                                }
                            }
                            //아직 스킬응ㄹ 배운적 없음
                            if(tempNum == -1)
                            {
                                //비어있는 스킬칸확인
                                for(int i = 0; i < lvUnitInfo.skillLev.Length; i++)
                                {
                                    if (lvUnitInfo.skillLev[i] == 0)
                                    {
                                        tempNum = i;
                                        break;
                                    }
                                }
                                lvUnitInfo.meleSkill[tempNum] = (MeleSkill)(num + 1);
                                Time.timeScale = 1;
                                BackLvBox.SetActive(false);
                                lvUnitInfo.skillLev[tempNum]++;
                                /* 스킬 UI 부분*/
                                skillObj.transform.GetChild(leaderManager.units.IndexOf(lvUnitInfo.gameObject.GetComponent<Unit>()) + 1).transform.GetChild(tempNum).GetChild(0).GetComponent<Text>().text = lvUnitInfo.meleSkill[tempNum] + "Lv : " + lvUnitInfo.skillLev[tempNum];
                                return;
                            }
                            if (lvUnitInfo.skillLev[tempNum] >= 5)
                            {
                                return;
                            }
                            lvUnitInfo.skillLev[tempNum]++;
                            /* 스킬 UI 부분 */
                            skillObj.transform.GetChild(leaderManager.units.IndexOf(lvUnitInfo.gameObject.GetComponent<Unit>()) + 1).transform.GetChild(tempNum).GetChild(0).GetComponent<Text>().text = lvUnitInfo.meleSkill[tempNum] + "Lv : " + lvUnitInfo.skillLev[tempNum];
                        }
                        break;
                        case PlayerType.Ranged:
                        {
                            int tempNum = -1;
                            //스킬 배운적 있는지 확인
                            for(int i = 0; i < lvUnitInfo.rangeSkill.Length; i++)
                            {
                                if (lvUnitInfo.rangeSkill[i] == (RangeSkill)(num + 1))
                                {
                                    tempNum = i;
                                    break;
                                }
                            }
                            //아직 스킬응ㄹ 배운적 없음
                            if(tempNum == -1)
                            {
                                //비어있는 스킬칸확인
                                for(int i = 0; i < lvUnitInfo.skillLev.Length; i++)
                                {
                                    if (lvUnitInfo.skillLev[i] == 0)
                                    {
                                        tempNum = i;
                                        break;
                                    }
                                }
                                lvUnitInfo.rangeSkill[tempNum] = (RangeSkill)(num + 1);
                                Time.timeScale = 1;
                                BackLvBox.SetActive(false);
                                lvUnitInfo.skillLev[tempNum]++;
                                /* 스킬 UI 부분*/
                                Debug.Log(leaderManager.units.IndexOf(lvUnitInfo.gameObject.GetComponent<Unit>()));

                                skillObj.transform.GetChild(leaderManager.units.IndexOf(lvUnitInfo.gameObject.GetComponent<Unit>()) + 1).transform.GetChild(tempNum).GetChild(0).GetComponent<Text>().text = lvUnitInfo.rangeSkill[tempNum] + "Lv : " + lvUnitInfo.skillLev[tempNum];
                                return;
                            }
                            if (lvUnitInfo.skillLev[tempNum] >= 5)
                            {
                                return;
                            }
                            lvUnitInfo.skillLev[tempNum]++;
                            /* 스킬 UI 부분 */
                            skillObj.transform.GetChild(leaderManager.units.IndexOf(lvUnitInfo.gameObject.GetComponent<Unit>()) + 1).transform.GetChild(tempNum).GetChild(0).GetComponent<Text>().text = lvUnitInfo.rangeSkill[tempNum] + "Lv : " + lvUnitInfo.skillLev[tempNum];
                        }
                        break;
                    case PlayerType.Magic:
                        {
                            int tempNum = -1;
                            //스킬 배운적 있는지 확인
                            for (int i = 0; i < lvUnitInfo.magicSkill.Length; i++)
                            {
                                if (lvUnitInfo.magicSkill[i] == (MagicSkill)(num + 1))
                                {
                                    tempNum = i;
                                    break;
                                }
                            }
                            //아직 스킬응ㄹ 배운적 없음
                            if (tempNum == -1)
                            {
                                //비어있는 스킬칸확인
                                for (int i = 0; i < lvUnitInfo.skillLev.Length; i++)
                                {
                                    if (lvUnitInfo.skillLev[i] == 0)
                                    {
                                        tempNum = i;
                                        break;
                                    }
                                }
                                lvUnitInfo.magicSkill[tempNum] = (MagicSkill)(num + 1);
                                Time.timeScale = 1;
                                BackLvBox.SetActive(false);
                                lvUnitInfo.skillLev[tempNum]++;
                                /* 스킬 UI 부분*/

                                skillObj.transform.GetChild(leaderManager.units.IndexOf(lvUnitInfo.gameObject.GetComponent<Unit>()) + 1).transform.GetChild(tempNum).GetChild(0).GetComponent<Text>().text = lvUnitInfo.magicSkill[tempNum] + "Lv : " + lvUnitInfo.skillLev[tempNum];
                                return;
                            }
                            if (lvUnitInfo.skillLev[tempNum] >= 5)
                            {
                                return;
                            }
                            lvUnitInfo.skillLev[tempNum]++;
                            /* 스킬 UI 부분 */
                            skillObj.transform.GetChild(leaderManager.units.IndexOf(lvUnitInfo.gameObject.GetComponent<Unit>()) + 1).transform.GetChild(tempNum).GetChild(0).GetComponent<Text>().text = lvUnitInfo.magicSkill[tempNum] + "Lv : " + lvUnitInfo.skillLev[tempNum];
                        }
                        break;

                }
                break;
            //공통스킬 시작
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
                {
                    foreach(Unit u in leaderManager.units)
                    {
                        u.unitInfo.commonSkillLev[(num - 4)]++;
                    }
                }
                break;

        }
        Time.timeScale = 1;
        BackLvBox.SetActive (false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSkillUI(int num, UnitInfo unitInfo)
    {
        lvUnitInfo = unitInfo;
        BackLvBox.SetActive(true);
    }

    public void SetUILeader(int num, UnitInfo unitInfo)
    {
        for(int i = 0; i < LeaderObj.transform.childCount-1; i++)
        {
            if(i == num)
            {
                /* Leader UI 부분  "Leader"*/
                LeaderObj.transform.GetChild(i + 1).transform.gameObject.GetComponent<Text>().text = "Leader";


            }
            else
            {
                /* LeaderUI 부분 ""*/
                LeaderObj.transform.GetChild(i + 1).transform.gameObject.GetComponent<Text>().text = "";
            }
        }
    }
    
    public void SetEnemyTeam()
    {
        switch (enemyLv)
        {
            case 0:
                int num = UnityEngine.Random.Range(2, 6);
                for(int i = 0; i < num; i++)
                {
                    Unit unit = Instantiate(prefabUnit, new Vector3(5.0f, 0, 0),prefabUnit.transform.rotation).GetComponent<Unit>();
                    unit.unitInfo.team = Team.Enemy;
                    unit.unitInfo.enemyType = EnemyType.mele1;
                    unit.currentTarget = leaderManager.currentLeader.transform;
                    unit.Leader = leaderManager.currentLeader.transform; //적이 나한테 와야되니까 따라오게끔
                    unit.gameObject.name = EnemyType.mele1.ToString();
                    unit.unitInfo.SetInitEnemyStatus(unit.unitInfo.enemyType);
                    enemys.Add(unit);
                }
                break;
        }
    }
    

    public void SetUI(int num, UnitInfo unitInfo)
    {
        Jobobj.transform.GetChild(num+1).GetComponent<Text>().text = unitInfo.playerType.ToString();
        Lvobj.transform.GetChild(num+1).GetComponent<Text>().text = unitInfo.curLv + "/" + unitInfo.maxLv;
        expObj.transform.GetChild(num + 1).GetComponent<Text>().text = unitInfo.exp + "/" + unitInfo.RequireExp();
        HpObj.transform.GetChild(num + 1).GetComponent<Text>().text = unitInfo.curHp + "/" + unitInfo.maxHp;
        Mpobj.transform.GetChild(num+1).GetComponent<Text>().text = unitInfo.curMp + "/" + unitInfo.MaxMp;
        atkObj.transform.GetChild(num + 1).GetComponent<Text>().text = unitInfo.attackDamage.ToString();

    }


    public void SetPlayerTeam()
    {
        for(int i = 0; i < 3; i++)
        {
            Unit unit = Instantiate(prefabUnit).GetComponent<Unit>();
            unit.unitInfo.team = Team.Player;
            unit.unitInfo.playerType = (PlayerType)i;
            unit.unitInfo.SetInitPlayerStatus(unit.unitInfo.playerType);
            unit.gameObject.name = ((PlayerType)i).ToString();
            SetUI(i,unit.unitInfo);
        }
        leaderManager.SetPlayerLeader();
    }

    
}
