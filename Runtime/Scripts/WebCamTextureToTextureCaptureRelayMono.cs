// Copyright (c) Meta Platforms, Inc. and affiliates.

using System;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.QuestCameraAPI
{
    public class WebCamTextureToTextureCaptureRelayMono : MonoBehaviour
    {
        public WebCamTexture m_source;
        public Texture2D m_lastTextureCaptured;
        public UnityEvent<Texture2D> m_onTextureCaptured;
       

        public void SetSource(WebCamTexture source)
        {
            m_source = source;
        }

        [ContextMenu("Capture And Relay")]
        public void CaptureAndRelay() { 
        
            if (m_source == null || !m_source.isPlaying)
            {
                return;
            }

            if (m_lastTextureCaptured == null || m_lastTextureCaptured.width != m_source.width || m_lastTextureCaptured.height != m_source.height)
            {
                m_lastTextureCaptured = new Texture2D(m_source.width, m_source.height, TextureFormat.RGBA32, false);
            }
            m_lastTextureCaptured.SetPixels32(m_source.GetPixels32());
            m_lastTextureCaptured.Apply();
            m_onTextureCaptured?.Invoke(m_lastTextureCaptured);
        }
    }


}
