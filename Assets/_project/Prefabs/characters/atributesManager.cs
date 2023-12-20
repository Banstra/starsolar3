using UnityEngine;

public class statsPlayer : MonoBehaviour
{
    public statsPlayer playerAtm;
    public statsPlayer enemyAtm;
    public int health;
    public int attack;
    private bool inside = false;

    // Start is called before the first frame update
    public void TakeDamage(int amount)
    {
        health -= amount;
        //Debug.Log(health);

    }

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<statsPlayer>();
        // Debug.Log(atm);
        if (atm != null)
        {
            if (inside)
            {
                atm.TakeDamage(attack);
                // Debug.Log("it should work");
            }
            // Debug.Log("atm != null");

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("they see each other");
        inside = true;
        enemyAtm.DealDamage(playerAtm.gameObject);

    }

    private void OnTriggerExit(Collider other)
    {
        inside = false;
        // Debug.Log("Exit");
        // Debug.Log(inside);
    }

}
