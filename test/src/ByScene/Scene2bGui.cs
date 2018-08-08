using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Scene2bGui : MonoBehaviour
{
    public TwoChoiceStoryStartControl twoChoiceStoryStartManager;
    public VRInput vrCamera;
    public AudioClip classroomBell;
    public AudioSource[] AudSrcsToFadeOut;

    //public AnimationControl heartBeatAnim;

    
    private void Awake()
    {
        IList<GuiModelBase> myGuiModels = new List<GuiModelBase>();


        /* adding text contents */

        SingleTextStatement Stat2_0 = new SingleTextStatement(
            "你遲到了", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        Stat2_0.AddPlayAudioOnUiFadeInComplete(GuiPrefabUtils.SceneSoundEffectVolume, false, classroomBell);
        
        SingleTextStatement Stat2_1 = new SingleTextStatement(
            "第一堂便是數學測驗", GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        SingleTextStatement Stat2_2 = new SingleTextStatement(
            "這次測驗不合格了", GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        SingleTextStatement Stat2A_0 = new SingleTextStatement(
            "你準時回到學校", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        Stat2A_0.AddPlayAudioOnUiFadeInComplete(GuiPrefabUtils.SceneSoundEffectVolume, false, classroomBell);

        //DoubleChoiceQuestion Q2 = new DoubleChoiceQuestion(doubleChoiceGui,
        //    "坐在你身旁的好友Tony\n裝作不經意地碰碰你手臂\n把選擇題的答案展示給你", "抄襲好友答案", "拒絕出貓",
        //    vrCamera, myGuiModels, SceneSwitchControl.Scene2Q2Name);

        //SingleTextStatement Stat2A_0 = new SingleTextStatement(singleTextGui,
        //   "你準時回到學校\n第一堂便是數學測驗", GuiPrefabUtils.SingleTextGazeDuration,
        //   vrCamera, myGuiModels);

        //Stat2A_0.AddPlayAudioOnUiFadeInComplete(GuiPrefabUtils.SceneSoundEffectVolume, false, classroomBell);

        //SingleTextStatement Stat2A_1 = new SingleTextStatement(singleTextGui,
        //    "依然睡眼惺忪的你，望著試卷\n腦袋好像僵住了一樣",
        //    GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        //SingleTextStatement Stat3_0 = new SingleTextStatement(singleTextGui,
        //    "就在你不斷抄寫Tony的答案時\n忽然有人敲敲你的桌子",
        //    GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        //SingleTextStatement Stat3_1 = new SingleTextStatement(singleTextGui,
        //    "被發現了！\n老師發現你和Tony作弊",
        //    GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        //SingleTextStatement Stat3_2 = new SingleTextStatement(singleTextGui,
        //    "你的操行紀錄上\n被刻上無法磨滅的缺點",
        //    GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        //SingleTextStatement Stat3_3 = new SingleTextStatement(singleTextGui,
        //    "而你和Tony\n也多了一個互相嘲笑的回憶",
        //    GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);

        //SingleTextStatement Stat3A_0 = new SingleTextStatement(singleTextGui,
        //    "這次測驗要不合格了\n但你寧願接受一個真正的成績",
        //    GuiPrefabUtils.SingleTextGazeDuration, vrCamera, myGuiModels);       

        /* end of adding text contents */


        /* setting next stories or next scenes */

        Stat2_0.AddNextStory(Stat2_1);
        Stat2_1.AddNextStory(Stat2_2);
        Stat2_2.AddNextScene(vrCamera.GetComponent<VRCameraFade>(), GuiPrefabUtils.CameraFadeDuration,
            SceneSwitchControl.Scene2cName, AudSrcsToFadeOut, GuiPrefabUtils.AudioFadeDuration);
        Stat2A_0.AddNextStory(Stat2_1);

        /* end of setting next stories or next scenes */


        /* setting start gui */

        twoChoiceStoryStartManager.m_Option1StartFader = GuiPrefabUtils.GetUiFader(Stat2_0.underlyingGameObj);
        twoChoiceStoryStartManager.m_Option1StartTextForGaze = GuiPrefabUtils.GetTextForGaze(Stat2_0.underlyingGameObj);
        twoChoiceStoryStartManager.m_Option2StartFader = GuiPrefabUtils.GetUiFader(Stat2A_0.underlyingGameObj);
        twoChoiceStoryStartManager.m_Option2StartTextForGaze = GuiPrefabUtils.GetTextForGaze(Stat2A_0.underlyingGameObj);

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