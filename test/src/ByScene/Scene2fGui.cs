using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Scene2fGui : MonoBehaviour
{    
    public StoryStartControl storyStartManager;
    public VRInput vrCamera;
    public AudioSource[] AudSrcsToFadeOut;

    //public AnimationControl heartBeatAnim;

    private void Awake()
    {
        IList<GuiModelBase> myGuiModels = new List<GuiModelBase>();


        /* adding text contents */

        SingleTextStatement Stat5_1 = new SingleTextStatement(
            "你之後如願以償地成為田徑校隊\n代校出賽", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        DoubleChoiceQuestion Q5 = new DoubleChoiceQuestion(
            "今天練習結束的時候\n你看見同班同學Jenny獨自一人\n沒精打彩地坐在籃球場外的長櫈上", "買一枝水\n過去請Jenny喝", "裝作沒看見\n獨自離校",
            vrCamera, myGuiModels, SceneSwitchControl.Scene2Q5Name);

        Q5.AddStoreTwoSelectionChoice(SceneSwitchControl.Scene2Q5Name);

        SingleTextStatement Stat6_0 = new SingleTextStatement(
            "你關心Jenny\n為什麼看起來一臉心事", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Stat6_1 = new SingleTextStatement(
            "原來\nJenny父母希望她這年專心應付公開試\n想Jenny退出籃球隊", 4.5f,
            vrCamera, myGuiModels);

        SingleTextStatement Stat6_2 = new SingleTextStatement(
            "你把自己加入田徑校隊的經歷告訴Jenny ……", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Stat6_3 = new SingleTextStatement(
            "你的故事似乎鼓舞了Jenny\nJenny展露出笑容\n你和Jenny成為了好朋友", 4.5f,
            vrCamera, myGuiModels);

        /* end of adding text contents */


        /* setting next stories or next scenes */


        Stat5_1.AddNextStory(Q5);
        Q5.AddNextStory(Stat6_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider1);
        Stat6_0.AddNextStory(Stat6_1);
        Stat6_1.AddNextStory(Stat6_2);
        Stat6_2.AddNextStory(Stat6_3);
        Stat6_3.AddNextScene(vrCamera.GetComponent<VRCameraFade>(), GuiPrefabUtils.CameraFadeDuration,
            SceneSwitchControl.Scene2hName, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);
        Q5.AddNextScene(vrCamera.GetComponent<VRCameraFade>(), GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene2hName,
            DoubleChoiceQuestion.SelectionSlider1Or2.Slider2, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);

        /* end of setting next stories or next scenes */


        /* setting start gui */

        Stat5_1.SetAsStartGui(storyStartManager);


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