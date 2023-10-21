using UnityEngine;

public class UnitDistance : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "unit")
        {
            Debug.Log("enter");
        }
    }
}
