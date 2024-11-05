using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeSystem : MonoBehaviour
{
    private int currenthealth;
    private int maxhealth = 5;

    [Header("Ui Settings")]
    public Image[] Hearts;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    
     public void TakeDamage(int Damage)
    {
        currenthealth -= Damage;
        UpdateHealth();
        if(currenthealth < 0)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        Debug.Log("Game_Over");
    }
    void UpdateHealth()
    {
        if(currenthealth >= 0 && currenthealth < Hearts.Length)
        {
            Destroy(Hearts[currenthealth]);
            Hearts[currenthealth] = null;
        }
    }
}
