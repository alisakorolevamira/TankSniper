// Copyright (c) 2015 - 2023 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

//.........................
//.....Generated Class.....
//.........................
//.......Do not edit.......
//.........................

using System.Collections.Generic;
// ReSharper disable All
namespace Doozy.Runtime.UIManager.Containers
{
    public partial class UIView
    {
        public static IEnumerable<UIView> GetViews(UIViewId.Gameplay id) => GetViews(nameof(UIViewId.Gameplay), id.ToString());
        public static void Show(UIViewId.Gameplay id, bool instant = false) => Show(nameof(UIViewId.Gameplay), id.ToString(), instant);
        public static void Hide(UIViewId.Gameplay id, bool instant = false) => Hide(nameof(UIViewId.Gameplay), id.ToString(), instant);

        public static IEnumerable<UIView> GetViews(UIViewId.MainMenu id) => GetViews(nameof(UIViewId.MainMenu), id.ToString());
        public static void Show(UIViewId.MainMenu id, bool instant = false) => Show(nameof(UIViewId.MainMenu), id.ToString(), instant);
        public static void Hide(UIViewId.MainMenu id, bool instant = false) => Hide(nameof(UIViewId.MainMenu), id.ToString(), instant);

        public static IEnumerable<UIView> GetViews(UIViewId.Shop id) => GetViews(nameof(UIViewId.Shop), id.ToString());
        public static void Show(UIViewId.Shop id, bool instant = false) => Show(nameof(UIViewId.Shop), id.ToString(), instant);
        public static void Hide(UIViewId.Shop id, bool instant = false) => Hide(nameof(UIViewId.Shop), id.ToString(), instant);
    }
}

namespace Doozy.Runtime.UIManager
{
    public partial class UIViewId
    {
        public enum Gameplay
        {
            Empty,
            Entry,
            GameOver,
            Hud,
            LevelCompleted,
            Pause,
            ReloadWeapon,
            Settings,
            Shoot
        }

        public enum MainMenu
        {
            AddTankTutorial,
            FightTutorial,
            Hud,
            MergeTanksTutorial,
            Settings,
            Shop
        }

        public enum Shop
        {
            Tank1,
            Tank2
        }    
    }
}
