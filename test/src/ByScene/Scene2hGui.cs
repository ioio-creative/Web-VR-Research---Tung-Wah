using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Scene2hGui : MonoBehaviour
{
    public TwoChoiceStoryStartControl twoChoiceStoryStartManager;
    public VRInput vrCamera;
    public AudioSource[] AudSrcsToFadeOut;

    private void Awake()
    {
        IList<GuiModelBase> myGuiModels = new List<GuiModelBase>();

        
        /* adding text contents */

        DoubleChoiceQuestion Q6 = new DoubleChoiceQuestion(
            "你抽中了兩張演唱會的門卷\n想邀請Jenny一同觀看，可是演唱會的日子\n正是校內模擬試的備試時期", "依然邀請Jenny\n一同觀看", "把演唱會門票\n送給別人\n專注預備模擬試",
            vrCamera, myGuiModels, SceneSwitchControl.Scene2Q5Name);

        Vector3 pos = GuiPrefabUtils.GetSelectionSlider2Text(Q6.underlyingGameObj).gameObject.transform.position;
        GuiPrefabUtils.GetSelectionSlider2Text(Q6.underlyingGameObj).gameObject.transform.position = new Vector3(pos.x, pos.y + 0.2f, pos.z);

        SingleTextStatement End_0 = new SingleTextStatement(
            "Jenny答應了你\n你們一起去了聽演唱會\n渡過了一個愉快的晚上", 4.5f,
            vrCamera, myGuiModels);

        SingleTextStatement End_1 = new SingleTextStatement(
            "代價是\n你的模擬試也考得一塌糊塗", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement End_2 = new SingleTextStatement(
            "「已經追不上了吧？」\n你對考大學失去了信心", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement End_3 = new SingleTextStatement(
            "考不上大學的話\n我應該怎麼辦？\n未來，應該怎麼辦？", 4.0f,
            vrCamera, myGuiModels);

        SingleTextStatement End_5 = new SingleTextStatement(
            "但你開始問自己這個問題的時候\n那就意味著", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement End_6 = new SingleTextStatement(
            "你長大了 ……", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Stat6A_0 = new SingleTextStatement(
            "你其實對這樣重覆的生活感到厭悶", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        DoubleChoiceQuestion Q6A = new DoubleChoiceQuestion(
            "有一天，你抽中了演唱會的門券\n想找朋友一同觀看，可是演唱會的日子\n正是校內模擬試的前夕", "依然邀請朋友\n一同觀看", "把演唱會門票\n送給別人\n專注預備模擬試",
            vrCamera, myGuiModels, SceneSwitchControl.Scene2Q5Name);

        Vector3 pos2 = GuiPrefabUtils.GetSelectionSlider2Text(Q6A.underlyingGameObj).gameObject.transform.position;
        GuiPrefabUtils.GetSelectionSlider2Text(Q6A.underlyingGameObj).gameObject.transform.position = new Vector3(pos2.x, pos2.y + 0.2f, pos2.z);

        SingleTextStatement EndA_0 = new SingleTextStatement(
            "演唱會十分精彩\n你和朋友們享受了愉快的一天", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement EndA_1 = new SingleTextStatement(
            "代價是\n你的模擬試也考得一塌糊塗", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement EndB_0 = new SingleTextStatement(
            "你始終覺得\n應付公開試比較重要", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement EndB_1 = new SingleTextStatement(
            "你憧憬著大學美好的生活\n這使你讀書更加有動力", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement EndB_2 = new SingleTextStatement(
            "大學生活\n到底是怎樣的呢？\n未來，到底是怎樣的呢？", 4.0f,
            vrCamera, myGuiModels);        

        /* end of adding text contents */


        /* setting next stories or next scenes */

        Q6.AddNextStory(End_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider1);
        Q6.AddNextStory(EndB_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider2);
        End_0.AddNextStory(End_1);
        End_1.AddNextStory(End_2);
        End_2.AddNextStory(End_3);
        End_3.AddNextStory(End_5);
        End_5.AddNextStory(End_6);
        End_6.AddNextScene(vrCamera.GetComponent<VRCameraFade>(),
            GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene3a_0Name, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);

        EndB_0.AddNextStory(EndB_1);
        EndB_1.AddNextStory(EndB_2);
        EndB_2.AddNextScene(vrCamera.GetComponent<VRCameraFade>(),
            GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene3a_0Name, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);

        Stat6A_0.AddNextStory(Q6A);
        Q6A.AddNextStory(EndA_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider1);
        Q6A.AddNextStory(EndB_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider2);
        EndA_0.AddNextStory(EndA_1);
        EndA_1.AddNextScene(vrCamera.GetComponent<VRCameraFade>(),
            GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene3a_0Name, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);

        /* end of setting next stories or next scenes */


        /* setting start gui */

        twoChoiceStoryStartManager.m_LastQuestionIdentifier = SceneSwitchControl.Scene2Q5Name;
        twoChoiceStoryStartManager.m_Option1StartFader = GuiPrefabUtils.GetUiFader(Q6.underlyingGameObj);
        twoChoiceStoryStartManager.m_Option1StartTextForGaze = GuiPrefabUtils.GetTextForGaze(Q6.underlyingGameObj);
        twoChoiceStoryStartManager.m_Option2StartFader = GuiPrefabUtils.GetUiFader(Stat6A_0.underlyingGameObj);
        twoChoiceStoryStartManager.m_Option2StartTextForGaze = GuiPrefabUtils.GetTextForGaze(Stat6A_0.underlyingGameObj);

        //Stat5_1.SetAsStartGui(storyStartManager);

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