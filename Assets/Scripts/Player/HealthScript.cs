using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    private int maxHealth = 3;
    public int currentHealth = 3;

    public Image Health1;
    public Image Health2;
    public Image Health3;

    public Sprite FullHeartImage;
    public Sprite EmptyHeartImage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth >= 3)
            Health3.sprite = FullHeartImage;
        else
            Health3.sprite = EmptyHeartImage;
        if (currentHealth >= 2)
            Health2.sprite = FullHeartImage;
        else
            Health2.sprite = EmptyHeartImage;
        if (currentHealth >= 1)
            Health1.sprite = FullHeartImage;
        else
            Health1.sprite = EmptyHeartImage;
    }
}
