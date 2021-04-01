using Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupComponent : MonoBehaviour
{
    [SerializeField] ItemScriptables PickupItem;


    [SerializeField] private int Amount = -1;

    [SerializeField]private MeshRenderer PropMeshRenderer;
    [SerializeField]private MeshFilter PropMeshFilter;

    private ItemScriptables ItemInstance;
    void Awake()
    {
        if (PropMeshRenderer == null) GetComponentInChildren<MeshRenderer>();
        if (PropMeshFilter == null) GetComponentInChildren<MeshFilter>();

        Instantiate();
        
    }

    public void Instantiate()
    {
        ItemInstance = Instantiate(PickupItem);
        if (Amount > 0) ItemInstance.SetAmount(Amount);
        ApplyMesh();
    }

   
    private void ApplyMesh()
    {
        if (PropMeshFilter) PropMeshFilter.mesh = PickupItem.ItemPrefab.GetComponentInChildren<MeshFilter>().sharedMesh;

        if (PropMeshRenderer) PropMeshRenderer.material = PickupItem.ItemPrefab.GetComponentInChildren<MeshRenderer>().sharedMaterial;

       



    }

    private void OnValidate()
    {
      
        ApplyMesh();
    }
   
    public void OnTriggerEnter(Collider other)
    {
       // Debug.Log("Here");
        if (!other.CompareTag("Player")) return;
        ItemInstance.UseItem(other.GetComponent<PlayerController>());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
