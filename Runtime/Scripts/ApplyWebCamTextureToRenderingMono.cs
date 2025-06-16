// Copyright (c) Meta Platforms, Inc. and affiliates.

using UnityEngine;
using UnityEngine.Events;

namespace Eloi.QuestCameraAPI
{
    public class ApplyWebCamTextureToRenderingMono : MonoBehaviour
    {
        public WebCamTexture m_webcamTexture;
        public Material[] m_materialsToAffect;
        public Renderer[] m_renderersToAffect;
        public UnityEvent<WebCamTexture> m_onWebcamTextureSet;
        public void SetWebcamTexture(WebCamTexture webCamTexture)
        {
            if (webCamTexture == null)
            {
                return;
            }
            if (m_webcamTexture == webCamTexture)
            {
                return;
            }


            if (m_materialsToAffect != null && m_materialsToAffect.Length > 0)
            {
                foreach (var material in m_materialsToAffect)
                {
                    if (material != null)
                    {
                        material.mainTexture = webCamTexture;
                    }
                }
            }
            if (m_renderersToAffect != null && m_renderersToAffect.Length > 0)
            {
                foreach (var renderer in m_renderersToAffect)
                {
                    if (renderer != null)
                    {
                        foreach (var material in renderer.materials)
                        {
                            material.mainTexture = webCamTexture;
                        }
                    }
                }
            }
            m_onWebcamTextureSet?.Invoke(webCamTexture);
        }


    }

}
