using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    // game objects that are given before runtime
    public GameObject world;
    public GameObject player;
    public GameObject UI_health;
    public GameObject UI_xp;
    public GameObject UI_compass;
    public GameObject UI_inventory;

    // game objects that are created at runtime
    private GameObject map;

    // constants
    public readonly int NUM_LEVELS = 4;
    public readonly Vector3 START_POS = new Vector3(11, 10, 0);
    public readonly int[] XP_TIERS = { 5, 10, 15, 20 };
    public readonly int INVENTORY_SIZE = 8;
    public readonly int POWER_UPS_SIZE = 4;

    // things the manager needs to keep track of
    private Vector3 currentPos;
    public int currentLevel;
    private int currentXp;
    private int currentHealth;
    private int[] currentPowerUps;
    private int[] currentInventory;
    private int currentInsight;
    private bool startFromSave = false;

    // Initialize variables, distribute data, and load resources
    void Awake()
    {
        if (startFromSave)
        {
            // load from save
        }
        else
        {
            // start from beginning
            currentPos = START_POS;
            currentPowerUps = new int[POWER_UPS_SIZE];
            currentHealth = 3;
            currentXp = 0;
            currentInsight = 0;
            currentInventory = new int[INVENTORY_SIZE];

            // not distributed, but tracked here
            currentLevel = 0;
        }

        // distribute variables
        player.SendMessage("SetPlayerPos", currentPos);
        player.SendMessage("SetPowerUps", currentPowerUps);
        UI_health.SendMessage("SetHealth", currentHealth);
        UI_xp.SendMessage("SetXP", currentXp);
        UI_compass.SendMessage("UpdateInsight", currentInsight);
        UI_inventory.SendMessage("SetInventory", currentInventory);
    }

    public void NextLevel()
    {
        // increment to next level
        ++currentLevel;

        if (currentLevel > NUM_LEVELS)
        {
            GameWon();
        }
        else
        {
            player.SendMessage("ChooseUpgrade");
            world.SendMessage("CreateNewBoss");
            currentInsight = 0;
            //UI_compass.SendMessage("UpdateInsight", currentInsight);
        }
    }

    public void IncrementXP(int amount)
    {
        currentXp += amount;
        if (currentXp >= XP_TIERS[currentInsight])
        {
            UI_xp.SendMessage("SetXP", currentXp);
            //UI_compass.SendMessage("UpdateInsight", currentInsight);
        }
    }

    public void UpdateHealth(int amount)
    {
        currentHealth += amount;
        UI_health.SendMessage("SetHealth", currentHealth);
    }

    private void GameWon()
    {
        // do win logic
    }

    private void GameLost()
    {
        // do lose logic
    }
}
