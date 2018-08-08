using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class InitialiseGuiPrefabs : MonoBehaviour
{
    public StoryStartControl storyStartManager;

    private void Awake()
    {
        IList<GuiModelBase> myGuiModels = new List<GuiModelBase>();


        /* adding camera */

        VRInput vrCameraInput = (new CameraVr()).GetVrInput();

        /* end of adding camera */


        /* adding text contents */

        SingleTextStatement Stat3_0 = new SingleTextStatement(
            "你開始喜歡一些事物，討厭一些事物", GuiPrefabUtils.SingleTextGazeDuration, vrCameraInput, myGuiModels);

        DoubleChoiceQuestion Q3_1 = new DoubleChoiceQuestion(
            "譬如說，媽媽送了一個新書包給你", "喜歡禮物\n親吻媽媽", "不喜歡禮物\n向媽媽發脾氣", vrCameraInput, myGuiModels, SceneSwitchControl.Scene1Q3Name);

        SingleTextStatement Stat4_0 = new SingleTextStatement(
            "你很喜歡爸爸媽媽\n覺得他們就是你的全世界了", GuiPrefabUtils.SingleTextGazeDuration, vrCameraInput, myGuiModels);

        DoubleChoiceQuestion Q4_1 = new DoubleChoiceQuestion(
            "因此，當你不小心\n打破了父母心愛的花瓶的時候\n你特別害怕", "向爸爸媽媽\n道歉", "謊稱是小狗\n撞破花瓶",
            vrCameraInput, myGuiModels, SceneSwitchControl.Scene1Q4Name);

        SingleTextStatement Stat4A_0 = new SingleTextStatement(
            "你媽媽為了哄你\n答應再送另一份禮物給你", GuiPrefabUtils.SingleTextGazeDuration, vrCameraInput, myGuiModels);

        SingleTextStatement Stat4A_1 = new SingleTextStatement(
            "你開心地笑出來\n你知道他們真的是很疼愛你", GuiPrefabUtils.SingleTextGazeDuration, vrCameraInput, myGuiModels);

        SingleTextStatement End_0 = new SingleTextStatement(
            "爸爸的確很生氣\n第一次這麼凶狠地責罵你", GuiPrefabUtils.SingleTextGazeDuration, vrCameraInput, myGuiModels);

        SingleTextStatement End_1 = new SingleTextStatement(
            "你害怕、你傷心、你哭 ……\n那天，你一整天都沒有再說話", GuiPrefabUtils.SingleTextGazeDuration, vrCameraInput, myGuiModels);

        SingleTextStatement End_2 = new SingleTextStatement(
            "媽媽似乎留意到你的情緒", GuiPrefabUtils.SingleTextGazeDuration, vrCameraInput, myGuiModels);

        SingleTextStatement End_3 = new SingleTextStatement(
            "那天夜晚，她進了你的房間，跟你說：\n「不要緊，爸爸媽媽依然愛你。」", GuiPrefabUtils.SingleTextGazeDuration, vrCameraInput, myGuiModels);

        SingleTextStatement End_4 = new SingleTextStatement(
            "那是你童年裡，一個溫暖而深刻的晚上", GuiPrefabUtils.SingleTextGazeDuration, vrCameraInput, myGuiModels);

        SingleTextStatement EndA_0 = new SingleTextStatement(
            "你看來還不擅長撒謊\n爸爸媽媽很快悉破你的謊言", GuiPrefabUtils.SingleTextGazeDuration, vrCameraInput, myGuiModels);

        SingleTextStatement EndA_1 = new SingleTextStatement(
            "你父母對你撒謊更為生氣\n第一次這麼凶狠地罵你", GuiPrefabUtils.SingleTextGazeDuration, vrCameraInput, myGuiModels);

        /* end of adding text contents */


        /* setting next stories or next scenes */

        Stat3_0.AddNextStory(Q3_1);
        Q3_1.AddNextStory(Stat4_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider1);
        Q3_1.AddNextStory(Stat4A_1, DoubleChoiceQuestion.SelectionSlider1Or2.Slider2);
        Stat4_0.AddNextStory(Q4_1);
        Q4_1.AddNextStory(End_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider1);
        Q4_1.AddNextStory(EndA_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider2);
        Stat4A_0.AddNextStory(Stat4A_1);
        Stat4A_1.AddNextStory(Stat4_0);
        End_0.AddNextStory(End_1);
        End_1.AddNextStory(End_2);
        End_2.AddNextStory(End_3);
        End_3.AddNextStory(End_4);
        End_4.AddNextScene(vrCameraInput.GetComponent<VRCameraFade>(),
            GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene1aName);
        EndA_0.AddNextStory(EndA_1);
        EndA_1.AddNextStory(End_1);

        /* end of setting next stories or next scenes */


        /* setting start gui */

        Stat3_0.SetAsStartGui(storyStartManager);

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