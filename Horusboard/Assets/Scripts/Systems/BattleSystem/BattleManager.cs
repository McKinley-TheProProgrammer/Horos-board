using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public enum GameStates
    {
        START,
        PLAYER_TURN,
        ENEMY_TURN,
        WIN,
        LOSE
    }
	
    [SerializeField]
    private GameStates state;

    [SerializeField]
    public List<CardData> cardDatas;
    
    [SerializeField]
    public GameObject playerPrefab;
    [SerializeField]
    public GameObject enemyPrefab;
	
    [SerializeField]
    public Transform playerBattleStation;
    
    [SerializeField]
    public Transform[] enemyBattleStations;

    [SerializeField] 
    public List<RectTransform> cardSlots;
    
    private UnitManager playerUnit, enemyUnit;
    private int enemyAction; // 0 Attacks, 1 Defends, 2 Heal
    
    [SerializeField]
    private BoolReference playerAttackAction, playerDefenseAction;

    [SerializeField] private Sound battleTheme;
    void Awake()
    {
        state = GameStates.START;
        SetupBattle();
    }

    private void Start()
    {
        AudioManager.Instance.Play(battleTheme);
    }
    

    void SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab,playerBattleStation.position,Quaternion.identity);
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStations[Mathf.CeilToInt(enemyBattleStations.Length / 2)].position,Quaternion.identity);

        playerUnit = playerGO.GetComponent<UnitManager>();
        enemyUnit = enemyGO.GetComponent<UnitManager>();

        state = GameStates.PLAYER_TURN;
        StartCoroutine(PlayerTurn());
    }

    void SetupEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            //Sets up the enemies
        }
    }

    void SetupCards()
    {
        for (int i = 0; i < 5; i++)
        {
            //Sets up the Deck for the Player
        }
    }

    IEnumerator PlayerTurn()
    {
        Debug.Log("Choose an action");

        yield return new WaitUntil(() => playerAttackAction.Value || playerDefenseAction.Value);

        if (playerAttackAction.Value)
        {
            PlayerAttack();
        }
        else if (playerDefenseAction.Value)
        {
            PlayerDefense();
        }

        if (playerUnit.isDead)
        {
            state = GameStates.LOSE;
            Debug.Log("Nope, player Dead, u lose");
            yield break;
        }

        if (enemyUnit.isDead)
        {
            state = GameStates.WIN;
            Debug.Log("Imma be damned the game has been wooooun");
            yield break;
        }
        // Set values to true to guarantee that the Player will not Fire an Input twice
        // Put this in a ChangeState function
        playerAttackAction.Value = true;
        playerDefenseAction.Value = true;

        state = GameStates.ENEMY_TURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(2f);
        
        EnemyAttack();

        // put this in a ChangeState function
        state = GameStates.PLAYER_TURN;
        
        playerAttackAction.Value = false;
        playerDefenseAction.Value = false;

        StartCoroutine(PlayerTurn());
    }
    void PlayerAttack()
    {
        playerUnit.Attack(enemyUnit);
    }

    void PlayerDefense()
    {
        playerUnit.Defend(enemyUnit);
    }

    void EnemyAttack()
    {
        enemyUnit.Attack(playerUnit);
    }

    void EnemyDefense()
    {
        enemyUnit.Defend(playerUnit);
    }
}
