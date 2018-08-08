using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Scene3dGui : MonoBehaviour
{
    public TwoChoiceStoryStartControl storyStartManager;
    public VRInput vrCamera;
    public AudioSource[] AudSrcsToFadeOut;

    private void Awake()
    {
        IList<GuiModelBase> myGuiModels = new List<GuiModelBase>();        


        /* adding text contents */

        SingleTextStatement Stat5_2 = new SingleTextStatement(
              "你找到一間年輕的企業\n沒有大公司的穩定保障\n但也沒有太多傳統規矩、\n壁壘分明的上司下屬關係 ……",
              4.5f, vrCamera, myGuiModels);

        SingleTextStatement Stat5_3 = new SingleTextStatement(
              "雖然工作有時也會很繁忙\n但這公司明顯更符合你的個性",
              GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        SingleTextStatement Stat5_4 = new SingleTextStatement(
              "在公司工作多年\n漸漸得到上司賞識和晉升機會",
              GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        SingleTextStatement Stat5_5 = new SingleTextStatement(
              "你偶爾瀏覽Facebook\n剛發現Jenny發佈了一張新照片\n她和新男友甜蜜合照",
              4.5f, vrCamera, myGuiModels);

        SingleTextStatement Stat5_6 = new SingleTextStatement(
              "你望著照片，祝福她、感謝她\n是她令你重新掌握到自己生活的節奏\n留意身邊的人和事",
              4.5f, vrCamera, myGuiModels);

        DoubleChoiceQuestion Q4 = new DoubleChoiceQuestion(
              "此時\n坐在你旁邊的新入職同事文珊\n對著電腦螢幕一臉緊張地敲打鍵盤", "沖一杯咖啡\n給文珊\n為她打氣", "笑笑不理\n繼續自己的工作",
              vrCamera, myGuiModels, SceneSwitchControl.Scene3Q4Name);

        Vector3 pos2 = GuiPrefabUtils.GetSelectionSlider1Text(Q4.underlyingGameObj).gameObject.transform.position;
        GuiPrefabUtils.GetSelectionSlider1Text(Q4.underlyingGameObj).gameObject.transform.position = new Vector3(pos2.x, pos2.y + 0.2f, pos2.z);

        SingleTextStatement End_0 = new SingleTextStatement(
              "文珊感謝你的體貼關心\n跟你分享工作上的煩惱",
              GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        SingleTextStatement End_1 = new SingleTextStatement(
              "你聽著文珊的煩惱，彷彿想起當年\n剛畢業投身工作的自己",
              GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        SingleTextStatement End_2 = new SingleTextStatement(
              "「不要緊的\n這個問題可以解決得了。」\n你提供意見，幫助文珊",
              4.5f, vrCamera, myGuiModels);

        SingleTextStatement End_3 = new SingleTextStatement(
              "對，不要緊的\n問題始終可以解決得了 ……",
              GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        SingleTextStatement EndA_0 = new SingleTextStatement(
              "你望著文珊煩惱的樣子\n彷彿想起當年剛畢業\n投身工作的自己",
              4.5f, vrCamera, myGuiModels);

        SingleTextStatement EndA_1 = new SingleTextStatement(
              "或許每個人都需要經歷\n一次進入社會的迷惘吧？",
              GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        SingleTextStatement EndA_2 = new SingleTextStatement(
              "「不要緊的，問題始終可以解決得了。」\n你心裡這樣想",
              GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        SingleTextStatement EndA_3 = new SingleTextStatement(
              "你心裡這樣相信", GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        /* end of adding text contents */


        /* setting next stories or next scenes */

        Stat5_2.AddNextStory(Stat5_3);
        Stat5_3.AddNextStory(Stat5_4);
        Stat5_4.AddNextStory(Stat5_5);
        Stat5_5.AddNextStory(Stat5_6);
        Stat5_6.AddNextStory(Q4);
        Q4.AddNextStory(End_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider1);
        Q4.AddNextStory(EndA_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider2);
        End_0.AddNextStory(End_1);
        End_1.AddNextStory(End_2);
        End_2.AddNextStory(End_3);
        End_3.AddNextScene(vrCamera.GetComponent<VRCameraFade>(),
            GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene4a_0Name, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);
        EndA_0.AddNextStory(EndA_1);
        EndA_1.AddNextStory(EndA_2);
        EndA_2.AddNextStory(EndA_3);
        EndA_3.AddNextScene(vrCamera.GetComponent<VRCameraFade>(),
            GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene4a_0Name, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);




        /* end of setting next stories or next scenes */


        /* setting start gui */

        //Stat5_2.SetAsStartGui(storyStartManager);
        storyStartManager.m_LastQuestionIdentifier = SceneSwitchControl.Scene3Q3Name;
        storyStartManager.m_Option1StartFader = GuiPrefabUtils.GetUiFader(Stat5_2.underlyingGameObj);
        storyStartManager.m_Option1StartTextForGaze = GuiPrefabUtils.GetTextForGaze(Stat5_2.underlyingGameObj);
        storyStartManager.m_Option2StartFader = GuiPrefabUtils.GetUiFader(Stat5_4.underlyingGameObj);
        storyStartManager.m_Option2StartTextForGaze = GuiPrefabUtils.GetTextForGaze(Stat5_4.underlyingGameObj);

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