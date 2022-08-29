using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;



[Serializable]
public class HammerParameters
{
    public Vector3 HammerHeadScale;
    public Vector3 HammerShiftScale;
}



public class ParameterInitializer : MonoBehaviour
{
    [SerializeField] private GameObject _hammerHead;
    [SerializeField] private GameObject _hammerShift;
    private HammerParameters _exportHammerParameters;
    private HammerParameters _importHammerParameters;


    // buttonから発火
    public void ExportHammerParameters()
    {
        _exportHammerParameters = new HammerParameters();
        _exportHammerParameters.HammerHeadScale = _hammerHead.transform.localScale;
        _exportHammerParameters.HammerShiftScale = _hammerShift.transform.localScale;
        SerializeToJsonFile();
    }
    private void SerializeToJsonFile()
    {
        string filePath = Application.dataPath + "/Resources/ParametersInfo.json";

        string json = JsonUtility.ToJson(_exportHammerParameters, true);
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json);       
        streamWriter.Flush();
        streamWriter.Close();
    }
    
    
    
    // buttonから発火
    public void ImportHammerParameters()
    {
        string inputString = Resources.Load<TextAsset>("ParametersInfo").ToString();
       
        // 読み取った文字列をLoadData型に変換。
        _importHammerParameters = JsonUtility.FromJson<HammerParameters>(inputString);
        Debug.Log(_importHammerParameters.HammerHeadScale.x);
        SetImportedParameters(_importHammerParameters.HammerHeadScale, _importHammerParameters.HammerShiftScale);
    }

    private void SetImportedParameters(Vector3 hammerHeadScale, Vector3 hammerShiftScale)
    {
        _hammerHead.transform.localScale = hammerHeadScale;
        _hammerShift.transform.localScale = hammerShiftScale;
        Debug.Log("aaa");
    }
    
    
    

}
