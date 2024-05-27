using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class PassiveIncomeBuildingLv1 : MonoBehaviour, IInteractableObject, IBuilding
{
    [Header("Building Price")]
    [SerializeField] private int woodToBuild;
    [SerializeField] private int ironToBuild;
    [SerializeField] private int blueprintsToBuild;

    public int WoodToBuild => woodToBuild;
    public int IronToBuild => ironToBuild;
    public int BlueprintsToBuild => blueprintsToBuild;

    [Header("Building Impact")] 
    [SerializeField] private int passiveIncome = 1;
    [SerializeField] private ParticleSystem particleSystem;

    [Header("For System")] 
    [SerializeField] private MainClicker mainClicker;
    [SerializeField] private ResourceBank resourceBank;
    [SerializeField] private GameObject notification; // Notification of no money
    [SerializeField] private SaveLoadSystem saveLoadSystem;
    private MeshRenderer _buildMeshRenderer;

    private static PassiveIncomeBuildingLv1 _instance; // ??? how to make not uninteractble

    private void Start()
    {
        _buildMeshRenderer = GetComponent<MeshRenderer>();
        _instance = GetComponent<PassiveIncomeBuildingLv1>();
    }

    #region IInteractableObject interface

    public void Interact()
    {
        if (PossibleToBuy()) 
        {
            mainClicker.SetPassiveIncome(passiveIncome);
            CreateBoom();
            _buildMeshRenderer.enabled = true;
            DisableIBuilding();
            saveLoadSystem.AddBuilding(gameObject);
        }
        else
        {
            ShowNotification();
        }
    }

    public string GetDescription()
    {
        return $"Постройка стоит {woodToBuild} дерева, {ironToBuild} железа, {blueprintsToBuild} чертежей";
    }
    

    #endregion

    #region PurchaseLogic

    private bool PossibleToBuy()
    {
        if (Checkout() && !_buildMeshRenderer.enabled)
        {
            return true;
        }

        return false;
    }

    public void MakeUninteractble()  // ??? how to make not uninteractble
    {
        
    }

    public static void DisableIBuilding()  // ??? how to make not uninteractble
    {
        _instance.enabled = false;
    }
    
    #endregion


    #region ParticleEffect creation

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

    #endregion

    #region Show No Money Note 

    private void ShowNotification()
    {
        StartCoroutine(ShowNotificationCoroutine());
    }
    
    private IEnumerator ShowNotificationCoroutine()
    {
        notification.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        notification.gameObject.SetActive(false);
    }

    #endregion

    private bool Checkout()
    {
        var currentWood = resourceBank.GetWood();
        var currentIron = resourceBank.GetIron();
        var currentBlueprints = resourceBank.GetBlueprints();

        if (currentWood >= woodToBuild && currentIron >= ironToBuild && currentBlueprints >= blueprintsToBuild)
        {
            resourceBank.SetWood(-woodToBuild);
            resourceBank.SetIron(-ironToBuild);
            resourceBank.SetBlueprints(-blueprintsToBuild);

            return true;
        }

        return false;
    }
}