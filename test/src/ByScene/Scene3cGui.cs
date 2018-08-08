using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Scene3cGui : MonoBehaviour
{
    public StoryStartControl storyStartManager;
    public VRInput vrCamera;
    public AudioSource[] AudSrcsToFadeOut;
    //public AnimationControl heartBeatAnim;

    private void Awake()
    {
        IList<GuiModelBase> myGuiModels = new List<GuiModelBase>();

        
        /* adding text contents */

        SingleTextStatement Stat4_6 = new SingleTextStatement(
              "迷惘煩惱的你相約好友Tony到酒吧\n交換近況", GuiPrefabUtils.SingleTextGazeDuration,
              vrCamera, myGuiModels);


        DoubleChoiceQuestion Q3 = new DoubleChoiceQuestion(
              "Tony最近轉了工，他充滿活力的形象啟發了你\n「我也要轉換一下環境嗎？」", "找一份新工作", "還是多做幾年\n累積經驗再算",
              vrCamera, myGuiModels, SceneSwitchControl.Scene3Q3Name);

        Q3.AddStoreTwoSelectionChoice(SceneSwitchControl.Scene3Q3Name);



        /* end of adding text contents */


        /* setting next stories or next scenes */

        Stat4_6.AddNextStory(Q3);

        Q3.AddNextScene(vrCamera.GetComponent<VRCameraFade>(), GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene3dName,
            DoubleChoiceQuestion.SelectionSlider1Or2.Slider1, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);

        Q3.AddNextScene(vrCamera.GetComponent<VRCameraFade>(), GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene3dName,
            DoubleChoiceQuestion.SelectionSlider1Or2.Slider2, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);

        /* end of setting next stories or next scenes */


        /* setting start gui */
        Stat4_6.SetAsStartGui(storyStartManager);
        //Stat4_4.SetAsStartGui(storyStartManager);

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