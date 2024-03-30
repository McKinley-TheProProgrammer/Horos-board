using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
    public TextMeshProUGUI stateDisplayText;
    
    [SerializeField] 
    private string winText, loseText;
    [SerializeField] 
    private TextMeshProUGUI endTextDisplay;
    [SerializeField] 
    private UIMoveToEffect endGameUI;
    
    [SerializeField]
    public List<CardData> cardDatas;

    [SerializeField] 
    public UIMoveToEffect cardDeckGroup;
    
    [SerializeField]
    public GameObject playerPrefab;
    [SerializeField]
    public GameObject enemyPrefab;
	
    [SerializeField]
    public Transform playerBattleStation;
    [SerializeField]
    public Transform[] enemyBattleStations;
    
    private UnitManager playerUnit, enemyUnit;
    private int enemyAction; // 0 Attacks, 1 Defends, 2 Heal
    
    [SerializeField]
    private BoolReference playerAttackAction, playerDefenseAction;
    
    
    [SerializeField] 
    private Sound battleTheme;
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

        stateDisplayText.text = "É a sua vez";
        cardDeckGroup.MoveBack();
        
        yield return new WaitUntil(() => !playerAttackAction.Value || !playerDefenseAction.Value);

        if (!playerAttackAction.Value)
        {
            PlayerAttack();
        }
        else if (!playerDefenseAction.Value)
        {
            PlayerDefense();
        }

        if (playerUnit.isDead)
        {
            Debug.Log("Nope, player Dead, u lose");
            
            state = GameStates.LOSE;
            endTextDisplay.text = loseText;
            endGameUI.MoveToCenter();
            yield break;
        }

        if (enemyUnit.isDead)
        {
            Debug.Log("Imma be damned the game has been wooooun");
            
            state = GameStates.WIN;
            endTextDisplay.text = winText;
            endGameUI.MoveToCenter();
            yield break;
        }
        // Set values to true to guarantee that the Player will not Fire an Input twice
        // Put this in a ChangeState function
        playerAttackAction.Value = false;
        playerDefenseAction.Value = false;

        state = GameStates.ENEMY_TURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        stateDisplayText.text = "É a vez de Gaia";
        yield return new WaitForSeconds(2f);

        enemyAction = Random.Range(0, 2);
        switch (enemyAction)
        {
            case 0:
                EnemyAttack();
                break;
            case 1:
                EnemyDefense();
                break;
            default:
                EnemyAttack();
                break;
        }
        

        // put this in a ChangeState function
        state = GameStates.PLAYER_TURN;
        
        playerAttackAction.Value = true;
        playerDefenseAction.Value = true;

        StartCoroutine(PlayerTurn());
    }
    void PlayerAttack()
    {
        stateDisplayText.text = "Voce atacou a Gaia";
        playerUnit.Attack(enemyUnit);
    }

    void PlayerDefense()
    {
        playerUnit.Defend(enemyUnit);
    }

    void EnemyAttack()
    {
        // Makes the Enemy win more Attack points each round
        enemyUnit.AddDamage(Random.Range(1,2));
        stateDisplayText.text = "Gaia Atacou";
        enemyUnit.Attack(playerUnit);
    }

    void EnemyDefense()
    {
        enemyUnit.LoseDefense(-Random.Range(1,5));
        stateDisplayText.text = "Gaia decidiu se defender do proximo ataque";
        enemyUnit.Defend(playerUnit);
    }
}
