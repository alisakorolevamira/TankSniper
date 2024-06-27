using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.InfrastructureInterfaces.Services.Spawners;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;
using Sources.Scripts.UIFramework.Presentations.Texts;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Inventory
{
    public class InventoryTankView : View, IInventoryTankView
    {
        [SerializeField] private UIText _levelText;
        
        private InventorySlotView _currentTankPoint;
        private IInventoryTankSpawnerService _spawnerService;
        
        public int Level { get; private set; }
        
        public void Construct(IInventoryTankSpawnerService spawnerService, int level, InventorySlotView currentPoint)
        {
            _spawnerService = spawnerService;
            Level = level;
            _currentTankPoint = currentPoint;
            _levelText.SetText(Level.ToString());
        }

        public void OnDeselected()
        {
            Ray ray = new Ray(transform.position, Vector3.down);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                bool isUnderPoint = hitInfo.collider.TryGetComponent(out InventorySlotView slotView);

                if (isUnderPoint)
                {
                    if (slotView == _currentTankPoint)
                        return;
                    
                    if (slotView.IsEmpty)
                    {
                        _currentTankPoint.ClearSlot();
                        slotView.SetTank(this);
                        _currentTankPoint = slotView;
                        transform.position = slotView.transform.position;
                        
                        return;
                    }

                    if (slotView.CurrentTank.Level == Level)
                    {
                        Destroy();
                        slotView.CurrentTank.Destroy();
                        _currentTankPoint.ClearSlot();
                        _spawnerService.Spawn(Level + InventoryTankConst.DefaultTankLevel, slotView);
                        
                        return;
                    }
                }
                
                transform.position = _currentTankPoint.transform.position;
            }
        }
    }
}