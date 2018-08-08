using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Scene4aGui : MonoBehaviour
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
            "三十而立\n你開始建立起自己的家庭", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Stat0_1 = new SingleTextStatement(
            "你的人生展開了新一章\n對於自己成為爸爸\n你又驚又喜 ……", 4.5f,
            vrCamera, myGuiModels);

        SingleTextStatement Stat0_2 = new SingleTextStatement(
            "同樣感到驚喜的，還有你媽媽\n她得知自己有孫女後，十分欣喜", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        DoubleChoiceQuestion Q1 = new DoubleChoiceQuestion(
            "你媽媽提議她搬到你家住幾個月\n幫忙照顧文珊和孫女\n然而文珊卻似乎不太情願 ……", "接受媽媽的建議", "聽從文珊的\n意願，婉拒媽媽", 
            vrCamera, myGuiModels, SceneSwitchControl.Scene4Q1Name);

        //Q1.AddStoreTwoSelectionChoice(SceneSwitchControl.Scene2Q1Name);

        SingleTextStatement Stat2_0 = new SingleTextStatement(
            "文珊的確不太高興。有些日子\n文珊和你媽媽在家中都為著\n一些事情發生小爭執",
            4.5f, vrCamera, myGuiModels);

        SingleTextStatement Stat2_1 = new SingleTextStatement(
            "夾著中間的你，尤其煩惱", GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        SingleTextStatement Stat2_2_0 = new SingleTextStatement(
            "當一個兒子，當一個丈夫\n真不是一件容易的事；而你現在 ……", 4.5f, vrCamera, myGuiModels);

        SingleTextStatement Stat2_2_1 = new SingleTextStatement(
            "還要當一個父親了", GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        SingleTextStatement Stat2_A = new SingleTextStatement(
            "你媽媽似乎不理解\n你為什麼拒絕自己的好事\n為此和你爭執了一小段日子",
            4.5f, vrCamera, myGuiModels);


        /* end of adding text contents */


        /* setting next stories or next scenes */

        Stat0_0.AddNextStory(Stat0_1);
        Stat0_1.AddNextStory(Stat0_2);
        Stat0_2.AddNextStory(Q1);
        Q1.AddNextStory(Stat2_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider1);
        Q1.AddNextStory(Stat2_A, DoubleChoiceQuestion.SelectionSlider1Or2.Slider2);
        Stat2_0.AddNextStory(Stat2_1);
        Stat2_1.AddNextStory(Stat2_2_0);
        Stat2_A.AddNextStory(Stat2_2_0);
        Stat2_2_0.AddNextStory(Stat2_2_1);
        Stat2_2_1.AddNextScene(vrCamera.GetComponent<VRCameraFade>(),
            GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene4b_0Name, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);
        
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