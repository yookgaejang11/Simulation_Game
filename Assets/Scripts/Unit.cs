using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    [SerializeField]
    public UnitInfo unitInfo;
    
    public Transform Leader; //리더 위치
    public Vector3 formOffset; //리더 따라다닐 위치
    public Vector3 DesiredVelocity; //목표위치
    public float attTimer;
    public Transform currentTarget;
    public List<Unit> tempTeam = new List<Unit>(20);
    public NavMeshAgent navMeshAgent;
    GameManager gameManager;
    public GameObject[] effectPrefab;
    public float[] skillCoolDown = new float[] { 0, 0, 0, 0, 0 };
    public Debuf debuf = Debuf.none;
    public float stunTimer = 2.0f;
    public float stunTiming;
    PotionInfo potionInfo = new PotionInfo();

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); //nav랑 charcterController는서로 충돌이 안되서 조종하는 Player도 nav를 가져야디ㅗㅁ
        unitInfo = GetComponent<UnitInfo>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void FixedUpdate()
    {
        if(Leader == null)
        {
            return;
        }
        if(navMeshAgent == null)
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            return;
        }
        if(DesiredVelocity.sqrMagnitude > 0.01f)
        {
            navMeshAgent.isStopped = false;
            
            navMeshAgent.SetDestination(DesiredVelocity);
        }
        else
        {
            
            navMeshAgent.isStopped = true;
        }
    }


   
    // Update is called once per frame
    void Update()
    {
        if(debuf == Debuf.stun)
        {
            stunTiming -= Time.deltaTime;
            if(stunTiming > 0)
            {
                return;
            }
            else
            {
                stunTiming = stunTimer;
                debuf = Debuf.none; 
            }
        }
        if(unitInfo.status == Status.Dead)
        {
            return ;
        }
        //현재 타겟이 없다면 새로운 타겟 검색
        if(currentTarget == null || IsValidTarget(currentTarget))
        {
            currentTarget = misDistanceTarget();
        }

        if(currentTarget != null)
        {
            //거리가 사거리에 들어왔는지 확인
            float dist = Vector3.Distance(transform.position, currentTarget.position);
            if(dist <= unitInfo.attackRange)
            {
                unitInfo.status = Status.Attack;
            }
            else
            {
                unitInfo.status = Status.Chase;
            }
        }
        else
        {
            if(Leader != null)
            {
                unitInfo.status = Status.follow;
            }
            else
            {
                unitInfo.status = Status.idle;
            }
        }

        switch (unitInfo.status)
        {
            case Status.Attack:
                DesiredVelocity = Vector3.zero;
                Attack(currentTarget);

                break;
            case Status.Chase:
                Vector3 dir = currentTarget.position - transform.position;
                dir.y = 0;

                if(dir.sqrMagnitude < 0.1f)
                {
                    DesiredVelocity = Vector3.zero;
                }
                else
                {
                    DesiredVelocity = currentTarget.position;
                }
                break;
            case Status.follow:
                Vector3 target = Leader.position + formOffset;

                //target += AvoidTeam();
                DesiredVelocity = target;
                break;
        }
        


    }


    void Attack(Transform target)
    {
        
        attTimer -= Time.deltaTime;

        if(attTimer > 0)
        {
            return;
        }
        if(target == null)
        {
            return;
        }
        if(!IsValidTarget(target))
        {
            return;
        }
        Unit targetUnit = target.GetComponent<Unit>();
        if(unitInfo.team == Team.Player)
        {
            /*GameObject effect = Instantiate(effectPrefab[(int)unitInfo.playerType],
                target.transform.position + new Vector3(0, 1.0f, 0),
                effectPrefab[(int)unitInfo.playerType].transform.rotation);*/
            if(unitInfo.playerType == PlayerType.Ranged)
            {

            }
            if(targetUnit.unitInfo.curHp - unitInfo.attackDamage > 0)
            {
                unitInfo.exp += targetUnit.unitInfo.GetExp(unitInfo.attackDamage);
            }
            else
            {
                unitInfo.exp += targetUnit.unitInfo.GetExp(unitInfo.attackDamage);
                unitInfo.exp += targetUnit.unitInfo.GetBonusExp();
            }
            LvUP();
        }
        targetUnit.Damage(unitInfo.attackDamage);
        attTimer = unitInfo.attackRate;

    }

    

    public void LvUP()
    {
        if(unitInfo.exp > unitInfo.RequireExp())
        {
            unitInfo.exp -= unitInfo.RequireExp();
            unitInfo.curLv++;
            unitInfo.SetInitPlayerStatus(unitInfo.playerType);

            gameManager.SetUI((int)unitInfo.playerType, unitInfo);
            if(unitInfo.curLv % 2 ==1)
            {
                Time.timeScale = 0;
                gameManager.SetSkillUI((int)unitInfo.playerType,unitInfo);
            }
        }
        gameManager.SetUI((int)unitInfo.playerType, unitInfo);
    }

    public void Damage(float damage)
    {
        if(unitInfo.curHp <= 0f)
        {
            return ;
        }
        unitInfo.curHp -=damage;

        if(unitInfo.curHp <= 0f)
        {
            unitInfo.curHp = 0f;
            GameObject manager = GameObject.Find("Manager");
            LeaderManager leaderManager = manager.GetComponent<LeaderManager>();
            GameManager gameManager = manager.GetComponent<GameManager>();
            if(leaderManager.currentLeader == this)
            {
                leaderManager.units.Remove(this);
                leaderManager.currentLeaderIndex = 0;
                leaderManager.ChangePlayerLeader(0);
                //gameManager.SetEnemyLeader();
            }
            else
            {
                leaderManager.units.Remove(this);
                gameManager.enemys.Remove(this);
            }
            if(unitInfo.team == Team.Enemy)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }


    bool IsValidTarget(Transform tr)
    {
        if(tr == null)
        {
            return false;
        }
        Unit unit = tr.GetComponent<Unit>();

        if(unit == null)
        {
            return false;
        }
        if(unit.unitInfo.curHp <= 01)
        {
            return false;
        }

        if(unit.unitInfo.team == this.unitInfo.team)
        {
            return false;
        }
        return true;
    }

    Transform misDistanceTarget()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, unitInfo.detectRadius, LayerMask.GetMask("Unit"));
        //타겟 선정
        Transform choice = null;

        float bestSqr = float.MaxValue;
        for(int i = 0; i < col.Length; i++)
        {
            Unit unit = col[i].GetComponent<Unit>();
            //유닛이 아닌지, 아군인지 확인
            if(unit == null || unit.unitInfo.team == this.unitInfo.team)
            {
                continue;
            }
            //magnitude => sqrMagnitude : 제곱근 사용하지 않음, 비교 연산이라 제곱근 없는거리
            float sq = (unit.transform.position - transform.position).sqrMagnitude;
            float distance = Vector3.Distance(unit.transform.position, transform.position);
            if(sq < bestSqr)
            {
                bestSqr = sq;
                choice = unit.transform;
            }

        }
        return choice;

    }
}
