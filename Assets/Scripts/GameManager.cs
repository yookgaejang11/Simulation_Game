using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefabUnit;
    public LeaderManager leaderManager;
    public List<Unit> enemys = new List<Unit>();
    public int enemyLv;
    public Transform[] Board;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerTeam()
    {
        for(int i = 0; i < 3; i++)
        {
            Unit unit = Instantiate(prefabUnit).GetComponent<Unit>();
            unit.unitInfo.team = Team.Player;
            unit.unitInfo.playerType = (PlayerType)i;
            //unit.unitInfo.SetInitPlayerStatus(unit.unitInfo.playerType);
            unit.gameObject.name = ((PlayerType)i).ToString();
            //SetUI(i,unit.unitInfo);
        }
    }

    
}
