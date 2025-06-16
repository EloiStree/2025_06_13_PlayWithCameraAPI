// Copyright (c) Meta Platforms, Inc. and affiliates.

using PassthroughCameraSamples;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi.QuestCameraAPI
{
    public class WebCamTextureManagerRelayMono : MonoBehaviour
    { 
        public WebCamTextureManager m_source;
        public WebCamTexture m_inSource;
        public UnityEvent<WebCamTexture> m_onRelayed;

        public bool m_relayAtEachFrame = true;


        public void Update()
        {
            if (m_relayAtEachFrame)
            {
                RelayTexture();
            }
        }

        public void RelayTexture() {

            if (m_source == null || m_source.WebCamTexture == null)
            {
                return;
            }
            //var texture = Texture2D.CreateExternalTexture(m_source.WebCamTexture.width, m_source.WebCamTexture.height, TextureFormat.RGBA32, false, false, m_source.WebCamTexture.GetNativeTexturePtr());


            m_inSource = m_source.WebCamTexture;
            m_onRelayed?.Invoke(m_inSource);
        }
    }


}
