using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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
        
        
    }
}
