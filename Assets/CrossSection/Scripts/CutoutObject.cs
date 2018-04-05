using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[ExecuteInEditMode]
public class CutoutObject : MonoBehaviour {

    [OnValueChanged("Init")]    
    public List<CutoutCapsule> cutouts = new List<CutoutCapsule>();
    [OnValueChanged("Init")]
    public Material cutoutMaterial;

	// Use this for initialization
	void Start () {
        Init();
        foreach (CutoutCapsule cut in cutouts)
            cut.CutoutObject = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (Application.isEditor && !Application.isPlaying)
            UpdateSections();
    }

    private void Init()
    {
        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
            rend.material = cutoutMaterial;
        cutoutMaterial.DisableKeyword("CLIP_PLANE");
        //cutoutMaterial.DisableKeyword("CLIP_SPHERE");
        cutoutMaterial.EnableKeyword("CLIP_TUBES");
        UpdateSections();
    }

    public void UpdateSections()
    {
        cutoutMaterial.SetInt("_hitCount", cutouts.Count);
        for(int i = 0; i < cutouts.Count; i++)
        {
            string point = "_hitPoint" + i.ToString();
            cutoutMaterial.SetVector(point, cutouts[i].transform.position);
            string rad = "_Rad" + i.ToString();
            cutoutMaterial.SetFloat(rad, cutouts[i].Radius);
            string dir = "_AxisDir" + i.ToString();
            cutoutMaterial.SetVector(dir, cutouts[i].transform.rotation * Vector3.up);
        }
    }
}


