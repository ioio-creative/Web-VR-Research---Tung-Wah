using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Scene3bGui : MonoBehaviour
{
    public StoryStartControl storyStartManager;
    public VRInput vrCamera;
    public AudioSource[] AudSrcsToFadeOut;
    //public AnimationControl heartBeatAnim;

    private void Awake()
    {
        IList<GuiModelBase> myGuiModels = new List<GuiModelBase>();
        

        /* adding text contents */

        SingleTextStatement Stat3_3 = new SingleTextStatement(
            "已經將近十時\n你終於可以離開公司\n你拖著疲憊的身子準備回家", 4.5f,
            vrCamera, myGuiModels);

        DoubleChoiceQuestion Q2 = new DoubleChoiceQuestion(
              "此時，你的女朋友Jenny打電話給你\n問今晚可不可以見面", "表示自己\n加班很累\n想要回家休息", "答應Jenny\n和她見面",
              vrCamera, myGuiModels, SceneSwitchControl.Scene3Q2Name);
        Vector3 pos = GuiPrefabUtils.GetSelectionSlider1Text(Q2.underlyingGameObj).gameObject.transform.position;
        GuiPrefabUtils.GetSelectionSlider1Text(Q2.underlyingGameObj).gameObject.transform.position = new Vector3(pos.x, pos.y+0.2f, pos.z);

        SingleTextStatement Stat4_0 = new SingleTextStatement(
              "「你只管顧著工作吧！不要再找我！」\nJenny忽然向你大發脾氣\n但你沒有感到很意外", 4.5f,
              vrCamera, myGuiModels);

        SingleTextStatement Stat4_1 = new SingleTextStatement(
              "繁忙的工作\n令你少了很多時間和心力\n經營與Jenny的這段關係", 4.5f,
              vrCamera, myGuiModels);

        SingleTextStatement Stat4_2 = new SingleTextStatement(
              "你有時覺得\n是Jenny不體諒自己", GuiPrefabUtils.SingleTextGazeDuration,
              vrCamera, myGuiModels);

        SingleTextStatement Stat4_3 = new SingleTextStatement(
              "有時又會想\n難道我專注工作也錯了嗎？", GuiPrefabUtils.SingleTextGazeDuration,
              vrCamera, myGuiModels);

        SingleTextStatement Stat4A_0 = new SingleTextStatement(
              "「我覺得我們最近好像很少見面。」", GuiPrefabUtils.SingleTextGazeDuration,
              vrCamera, myGuiModels);

        SingleTextStatement Stat4A_1 = new SingleTextStatement(
              "一臉心事的Jenny這樣跟你說\n還和你提出不如大家冷靜一下 ……", GuiPrefabUtils.SingleTextGazeDuration,
              vrCamera, myGuiModels);

        SingleTextStatement Stat4A_2 = new SingleTextStatement(
              "你明白Jenny的想法", GuiPrefabUtils.SingleTextGazeDuration,
              vrCamera, myGuiModels);

        /* end of adding text contents */


        /* setting next stories or next scenes */

        Stat3_3.AddNextStory(Q2);
        Q2.AddNextStory(Stat4_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider1);
        Q2.AddNextStory(Stat4A_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider2);
        Stat4_0.AddNextStory(Stat4_1);
        Stat4_1.AddNextStory(Stat4_2);
        Stat4_2.AddNextStory(Stat4_3);
        Stat4_3.AddNextScene(vrCamera.GetComponent<VRCameraFade>(),
            GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene3c_0Name, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);
        Stat4A_0.AddNextStory(Stat4A_1);
        Stat4A_1.AddNextStory(Stat4A_2);
        Stat4A_2.AddNextStory(Stat4_1);

        /* end of setting next stories or next scenes */


        /* setting start gui */

        Stat3_3.SetAsStartGui(storyStartManager);

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