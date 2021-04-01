using Character.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    [RequireComponent(typeof(PlayerHealthComponent))]
    public class PlayerController : MonoBehaviour, PauseManager.IPausable

    {
        public CrossHairScript CrossHair => CrossHairComponent;
        [SerializeField] private CrossHairScript CrossHairComponent;

        private GameUIController GameUIController;
        public HealthComponent Health => HealthComponent;
        private HealthComponent HealthComponent;

        public InventoryComponent Inventory => InventoryComponent;
        private InventoryComponent InventoryComponent;

        public WeaponHolder WeaponHolder => WeaponHolderComponent;
        private WeaponHolder WeaponHolderComponent;

        private PlayerInput PlayerInput;

        [SerializeField] ConsumableItemScriptable consume;

        public bool IsFiring;
        public bool IsReloading;
        public bool IsJumping;
        public bool IsRunning;

        private void Start()
        {
           Health.TakeDamage(10);
           //consume.UseItem(this);
        }
        private void Awake()
        {
            if (GameUIController == null)
            {
                GameUIController = FindObjectOfType<GameUIController>();
            }
            if (PlayerInput == null)
            {
                PlayerInput = GetComponent<PlayerInput>();
            }
            if (HealthComponent == null)
            {
                HealthComponent = GetComponent<HealthComponent>();
            }
            if (WeaponHolderComponent == null)
            {
                WeaponHolderComponent = GetComponent<WeaponHolder>();
            }
            if (InventoryComponent == null)
            {
                InventoryComponent = GetComponent<InventoryComponent>();
            }

        }
        public  void OnPauseGame()
        {
            PauseManager.Instance.PauseGame();
        }

        public  void OnUnPauseGame()
        {
            PauseManager.Instance.UnPauseGame();
        }

        public void PauseGame()
        {
           
            GameUIController.EnablePauseMenu();
            if (PlayerInput)
            {
                PlayerInput.SwitchCurrentActionMap("PauseActionMap");
            }
        }

        public void UnPauseGame()
        {
            GameUIController.EnableGameMenu();
            if (PlayerInput)
            {
                PlayerInput.SwitchCurrentActionMap("PlayerActionMap");
            }
        }
    }

    
}
