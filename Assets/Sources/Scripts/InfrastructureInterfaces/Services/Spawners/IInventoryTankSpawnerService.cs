﻿using System.Collections.Generic;
using Sources.Scripts.Domain.Models.Inventory;
using Sources.Scripts.Presentations.Views.Inventory;
using Sources.Scripts.PresentationsInterfaces.Views.Inventory;
using UnityEngine;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Spawners
{
    public interface IInventoryTankSpawnerService
    {
        IInventoryTankView Spawn(int level, Vector3 position);
        InventorySlotView FindEmptySlot();
    }
}