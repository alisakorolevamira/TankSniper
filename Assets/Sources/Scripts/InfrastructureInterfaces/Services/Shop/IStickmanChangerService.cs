﻿using Sources.Scripts.Domain.Models.Stickman;
using Sources.Scripts.Presentations.Views.Stickman;

namespace Sources.Scripts.InfrastructureInterfaces.Services.Shop
{
    public interface IStickmanChangerService
    {
        void ChangeStickman(StickmanType stickmanType);
        void Construct(StickmanChanger stickmanChanger);
    }
}