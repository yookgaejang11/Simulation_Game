using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum Team
    {
        /// <summary>
        /// 플레이어
        /// </summary>
        Player,
        /// <summary>
        /// 적
        /// </summary>
        Enemy,
        /// <summary>
        /// 중립
        /// </summary>
        Neutral
    }


    /// <summary>
    /// 플레이어 타입
    /// </summary>
    public enum PlayerType
    {
        /// <summary>
        /// 근거리
        /// </summary>
        Mele,
        /// <summary>
        /// 원거리
        /// </summary>
        Ranged,
        /// <summary>
        /// 마법
        /// </summary>
        Magic,
    }
    /// <summary>
    /// 적 타입
    /// </summary>
    public enum EnemyType
    {
        /// <summary>
        /// 근거리 1단계
        /// </summary>
        mele1,
        /// <summary>
        /// 근거리 2단계
        /// </summary>
        mele2,
        /// <summary>
        /// 근거리 3단계
        /// </summary>
        mele3,
        /// <summary>
        /// 원거리 1단계
        /// </summary>
        range1,
        /// <summary>
        /// 원거리 2단계
        /// </summary>
        range2,
        /// <summary>
        /// 원거리 3단계
        /// </summary>
        range3,
        /// <summary>
        /// 보스 1단계
        /// </summary>
        boss1,
        /// <summary>
        /// 보스 2단계
        /// </summary>
        boss2,
        /// <summary>
        /// 보스 3단계
        /// </summary>
        boss3,
    }
    /// <summary>
    /// 보스 스킬
    /// </summary>
    public enum BossSkill
    {
        /// <summary>
        /// 1단계근거리 몬스터 소환
        /// </summary>
        summonMele1,
        /// <summary>
        /// 2단계 근거리 모스터 소환
        /// </summary>
        summonMele2,
    }

    public enum Boss2Skill
    {
        /// <summary>
        /// 2단계근거리 몬스터 소환
        /// </summary>
        summonMele2,
        /// <summary>
        /// 3단계 근거리 모스터 소환
        /// </summary>
        summonMele3,
        /// <summary>
        /// 2단계 원거리 몬스터 소환
        /// </summary>
        summonRange2,
        /// <summary>
        /// 3단계 원거리 모스터 소환
        /// </summary>
        summonRange3,
    }

    public enum Boss3Skill
    {
        /// <summary>
        /// 3단계 근거리 모스터 소환
        /// </summary>
        summonMele3,
        /// <summary>
        /// 3단계 원거리 모스터 소환
        /// </summary>
        summonRange3,
        /// <summary>
        /// 화면가리기, 3초간 UI 삭제, 중앙에 남은 시간 표기
        /// </summary>
        HideUI,
        
        ChaosScreen
    }
    /// <summary>
    /// 행동
    /// </summary>
    public enum Status
    {
        //이동 따라가기, 이동, 추적, 공격, ㄷ짐
        idle,
        follow,
        MoveTo,
        Chase,
        Attack,
        Dead
    }

    /// <summary>
    /// 근거리 스킬
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
    /// 원거리 스킬
    /// </summary>
    public enum RangeSkill
    {
        //기본, 연속, 멀티, 관통, 광역
        none,
        combo,
        multi,
        anglePiercing,
        aoe
    }

    /// <summary>
    /// 마법스킬
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
    /// 아이템 정보
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
        /// 화려하 전투
        /// </summary>
        FlaashyBattle,
        /// <summary>
        /// 정신집중
        /// </summary>
        MentalFocus,
        /// <summary>
        /// 부활
        /// </summary>
        Revival
    }
    /// <summary>
    /// 디버프
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

