using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Scene5aGui : MonoBehaviour
{
    public StoryStartControl storyStartManager;
    public VRInput vrCamera;
    public AudioSource[] AudSrcsToFadeOut;

    //public AnimationControl heartBeatAnim;

    private void Awake()
    {
        IList<GuiModelBase> myGuiModels = new List<GuiModelBase>();

        
        /* adding text contents */

        SingleTextStatement Stat0_0 = new SingleTextStatement(
            "你出入醫院的次數\n比起以前多了很多", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Stat0_1 = new SingleTextStatement(
            "這是學習別離的年紀 ……", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Stat0_2 = new SingleTextStatement(
            "你望著躺卧在病床上的父親\n身上插滿各種儀器，神色難受痛苦", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        DoubleChoiceQuestion Q1 = new DoubleChoiceQuestion(
            "醫生說\n他現在只能用機器勉強維持生命 ……", "同意放棄\n任何急救,\n讓父親離世", "用盡方法\n要父親繼續生存", vrCamera, myGuiModels, SceneSwitchControl.Scene5Q1Name);

        SingleTextStatement Q2_0 = new SingleTextStatement(
            "你不想讓父親繼續承受肉體的折磨", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Q2_1 = new SingleTextStatement(
            "你開始學懂放手", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Q2_A = new SingleTextStatement(
            "你盡可能想讓爸爸活一秒多一秒", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Q2_A1 = new SingleTextStatement(
            "你這樣或許是自私的\n但你的確就是捨不得 ……", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        /* end of adding text contents */


        /* setting next stories or next scenes */

        Stat0_0.AddNextStory(Stat0_1);
        Stat0_1.AddNextStory(Stat0_2);
        Stat0_2.AddNextStory(Q1);
        Q1.AddNextStory(Q2_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider1);
        Q1.AddNextStory(Q2_A, DoubleChoiceQuestion.SelectionSlider1Or2.Slider2);
        Q2_0.AddNextStory(Q2_1);
        Q2_1.AddNextScene(vrCamera.GetComponent<VRCameraFade>(),
            GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene5bcName);
        Q2_A.AddNextStory(Q2_A1);
        Q2_A1.AddNextScene(vrCamera.GetComponent<VRCameraFade>(),
            GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene5bcName);


        /* end of setting next stories or next scenes */


        /* setting start gui */

        Stat0_0.SetAsStartGui(storyStartManager);

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