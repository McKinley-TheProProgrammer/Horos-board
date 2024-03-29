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

    private UnitManager playerUnit, enemyUnit;

    [SerializeField]
    private BoolReference playerActionMade;
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
        PlayerTurn();
    }

    void SetupEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            
        }
    }

    void PlayerTurn()
    {
        Debug.Log("Choose an action");
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
