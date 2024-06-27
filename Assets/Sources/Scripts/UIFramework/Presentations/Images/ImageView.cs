using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Scripts.Domain.Models.Constants;
using Sources.Scripts.Presentations.Views;
using Sources.Scripts.PresentationsInterfaces.UI.Images;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Scripts.UIFramework.Presentations.Images
{
    public class ImageView : View, IImageView
    {
        [SerializeField] private Image _image;

        public float FillAmount => _image.fillAmount;
        
        public void SetSprite(Sprite sprite) =>
            _image.sprite = sprite;

        public void SetFillAmount(float fillAmount) =>
            _image.fillAmount = fillAmount;

        public UniTask FillMoveTowardsAsync(float duration, CancellationToken cancellationToken) =>
            UniTask.CompletedTask;

        public void ShowImage() => 
            _image.fillAmount = ImageConst.Max;

        public void HideImage() => 
            _image.fillAmount = 0f;
    }
}