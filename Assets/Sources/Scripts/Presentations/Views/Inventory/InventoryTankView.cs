﻿using System;
using Sources.Scripts.Controllers.Presenters.Inventory;
using Sources.Scripts.Infrastructure.Services.ObjectPool;
using Sources.Scripts.Infrastructure.Services.Spawners;
using Sources.Scripts.InfrastructureInterfaces.Services.ObjectPool;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;
using UnityEngine;

namespace Sources.Scripts.Presentations.Views.Inventory
{
    public class InventoryTankView : View, IInventoryTankView
    {
        private InventorySlotView _currentTankPoint;
        private InventoryTankSpawnerService _spawnerService;

        public event Action<int> AddNewTank;
        public int Level { get; private set; }
        
        public void Construct(InventoryTankSpawnerService spawnerService, int level)
        {
            _spawnerService = spawnerService;
            Level = level;
        }
        
        public void OnDeselected()
        {
            Ray ray = new Ray(transform.position, Vector3.down);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                bool isUnderPoint = hitInfo.collider.TryGetComponent(out InventorySlotView slotView);

                if (isUnderPoint)
                {
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
                        Hide();
                        slotView.CurrentTank.Hide();
                        _currentTankPoint.ClearSlot();
                        _spawnerService.Spawn(Level + 1, slotView.transform.position);
                        
                        return;
                    }
                }
                
                transform.position = _currentTankPoint.transform.position;
            }
        }
    }
}