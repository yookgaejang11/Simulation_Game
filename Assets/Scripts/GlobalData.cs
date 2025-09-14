using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum Team
    {
        /// <summary>
        /// �÷��̾�
        /// </summary>
        Player,
        /// <summary>
        /// ��
        /// </summary>
        Enemy,
        /// <summary>
        /// �߸�
        /// </summary>
        Neutral
    }


    /// <summary>
    /// �÷��̾� Ÿ��
    /// </summary>
    public enum PlayerType
    {
        /// <summary>
        /// �ٰŸ�
        /// </summary>
        Mele,
        /// <summary>
        /// ���Ÿ�
        /// </summary>
        Ranged,
        /// <summary>
        /// ����
        /// </summary>
        Magic,
    }
    /// <summary>
    /// �� Ÿ��
    /// </summary>
    public enum EnemyType
    {
        /// <summary>
        /// �ٰŸ� 1�ܰ�
        /// </summary>
        mele1,
        /// <summary>
        /// �ٰŸ� 2�ܰ�
        /// </summary>
        mele2,
        /// <summary>
        /// �ٰŸ� 3�ܰ�
        /// </summary>
        mele3,
        /// <summary>
        /// ���Ÿ� 1�ܰ�
        /// </summary>
        range1,
        /// <summary>
        /// ���Ÿ� 2�ܰ�
        /// </summary>
        range2,
        /// <summary>
        /// ���Ÿ� 3�ܰ�
        /// </summary>
        range3,
        /// <summary>
        /// ���� 1�ܰ�
        /// </summary>
        boss1,
        /// <summary>
        /// ���� 2�ܰ�
        /// </summary>
        boss2,
        /// <summary>
        /// ���� 3�ܰ�
        /// </summary>
        boss3,
    }
    /// <summary>
    /// ���� ��ų
    /// </summary>
    public enum BossSkill
    {
        /// <summary>
        /// 1�ܰ�ٰŸ� ���� ��ȯ
        /// </summary>
        summonMele1,
        /// <summary>
        /// 2�ܰ� �ٰŸ� ���� ��ȯ
        /// </summary>
        summonMele2,
    }

    public enum Boss2Skill
    {
        /// <summary>
        /// 2�ܰ�ٰŸ� ���� ��ȯ
        /// </summary>
        summonMele2,
        /// <summary>
        /// 3�ܰ� �ٰŸ� ���� ��ȯ
        /// </summary>
        summonMele3,
        /// <summary>
        /// 2�ܰ� ���Ÿ� ���� ��ȯ
        /// </summary>
        summonRange2,
        /// <summary>
        /// 3�ܰ� ���Ÿ� ���� ��ȯ
        /// </summary>
        summonRange3,
    }

    public enum Boss3Skill
    {
        /// <summary>
        /// 3�ܰ� �ٰŸ� ���� ��ȯ
        /// </summary>
        summonMele3,
        /// <summary>
        /// 3�ܰ� ���Ÿ� ���� ��ȯ
        /// </summary>
        summonRange3,
        /// <summary>
        /// ȭ�鰡����, 3�ʰ� UI ����, �߾ӿ� ���� �ð� ǥ��
        /// </summary>
        HideUI,
        
        ChaosScreen
    }
    /// <summary>
    /// �ൿ
    /// </summary>
    public enum Status
    {
        //�̵� ���󰡱�, �̵�, ����, ����, ����
        idle,
        follow,
        MoveTo,
        Chase,
        Attack,
        Dead
    }

    /// <summary>
    /// �ٰŸ� ��ų
    /// </summary>
    public enum MeleSkill
    {
        none,
        mele,
        multi,
        piercing,
        stun
    }
    /// <summary>
    /// ���Ÿ� ��ų
    /// </summary>
    public enum RangeSkill
    {
        //�⺻, ����, ��Ƽ, ����, ����
        none,
        combo,
        multi,
        anglePiercing,
        aoe
    }

    /// <summary>
    /// ������ų
    /// </summary>
    public enum MagicSkill
    {
        none,
        combo,
        chain,
        heal,
        posion
    }


    public enum CommonSkill
    {
        criticalRateUp,
        attackSpeedUp,
        HPUP,
        moveSpeedUP,
        attackDamageUP
    }
    /// <summary>
    /// ������ ����
    /// </summary>
    public enum ItemName
    {
        none,
        Hp1,
        Hp2,
        Hp3,
        Mp1,
        Mp2,
        Mp3,
        /// <summary>
        /// ȭ���� ����
        /// </summary>
        FlaashyBattle,
        /// <summary>
        /// ��������
        /// </summary>
        MentalFocus,
        /// <summary>
        /// ��Ȱ
        /// </summary>
        Revival
    }
    /// <summary>
    /// �����
    /// </summary>
    public enum Debuf
    {
        none,
        stun,
        posion
    }

    [Serializable]
    public class PotionInfo
    {
        public int[] Amount = new int[] { 10, 30, 50 };
        public float Cool = 2;
    }

