using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Scene4bGui : MonoBehaviour
{
    public StoryStartControl storyStartManager;
    public VRInput vrCamera;
    public AudioClip closeDoor;
    public AudioClip girlCry;
    public AudioSource[] AudSrcsToFadeOut;

    private AudioSource girlCrySource3_1;
    private AudioSource girlCrySource3A_3;


    private void Awake()
    {
        IList<GuiModelBase> myGuiModels = new List<GuiModelBase>();


        /* adding text contents */

        SingleTextStatement Stat2_3 = new SingleTextStatement(
            "有時你覺得家庭是一種甜蜜的負擔\n有時是一副沉重的軛", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        DoubleChoiceQuestion Q2 = new DoubleChoiceQuestion(
            "你女兒有時吵鬧任性，在考試的前一晚\n還吵嚷著要你給她玩iPad", "拒絕女兒要求", "答應女兒要求", 
            vrCamera, myGuiModels, SceneSwitchControl.Scene4Q2Name);

        SingleTextStatement Stat3_0 = new SingleTextStatement(
            "女兒感到生氣\n粗暴地把自己房門關上", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        Stat3_0.AddPlayAudioOnUiFadeInComplete(GuiPrefabUtils.SceneSoundEffectVolume, false, closeDoor);

        SingleTextStatement Stat3_1 = new SingleTextStatement(
            "你對女兒亂發脾氣感到相當不滿\n狠狠責罵女兒一頓，她大哭了出來", 7f,
            vrCamera, myGuiModels);

        Stat3_1.AddPlayAudioOnUiFadeInComplete(0.6f, false, girlCry);
        girlCrySource3_1 = Stat3_1.underlyingGameObj.GetComponent<AudioSource>();

        DoubleChoiceQuestion Q3 = new DoubleChoiceQuestion(
            "你見狀一時不忍再罵她\n忽然覺得自己可能也應該道歉", "向女兒道歉\n指自己語氣\n太重了", "保持父親威嚴\n堅拒道歉安慰",
            vrCamera, myGuiModels, SceneSwitchControl.Scene4Q3Name);

        SingleTextStatement Stat3A_0 = new SingleTextStatement(
            "你對她的撒嬌吵嚷看來\n沒什麼辦法，讓她玩了半小時", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Stat3A_1 = new SingleTextStatement(
            "但有些時候\n女兒實在令你忍不住動怒", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Stat3A_2 = new SingleTextStatement(
            "有一次\n她不小心打爛了你一瓶心愛的紅酒", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Stat3A_3 = new SingleTextStatement(
            "你狠狠責罵了女兒一頓\n她第一次看見你這麼生氣\n害怕得哭了出來", 7f,
            vrCamera, myGuiModels);

        Stat3A_3.AddPlayAudioOnUiFadeInComplete(0.6f, false, girlCry);
        girlCrySource3A_3 = Stat3A_3.underlyingGameObj.GetComponent<AudioSource>();

        //SingleTextStatement Stat4_0 = new SingleTextStatement(
        //    "女兒的哭聲慢慢止住\n一顆小小的心開始鎮定下來 ……", GuiPrefabUtils.SingleTextGazeDuration,
        //    vrCamera, myGuiModels);

        //uiFader4_0 = GuiPrefabUtils.GetUiFader(Stat4_0.underlyingGameObj);

        //SingleTextStatement Stat4A_0 = new SingleTextStatement(
        //    "女兒似是被你罵得怕了\n一直哭一直哭，過了很久才終於止住", GuiPrefabUtils.SingleTextGazeDuration,
        //    vrCamera, myGuiModels);

        //uiFader4A_0 = GuiPrefabUtils.GetUiFader(Stat4A_0.underlyingGameObj);

        //SingleTextStatement Stat4A_1 = new SingleTextStatement(
        //    "或者，這會成了你和她\n關係上的一道小缺口", GuiPrefabUtils.SingleTextGazeDuration,
        //    vrCamera, myGuiModels);

        /* end of adding text contents */


        /* setting next stories or next scenes */

        List<AudioSource> sources = new List<AudioSource>(AudSrcsToFadeOut);
        sources.Add(girlCrySource3_1);
        sources.Add(girlCrySource3A_3);

        AudioSource[] audioSources = sources.ToArray();

        Stat2_3.AddNextStory(Q2);
        Q2.AddNextStory(Stat3_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider1);
        Q2.AddNextStory(Stat3A_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider2);
        Stat3_0.AddNextStory(Stat3_1);
        Stat3_1.AddNextScene(vrCamera.GetComponent<VRCameraFade>(),
                    GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene4c_0Name, audioSources, GuiPrefabUtils.AudioFadeDuration);
        Stat3A_0.AddNextStory(Stat3A_1);
        Stat3A_1.AddNextStory(Stat3A_2);
        Stat3A_2.AddNextStory(Stat3A_3);
        Stat3A_3.AddNextScene(vrCamera.GetComponent<VRCameraFade>(),
                    GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene4c_0Name, audioSources, GuiPrefabUtils.AudioFadeDuration);



        /* end of setting next stories or next scenes */


        /* setting start gui */

        Stat2_3.SetAsStartGui(storyStartManager);

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