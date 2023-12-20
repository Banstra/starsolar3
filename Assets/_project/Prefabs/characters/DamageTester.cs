using UnityEngine;

public class DamageTester : MonoBehaviour
{

    // Update is called once per frame
    public void interacting()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 21f);
            Debug.Log("the V button is pressed");
            foreach (Collider collider in colliders)
            {
                Debug.Log(collider);
                Debug.Log("there IS a collider");
            }
        }
    }
}
