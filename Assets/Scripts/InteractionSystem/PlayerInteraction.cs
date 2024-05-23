using UnityEngine;
using TMPro;

public interface IInteractableObject
{
    void Interact();
    string GetDescription();
}

public interface IBuilding
{
    int WoodToBuild { get; }
    int IronToBuild { get; }
    int BlueprintsToBuild { get; }
}

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private float interactionDistance = 5f;

    [SerializeField] private GameObject interactionUI;
    [SerializeField] private TextMeshProUGUI interactionText;

    private void Update()
    {
        InteractionRay();
    }

    void InteractionRay()
    {
        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit[] hits = Physics.RaycastAll(ray, interactionDistance);

        bool hitSomething = false;
        float closestDistance = Mathf.Infinity;
        IInteractableObject closestObject = null;

        foreach (RaycastHit hit in hits)
        {
            IInteractableObject interactableObject = hit.collider.GetComponent<IInteractableObject>();

            if (interactableObject != null)
            {
                float distance = Vector3.Distance(transform.position, hit.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestObject = interactableObject;
                }

                hitSomething = true;
            }
        }

        if (closestObject != null)
        {
            interactionText.text = closestObject.GetDescription();

            if (Input.GetKeyDown(KeyCode.E))
            {
                closestObject.Interact();
            }
        }

        interactionUI.SetActive(hitSomething);
    }
}