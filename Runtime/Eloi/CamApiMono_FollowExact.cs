using UnityEngine;


namespace Eloi.QuestCameraAPI {
    public class CamApiMono_FollowExact : MonoBehaviour
    {

        public Transform m_whatToFollow;
        public Transform m_whatToMove;

        public bool m_useUpdate = false;
        public bool m_useLateUpdate = true;
        public bool m_fetchMainCameraIfNull = true;

        private void Reset()
        {
            m_whatToMove = transform;
        }
    

        public void Update()
        {
            if (m_useUpdate)
            {
                Refresh();
            }
        }

       

        public void LateUpdate()
        {
            if (m_useLateUpdate)
            {
                Refresh();
            }
        }

        private void Refresh()
        {
            if (m_whatToFollow == null && m_fetchMainCameraIfNull)
            {
                m_whatToFollow = Camera.main?.transform;
            }
            if (m_whatToFollow != null && m_whatToMove != null)
            {
                m_whatToMove.position = m_whatToFollow.position;
                m_whatToMove.rotation = m_whatToFollow.rotation;
            }
        }
    }

}