using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Scene2gGui : MonoBehaviour
{
    public StoryStartControl storyStartManager;
    public VRInput vrCamera;
    public AudioSource[] AudSrcsToFadeOut;

    private void Awake()
    {
        IList<GuiModelBase> myGuiModels = new List<GuiModelBase>();
        

        /* adding text contents */

        DoubleChoiceQuestion Q5A = new DoubleChoiceQuestion(
            "你走到巴士站，終於離開自修室回家\n卻遇見穿著籃球運動服的同班女同學Jenny\n她一臉心事的樣子 ……", "走過去跟\nJenny聊天", "裝作沒看見\n排在巴士站末端",
            vrCamera, myGuiModels, SceneSwitchControl.Scene2Q5Name);

        Q5A.AddStoreTwoSelectionChoice(SceneSwitchControl.Scene2Q5Name);

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

        Q5A.AddNextStory(Stat6_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider1);
        Q5A.AddNextScene(vrCamera.GetComponent<VRCameraFade>(), GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene2hName,
            DoubleChoiceQuestion.SelectionSlider1Or2.Slider2, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);
        Stat6_0.AddNextStory(Stat6_1);
        Stat6_1.AddNextStory(Stat6_2);
        Stat6_2.AddNextStory(Stat6_3);
        Stat6_3.AddNextScene(vrCamera.GetComponent<VRCameraFade>(),
            GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene2hName, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);



        /* end of setting next stories or next scenes */


        /* setting start gui */

        Q5A.SetAsStartGui(storyStartManager);

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