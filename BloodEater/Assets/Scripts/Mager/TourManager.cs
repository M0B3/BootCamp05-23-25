using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class TourManager : MonoBehaviour
{
    private bool hasPlayed = false;
    public bool EndGame = false;
    public bool actualPlayer = false;
    public Stack<bool> barrel = new Stack<bool>();
    public List<Player> players;
    public int nbReload = 0;
    
    private static TourManager instance = null;
    public static TourManager Instance => instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
		
        // Initialisation du Game Manager...
    }
    
    private void Start()
    { 
       players = new List<Player>();
       players.Add(new Player());
       players.Add(new Player());

       realod_shootgun();
    }
    private void Update()
    {
        

        if (!EndGame)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Joueur "+ actualPlayer +" a joué contre Joueur "+ !actualPlayer +" nb balle restant "+ barrel.Count);
                shoot(true);
                
            }

            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                Debug.Log("Joueur "+ actualPlayer +" a joué contre lui  nb balle restant "+ barrel.Count);
                shoot(false);
                
            }
            
        }
            
    }

    public void realod_shootgun()
    {
        nbReload++;
        
        switch (nbReload)
        {
            case 1:
                MakeReload(3, 1);
                break;
            case 2:
                MakeReload(7,2);
                break;
            case 3:
                MakeReload(4,3);
                break;
            case 4:
                MakeReload(11,4);
                break;
            default: 
                MakeReload(1,4);
                break;
        }
        
        Debug.Log("Recharge");
    }

    private void MakeReload(int maxBullet, int maxBlackBullet)
    {
        List<bool> bullets = new List<bool>();
        for (int i = 0; i < maxBullet; i++)
        {
            bullets.Add(false);
        }
        
        int blackBullet = 0;

        while (blackBullet < maxBlackBullet)
        {
            int index = Random.Range(0, maxBullet);
            if (bullets[index].Equals(false))
            {
                bullets[index] = true;
                blackBullet++;
            }
        }

        foreach (var bullet in bullets)
        {
            barrel.Push(bullet);
        }
        
    }
    
    
    public void realod_canon_shootgun()
    {
        
    }

    
    public void TurnEnd()
    {
        actualPlayer = !actualPlayer;
        Debug.Log("Vous préparez votre tir ");
    }

    public void shoot(bool IsEnemy)
    {
        if (!barrel.Peek() && IsEnemy)
        {
            Debug.Log("balle a blanc sur ennemi");
            Debug.Log("Le canon ne vous appartient plus ");
            barrel.Pop();
           // mettre à jour le canon
           
           TurnEnd();
           if (barrel.Count == 0)
           {
               realod_shootgun();
           }
           
           Debug.Log("nombre de balle restant "+ barrel.Count);
           
           return;
        }else if(!barrel.Peek())
            Debug.Log("balle a blanc sur soi");
        
        
        if (barrel.Count != 0 && barrel.Peek())
        {
            
            barrel.Pop();
            
            if (barrel.Count == 0)
            {
                realod_shootgun();
            }
            // mettre à jour le canon
            
            
            if (!IsEnemy)
            {
                players[actualPlayer ? 1 : 0].TakeDamage(1);
                Debug.Log(actualPlayer ? 1 : 0 + " a pris un coup est a " + players[actualPlayer ? 1 : 0].currentHealth +" points de vie");
                TurnEnd();
                
            }
            else
            {
                players[!actualPlayer ? 1 : 0].TakeDamage(1);
                Debug.Log(!actualPlayer + " a pris un coup est a " + players[!actualPlayer ? 1 : 0].currentHealth +" points de vie");
            }
        }
        
        Debug.Log("nombre de balle restant "+ barrel.Count);

    }
}
