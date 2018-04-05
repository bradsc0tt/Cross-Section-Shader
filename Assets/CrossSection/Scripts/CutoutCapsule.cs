using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(CapsuleCollider))]
public class CutoutCapsule : MonoBehaviour {

    [OnValueChanged("UpdateCollider")]
    public float Radius = 0.5f;
    [OnValueChanged("UpdateCollider")]
    public float Height = 1f;

    private CapsuleCollider m_collider { get { return GetComponent<CapsuleCollider>(); } }
    public CutoutObject CutoutObject { get; set; }

    private void UpdateCollider()
    {
        m_collider.radius = Radius;
        m_collider.height = Height;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.hasChanged)
            if (CutoutObject != null)
                CutoutObject.UpdateSections();
    }
}
