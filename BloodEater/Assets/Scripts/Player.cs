using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public int MaxHealth = 4;
   public int currentHealth = 4;
  //public List<Item> Inventory = new List<Item>();


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    public void UseItem(int index)
    {

    }
   
  
    /**public void AddItem(Item item)
    {
        
    }

    public void RemoveItem(int index)
    {
        
    }
    **/
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > MaxHealth)
        {
            currentHealth = MaxHealth;
        }
    }
    
    public void Die()
    {
        Debug.Log("Vous êtes mort");
        TourManager.Instance.EndGame = true;
    }
    
    
    
    
}
