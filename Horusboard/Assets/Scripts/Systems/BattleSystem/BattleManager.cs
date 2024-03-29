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

    [SerializeField]
    private BoolReference playerAttackAction, playerDefenseAction;
    void Start()
    {
        state = GameStates.START;
        SetupBattle();
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
        
        playerAttackAction.Value = false;
        playerDefenseAction.Value = false;

        state = GameStates.ENEMY_TURN;

    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(2f);
        
        EnemyAttack();

        state = GameStates.PLAYER_TURN;
    }
    void PlayerAttack()
    {
        playerUnit.Attack(enemyUnit);
    }

    void PlayerDefense()
    {
        playerUnit.Defend();
    }

    void EnemyAttack()
    {
        enemyUnit.Attack(playerUnit);
    }
}
