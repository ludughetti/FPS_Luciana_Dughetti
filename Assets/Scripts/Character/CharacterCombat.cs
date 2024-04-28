using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField] private LayerMask target;
    [SerializeField] private Vector3 offset;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public void Shoot()
    {
        RaycastHit hit;

        Vector3 sourcePosition = transform.position + offset;

        if(Physics.Raycast(sourcePosition, transform.forward, out hit, Mathf.Infinity, target)) 
        {
            Debug.DrawRay(sourcePosition, transform.forward * hit.distance, Color.yellow, 2);
            Debug.Log("Hit target");
        } 
        else
        {
            Debug.DrawRay(sourcePosition, transform.forward * 1000, Color.white, 2);
            Debug.Log("Did not hit target");
        }
    }
}
