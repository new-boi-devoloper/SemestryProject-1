using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class PassiveIncomeBuildingLv1 : MonoBehaviour, IInteractableObject, IBuilding
{
    [Header("Building Price")] [SerializeField]
    private int woodToBuild;

    [SerializeField] private int ironToBuild;
    [SerializeField] private int blueprintsToBuild;

    public int WoodToBuild => woodToBuild;
    public int IronToBuild => ironToBuild;
    public int BlueprintsToBuild => blueprintsToBuild;

    [Header("Building Impact")] [SerializeField]
    private int passiveIncome = 1;

    [SerializeField] private ParticleSystem particleSystem;

    [Header("For System")] [SerializeField]
    private MainClicker mainClicker;

    [SerializeField] private ResourceBank resourceBank;

    public void Interact()
    {
        mainClicker.SetPassiveIncome(passiveIncome);
        CreateBoom();
        Checkout();
    }

    public string GetDescription()
    {
        return $"Постройка стоит {woodToBuild} дерева, {ironToBuild} железа, {blueprintsToBuild} чертежей";
    }

    private async Task CreateBoom()
    {
        StartCoroutine(CreateBoomCoroutine());
    }

    private IEnumerator CreateBoomCoroutine()
    {
        var spawnedEffect = Instantiate(particleSystem, transform.position, transform.rotation);
        yield return new WaitForSeconds(3);
        Destroy(spawnedEffect.gameObject);
    }

    private void Checkout()
    {
        var currentWood = resourceBank.GetWood();
        var currentIron = resourceBank.GetIron();
        var currentBlueprints = resourceBank.GetBlueprints();

        if (currentWood >= WoodToBuild && currentIron >= IronToBuild && currentBlueprints >= BlueprintsToBuild)
        {
            resourceBank.SetWood(-WoodToBuild);
            resourceBank.SetIron(-IronToBuild);
            resourceBank.SetBlueprints(-BlueprintsToBuild);
        }
    }
}