using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    public Vector3 collison = Vector3.zero;
    public GameObject lastHit;
    public Transform playerCam;
    public LayerMask whatIsInteractable;
    public float distance;

    [Header("UI Elements")]
    public Image pointer;

    private void Update()
    {
        Ray _ray = new(transform.position, transform.forward);
        if (Physics.Raycast(_ray, out RaycastHit _hit, distance, whatIsInteractable))
        {
            lastHit = _hit.transform.gameObject;
            collison = _hit.point;
            pointer.color = Color.white;
            if(Input.GetMouseButtonDown(0))
            {
                Interaction.Instance.Interact(lastHit.GetComponent<InteractionData>());
            }
        }
        else
        {
            pointer.color = Color.black;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(collison, 0.2f);
    }
}
