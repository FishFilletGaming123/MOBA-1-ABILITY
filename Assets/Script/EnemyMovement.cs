using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform targetPoint;
    public GameObject frozenBlock;
    [SerializeField] private float currentMoveSpeed = 4f;
    [SerializeField] private float originalMoveSpeed = 4f;
    private bool isInFrost = false;
    private bool isFrozen = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (!isFrozen)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, currentMoveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Frost"))
        {
            isInFrost = true;
            if (!isFrozen)
            {
                StartCoroutine(FrostEffect());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Frost"))
        {
            isInFrost = false;
            StopCoroutine(FrostEffect());
            currentMoveSpeed = originalMoveSpeed;
        }
    }

    IEnumerator FrostEffect()
    {
        currentMoveSpeed = 2f;
        yield return new WaitForSeconds(3f);
        
        //this part here is when the enemy stays in the spell circle for too long 
        //then they will be stunned

        if (isInFrost)
        {
            Instantiate(frozenBlock, transform.position, Quaternion.identity);
            currentMoveSpeed = 0f;       
            yield return new WaitForSeconds(3f);         
            currentMoveSpeed = originalMoveSpeed;        
        }
        else
        {
          currentMoveSpeed = originalMoveSpeed;
          isFrozen = false;
        }
    }
}
