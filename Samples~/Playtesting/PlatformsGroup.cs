﻿using UnityEngine;
using UnityEngine.UI;

namespace Agava.GameCoupons.Samples.Playtesting
{
    public class PlatformsGroup : MonoBehaviour
    {
        [SerializeField] private InputField _page;
        [SerializeField] private InputField _size;
        [SerializeField] private Button _requestButton;

        private void OnEnable()
        {
            _requestButton.onClick.AddListener(OnRequestButtonClicked);
        }

        private void OnDisable()
        {
            _requestButton.onClick.RemoveListener(OnRequestButtonClicked);
        }

        private async void OnRequestButtonClicked()
        {
            var platforms = await GameCoupons.Platforms(int.Parse(_page.text), int.Parse(_size.text), (error) => Debug.LogError(error));

            if (platforms != null)
                Debug.Log($"Platforms: {JsonUtility.ToJson(platforms)}");
        }
    }
}
