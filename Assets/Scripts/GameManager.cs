using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    void Update()
    {
        KeyboardClicks();
        if(EnemyKilled())
        {
            AchievementManager.instance.addValue(PropertiesName.killedEnemies, 1);
        }
    }

    void KeyboardClicks()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            AchievementManager.instance.addValue(PropertiesName.clickQ, 1);

        if (Input.GetKeyDown(KeyCode.W))
            AchievementManager.instance.addValue(PropertiesName.clickW, 1);

        if (Input.GetKeyDown(KeyCode.E))
            AchievementManager.instance.addValue(PropertiesName.clickE, 1);

        if (Input.GetKeyDown(KeyCode.R))
            AchievementManager.instance.addValue(PropertiesName.clickR, 1);

        if (Input.GetKeyDown(KeyCode.T))
            AchievementManager.instance.addValue(PropertiesName.clickT, 1);

        if (Input.GetKeyDown(KeyCode.Y))
            AchievementManager.instance.addValue(PropertiesName.clickY, 1);

        if (Input.GetKeyDown(KeyCode.B))
            AchievementManager.instance.addValue(PropertiesName.clickB, 1);

        if (Input.GetKeyDown(KeyCode.O))
            AchievementManager.instance.addValue(PropertiesName.clickO, 1);

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Checking if achievements properties are active");
            AchievementManager.instance.checkAchievementsAndDumbThem();
        }
    }

    void OnApplicationQuit()
    {
        //saving properties...        
        AchievementManager.instance.resetProperties();
        // just for presentation purpose we reset our achievs
        AchievementManager.instance.resetAchievements();
    }

    public bool EnemyKilled()
    {
        bool aRet = false;
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("enemey killed");
            aRet = true;
        }

        return aRet;
    }

}
