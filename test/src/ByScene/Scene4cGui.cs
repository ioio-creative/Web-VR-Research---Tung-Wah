using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Scene4cGui : MonoBehaviour
{
    public StoryStartControl storyStartManager;
    public VRInput vrCamera;
    public AudioSource[] AudSrcsToFadeOut;

    //public AnimationControl heartBeatAnim;

    private void Awake()
    {
        IList<GuiModelBase> myGuiModels = new List<GuiModelBase>();


        /* adding text contents */

        SingleTextStatement Stat4_1 = new SingleTextStatement(
            "到了這個年紀\n你要顧的，早就不只是一個家", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Stat4_2 = new SingleTextStatement(
            "這天早上\n文珊忘記攜帶女兒小學面試用的作品集\n要你連忙送回", 4.5f,
            vrCamera, myGuiModels);

        SingleTextStatement Stat4_3 = new SingleTextStatement(
            "就在你趕往學校途中\n你收到一個電話 ……", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        DoubleChoiceQuestion Q4 = new DoubleChoiceQuestion(
            "「你媽媽忽然暈倒送院了\n醫生說情況很危急 ……」\n爸爸焦急地說", "不差十分鐘\n先去學校", "立即改道到醫院", 
            vrCamera, myGuiModels, SceneSwitchControl.Scene4Q4Name);

        SingleTextStatement Stat5_0 = new SingleTextStatement(
            "為了女兒的升學\n你看不見你媽媽離世前\n最後一面了 ……", 4.5f,
            vrCamera, myGuiModels);

        SingleTextStatement Stat5_1 = new SingleTextStatement(
            "媽媽離世後\n你把爸爸也接過來一起居住", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Stat5_2 = new SingleTextStatement(
            "隨著年月\n你爸爸身體日漸變差\n已經需要別人貼身照顧", 4.5f,
            vrCamera, myGuiModels);

        SingleTextStatement Stat5_3 = new SingleTextStatement(
            "你考慮過送他到老人院\n但擔心他不喜歡", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        DoubleChoiceQuestion Q5 = new DoubleChoiceQuestion(
            "請一個有醫護知識的傭人\n在家貼身照顧也是一個選擇\n但價錢是老人院院費的兩倍", "聘請醫護傭人", "安排爸爸\n入住老人院",
            vrCamera, myGuiModels, SceneSwitchControl.Scene4Q5Name);

        SingleTextStatement Stat5A_0 = new SingleTextStatement(
            "你十分擔心媽媽的狀況\n趕赴醫院", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Stat5A_1 = new SingleTextStatement(
            "女兒也許上不到那所心儀的小學了\n但你趕得及見媽媽的最後一面", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Stat5A_2 = new SingleTextStatement(
            "你媽媽臨終前看見你\n展現了欣慰的笑容 ……", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Stat6A_0 = new SingleTextStatement(
            "你爸爸很不滿、失望\n他不情願住老人院；但你認為\n這已經是最好方案了",
            4.5f, vrCamera, myGuiModels);

        SingleTextStatement Stat6A_1 = new SingleTextStatement(
            "你把這件事告訴文珊\n她的回應卻超乎你的意料",
            GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        SingleTextStatement Stat6A_2 = new SingleTextStatement(
            "她認為應該為你爸爸聘請醫護傭人\n還向你說：\n「我還有些私己錢，我們一同分擔吧！」",
            4.5f, vrCamera, myGuiModels);

        SingleTextStatement End_0 = new SingleTextStatement(
            "你不想讓爸爸住老人院\n但你又擔心文珊會反對\n你聘請醫護傭人",
            GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        SingleTextStatement End_1 = new SingleTextStatement(
            "然而，文珊的支持卻超乎你意料\n還向你說：\n「我還有些私己錢，我們一同分擔吧！」",
            4.5f, vrCamera, myGuiModels);

        SingleTextStatement End_2 = new SingleTextStatement(
            "維持一個家不是一件容易的事\n需要忍耐、包容、犧牲...\n你慶幸有她，陪伴你，在這一路上",
            4.5f, vrCamera, myGuiModels);
        
        /* end of adding text contents */


        /* setting next stories or next scenes */


        Stat4_1.AddNextStory(Stat4_2);
        Stat4_2.AddNextStory(Stat4_3);
        Stat4_3.AddNextStory(Q4);
        Q4.AddNextStory(Stat5_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider1);
        Q4.AddNextStory(Stat5A_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider2);
        Stat5_0.AddNextStory(Stat5_1);
        Stat5_1.AddNextStory(Stat5_2);
        Stat5_2.AddNextStory(Stat5_3);
        Stat5_3.AddNextStory(Q5);
        Stat5A_0.AddNextStory(Stat5A_1);
        Stat5A_1.AddNextStory(Stat5A_2);
        Stat5A_2.AddNextStory(Stat5_1);
        Q5.AddNextStory(End_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider1);
        Q5.AddNextStory(Stat6A_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider2);

        Stat6A_0.AddNextStory(Stat6A_1);
        Stat6A_1.AddNextStory(Stat6A_2);
        Stat6A_2.AddNextStory(End_2);
        //Stat6_0.AddNextStory(Stat6_1);
        //Stat6_1.AddNextStory(Stat6_3);
        //Stat6_3.AddNextStory(Q6);
        //Stat6A_1.AddNextStory(Stat6_3);
        //Q6.AddNextStory(End_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider1);
        //Q6.AddNextStory(EndA_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider2);
        End_0.AddNextStory(End_1);
        End_1.AddNextStory(End_2);
        End_2.AddNextScene(vrCamera.GetComponent<VRCameraFade>(),
            GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene5a_0Name, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);
        //EndA_0.AddNextStory(EndA_1);
        //EndA_1.AddNextScene(vrCamera.GetComponent<VRCameraFade>(),
        //    GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene5a_0Name, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);

        /* end of setting next stories or next scenes */


        /* setting start gui */

        Stat4_1.SetAsStartGui(storyStartManager);

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