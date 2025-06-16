// Copyright (c) Meta Platforms, Inc. and affiliates.

using UnityEngine;
using UnityEngine.Events;

namespace Eloi.QuestCameraAPI
{
    public class ApplyTexture2DToRenderingMono : MonoBehaviour
    {
        public Texture2D m_texture2D;
        public Material[] m_materialsToAffect;
        public Renderer[] m_renderersToAffect;
        public UnityEvent<Texture2D> m_onTextureSet;
        public void SetTexture2D(Texture2D texture)
        {
            if (texture == null)
            {
                return;
            }
            if (m_texture2D == texture)
            {
                return;
            }


            if (m_materialsToAffect != null && m_materialsToAffect.Length > 0)
            {
                foreach (var material in m_materialsToAffect)
                {
                    if (material != null)
                    {
                        material.mainTexture = texture;
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
                            material.mainTexture = texture;
                        }
                    }
                }
            }
            m_onTextureSet?.Invoke(texture);
        }


    }

}
