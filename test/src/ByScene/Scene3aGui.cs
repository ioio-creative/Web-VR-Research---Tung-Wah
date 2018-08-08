using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Scene3aGui : MonoBehaviour
{
    public StoryStartControl storyStartManager;
    public VRInput vrCamera;
    public AudioSource[] AudSrcsToFadeOut;
    public AudioClip phoneCall;

    private void Awake()
    {
        IList<GuiModelBase> myGuiModels = new List<GuiModelBase>();

        
        /* adding text contents */

        SingleTextStatement Stat0_0 = new SingleTextStatement(
            "資料搜集、會議報告、\n匯報書、報價表、採購表、\n訂單、合約 ……", 4.0f,
            vrCamera, myGuiModels);

        SingleTextStatement Stat0_1 = new SingleTextStatement(
            "辦公桌上，堆積不同的工作文件\n你預計自己可能又要加班了", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        DoubleChoiceQuestion Q1 = new DoubleChoiceQuestion(
            "你繼續準備計劃書\n發現同事負責的部分有幾個錯誤", "裝作看不見", "自行幫同事\n修正錯誤",
            vrCamera, myGuiModels, SceneSwitchControl.Scene3Q1Name);

        SingleTextStatement Stat3_0 = new SingleTextStatement(
            "你的辦公電話響起\n同事拜託你校對整份匯報文件\n改正錯漏", 4.5f,
            vrCamera, myGuiModels);

        Stat3_0.AddPlayAudioOnUiFadeInComplete(GuiPrefabUtils.SceneSoundEffectVolume, false, phoneCall);



        SingleTextStatement Stat3_1 = new SingleTextStatement(
            "你開始懷疑\n你同事是故意把自己的工作卸給你的\n你沒有太多選擇的餘地", 4.5f,
            vrCamera, myGuiModels);

        //SingleTextStatement Stat3_3 = new SingleTextStatement(
        //    "已經將近十時\n你終於可以離開公司\n你拖著疲憊的身子準備回家", 4.5f,
        //    vrCamera, myGuiModels);


        /* end of adding text contents */


        /* setting next stories or next scenes */

        Stat0_0.AddNextStory(Stat0_1);
        Stat0_1.AddNextStory(Q1);
        Q1.AddNextStory(Stat3_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider1);
        Q1.AddNextScene(vrCamera.GetComponent<VRCameraFade>(), GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene3bName,
            DoubleChoiceQuestion.SelectionSlider1Or2.Slider2, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);
        Stat3_0.AddNextStory(Stat3_1);
        Stat3_1.AddNextScene(vrCamera.GetComponent<VRCameraFade>(),
            GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene3bName, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);



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