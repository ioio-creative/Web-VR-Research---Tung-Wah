using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Scene3c0Gui : MonoBehaviour
{
    public StoryStartControl storyStartManager;
    public VRInput vrCamera;
    
    //public AnimationControl heartBeatAnim;

    private void Awake()
    {
        IList<GuiModelBase> myGuiModels = new List<GuiModelBase>();

        
        /* adding text contents */

        DoubleTextStatement Stat4_4_0= new DoubleTextStatement( Color.white,
            "- 28歲 -", "這樣的工作維持四年\n薪酬職級略略上調",
            GuiPrefabUtils.DoubleTextFirstGazeDuration, GuiPrefabUtils.DoubleTextSecondGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Stat4_4= new SingleTextStatement(Color.white,
            "營營役役，你身心已經感到厭倦\nJenny也正式和你分手了", GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        SingleTextStatement Stat4_5 = new SingleTextStatement(Color.white,
            "這就是你的理想人生嗎？\n有時你會這樣問自己", GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        /* end of adding text contents */


        /* setting next stories or next scenes */

        Stat4_4_0.AddNextStory(Stat4_4);
        Stat4_4.AddNextStory(Stat4_5);
        Stat4_5.AddNextScene(vrCamera.GetComponent<VRCameraFade>(),
            GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene3cName);


        /* end of setting next stories or next scenes */


        /* setting start gui */

        Stat4_4_0.SetAsStartGui(storyStartManager);

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