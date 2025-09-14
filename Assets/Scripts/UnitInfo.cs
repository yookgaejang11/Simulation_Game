using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInfo : MonoBehaviour
{
    /// <summary>
    /// �ٰŸ� ���Ÿ� ����
    /// </summary>
    public int[] LvUpStatusHp = new int[] { 20, 15, 10 };
    /// <summary>
    /// �ٰŸ� ���Ÿ� ����
    /// </summary>
    public int[] LvUPStatusDamage = new int[] { 10, 8, 10 };
    /// <summary>
    /// ���� ��ų ����
    /// </summary>
    public int[] skillLev = new int[] { 0, 0, 0, 0 };
    /// <summary>
    /// ���뽺ų ����
    /// </summary>
    public int[]commonSkillLev = new int[] {0,0,0,0,0 };
    /// <summary>
    /// ũ��Ƽ�� �з� ����
    /// </summary>
    public int[] commonSkill1 = new int[] { 0, 10, 20, 30, 40, 50 };
    /// <summary>
    /// ���� �ӵ� ����
    /// </summary>
    public float[] commonSkill2 = new float[] { 0f, 0.5f, 1.0f, 1.5f, 2.0f, 3.0f };
    /// <summary>
    /// ü�� ����
    /// </summary>
    public int[] commonSkill3 = new int[] { 0, 200, 400, 600, 800, 1000 };
    /// <summary>
    /// �̵��ӵ� ����
    /// </summary>
    public float[] commonSkill4 = new float[] { 0f, 0.5f, 1.0f, 1.2f, 1.5f, 2.0f };
    /// <summary>
    /// ���ݷ� ����
    /// </summary>
    public int[] commonSkill5 = new int[] { 0, 20, 40, 60, 80, 100 };

    public Vector3[] formOffset = new Vector3[]
    {
        new Vector3(2.0f, 0, 2.0f),
        new Vector3(-2.0f, 0, 2.0f),
        new Vector3(-2.0f, 0, -2.0f),
    };


    public Status status;
    public Team team;
    public PlayerType playerType;

    public int maxLv = 20;
    public int curLv = 0;
    public float baseHp = 100f;
    public float maxHp = 100f;
    public float curHp = 100f;
    public float MaxMp = 50f;
    public float curMp = 50f;
    public float moveSpeed = 4.5f;
    public float criticalRate = 10f;
    public float turnSpeed = 720f;
    public float baseAttackDamage = 1f;
    public float attackDamage = 1f;
    public float attackRate = 1.0f;
    public float attackRange = 1.4f;
    public float detectRadius = 8f;
    public float healDamage = 10f;
    public float arriveRadius = 0.6f;
    public float friendlyRadius = 1.5f; //�Ʊ� ����
    public float separationWeight = 4f; // separation �� ����ġ
    public float cohesionWeight = 1.0f; //���� Cohesion ����ġ
    public float alignmentWeight = 0.5f; // ���� alignment ����ġ
    public float exp = 0;


    public float GetExp(float damage)
    {
        if(damage > curHp)
        {
            return exp * curHp / maxHp;
        }
        return exp * damage / maxHp;
    }

    public float RequireExp()
    {
        return 100f * curLv;
    }

    public float GetBonusExp()
    {
        return exp / 10;
    }

    public void SetInitPlayerStatus(PlayerType _type)
    {
        playerType = _type;

        switch(playerType)
        {
            case PlayerType.Mele:
                baseHp = 100;
                maxHp = baseHp;
                curHp = maxHp;
                MaxMp = 50;
                curMp = MaxMp;
                baseAttackDamage = 20;
                attackDamage = baseAttackDamage;
                attackRange = 1.0f;
                criticalRate = 0.1f;
                break;
            case PlayerType.Ranged:
                baseHp = 80;
                maxHp = baseHp;
                curHp = maxHp;
                MaxMp = 70;
                curMp = MaxMp;
                baseAttackDamage = 15;
                attackDamage = baseAttackDamage;
                attackRange = 3.0f;
                criticalRate = 0.2f;
                break;
            case PlayerType.Magic:
                baseHp = 70;
                maxHp = baseHp;
                curHp = maxHp;
                MaxMp = 150;
                curMp = MaxMp;
                baseAttackDamage = 10;
                attackDamage = baseAttackDamage;
                attackRange = 3.0f;
                criticalRate = 0f;
                break;
        }
        maxHp = baseHp + (curLv * LvUPStatusDamage[(int)_type]);
        curHp = maxHp;
        curMp = MaxMp;
        attackDamage = baseAttackDamage + (curLv * LvUPStatusDamage[(int)_type]);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
