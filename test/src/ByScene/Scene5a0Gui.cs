using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Scene5a0Gui : MonoBehaviour
{
    public StoryStartControl storyStartManager;
    public VRInput vrCamera;
    
    //public AnimationControl heartBeatAnim;

    private void Awake()
    {
        IList<GuiModelBase> myGuiModels = new List<GuiModelBase>();

    
        /* adding text contents */

        DoubleTextStatement Stat0_0_0= new DoubleTextStatement(Color.white,
            "- 50歲 -", "你進入中年",
            GuiPrefabUtils.DoubleTextFirstGazeDuration, GuiPrefabUtils.DoubleTextSecondGazeDuration,
            vrCamera, myGuiModels);

        /* end of adding text contents */


        /* setting next stories or next scenes */


        Stat0_0_0.AddNextScene(vrCamera.GetComponent<VRCameraFade>(),
            GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene5aName);


        /* end of setting next stories or next scenes */


        /* setting start gui */

        Stat0_0_0.SetAsStartGui(storyStartManager);

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