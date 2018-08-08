using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Scene2cGui : MonoBehaviour
{
    public StoryStartControl storyStartManager;
    public VRInput vrCamera;
    public AudioSource[] AudSrcsToFadeOut;

    //public AnimationControl heartBeatAnim;

    private void Awake()
    {
        IList<GuiModelBase> myGuiModels = new List<GuiModelBase>();

        
        /* adding text contents */

        DoubleChoiceQuestion Q3 = new DoubleChoiceQuestion(
            "放學後，今天是你期待已久的田徑校隊選拔\n但你現在卻要趕到校外\n上媽媽幫你報名的鋼琴班", "缺席鋼琴班\n參加田徑選拔", "趕赴鋼琴班",
            vrCamera, myGuiModels, SceneSwitchControl.Scene2Q3Name);

        SingleTextStatement Stat4_0 = new SingleTextStatement(
           "你可看見其他同學在操場上\n熱身、跑步、流汗的樣子\n你就忽然鼓起決心", 4.5f,
           vrCamera, myGuiModels);

        SingleTextStatement Stat4_1 = new SingleTextStatement(
            "跑吧！",
            GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        SingleTextStatement Stat4A_0 = new SingleTextStatement(
           "還是不能辜負父母的期望吧", GuiPrefabUtils.SingleTextGazeDuration,
           vrCamera, myGuiModels);

        SingleTextStatement Stat4A_1 = new SingleTextStatement(
            "也許他們也說得對 ……",
            GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        /* end of adding text contents */


        /* setting next stories or next scenes */

        Q3.AddNextStory(Stat4_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider1);
        Q3.AddNextStory(Stat4A_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider2);
        Stat4_0.AddNextStory(Stat4_1);
        Stat4_1.AddNextScene(vrCamera.GetComponent<VRCameraFade>(), GuiPrefabUtils.CameraFadeDuration,
            SceneSwitchControl.Scene2f_0Name, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);
        Stat4A_0.AddNextStory(Stat4A_1);
        Stat4A_1.AddNextScene(vrCamera.GetComponent<VRCameraFade>(), GuiPrefabUtils.CameraFadeDuration,
            SceneSwitchControl.Scene2g_0Name, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);

        /* end of setting next stories or next scenes */


        /* setting start gui */


        /* end of setting start gui */
        Q3.SetAsStartGui(storyStartManager);

        /* activating guis */
        // [Important] This is needed because the prefab game objects are set to be inactive so that the OnEnable event is not called during Prefab Instantiation.

        foreach (GuiModelBase myGuiModel in myGuiModels)
        {
            myGuiModel.SetActive(true);
        }

        /* end of activating guis */
    }
}