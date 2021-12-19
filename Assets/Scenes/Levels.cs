using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Levels : MonoBehaviour
{
    private Enemy[] enemies;
    private static int levelIndex = 1;
    private void OnEnable()
    {
        enemies = FindObjectsOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var enemy in enemies)
        {
            if(enemy != null)
                return;
        }

        Debug.Log("Level Finished !");
        levelIndex++;
        if(levelIndex > 2)
            SceneManager.LoadScene("Level1");
        var levelName = "Level" + levelIndex;
        SceneManager.LoadScene(levelName);
    }
}
