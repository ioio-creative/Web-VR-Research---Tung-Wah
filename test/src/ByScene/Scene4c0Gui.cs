using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Scene4c0Gui : MonoBehaviour
{
    public StoryStartControl storyStartManager;
    public VRInput vrCamera;
    
    //public AnimationControl heartBeatAnim;

    private void Awake()
    {
        IList<GuiModelBase> myGuiModels = new List<GuiModelBase>();
        

        /* adding text contents */

        DoubleTextStatement Stat4_1_0= new DoubleTextStatement(Color.white,
            "- 41歲 -", "父母在你不知不覺間變老",
            GuiPrefabUtils.DoubleTextFirstGazeDuration, GuiPrefabUtils.DoubleTextSecondGazeDuration,
            vrCamera, myGuiModels);


        /* end of adding text contents */


        /* setting next stories or next scenes */


        Stat4_1_0.AddNextScene(vrCamera.GetComponent<VRCameraFade>(),
            GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene4cName);


        /* end of setting next stories or next scenes */


        /* setting start gui */

        Stat4_1_0.SetAsStartGui(storyStartManager);

        /* end of setting start gui */


        /* activating guis */
        // [Important] This is needed because the prefab game objects are set to be inactive so that the OnEnable event is not called during Prefab Instantiation.

        foreach (GuiModelBase myGuiModel in myGuiModels)
        {
            myGuiModel.SetActive(true);
        }

        /* end of activating guis */
    }
}