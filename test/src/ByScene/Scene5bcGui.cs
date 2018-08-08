using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Scene5bcGui : MonoBehaviour
{
    public StoryStartControl storyStartManager;
    public VRInput vrCamera;
    public Transform heartbeatSphere;
    public AnimationControl heartbeatAnimationControl;  
    public AudioClip hospitalCurtainClip;
    //public AudioSource[] AudSrcsToFadeOut;

    //public AudioClip heartbeatClip;
    //private AudioSource heartbeatAudio;
    public AudioClip scene5Q3Clip;
    private AudioSource scene5Q3ClipSource;
    public AudioClip scene5Q4Clip;
    private AudioSource scene5Q4ClipSource;
    public AudioClip scene5Q4LoopClip;
    private AudioSource scene5Q4LoopClipSource;

    public AudioSource passAwayAudio;

    private SelectionSlider passAwaySelectionSlider;
    private UIFader Stat4_1UiFader;
    private UIFader Q4UiFader;


    private void OnEnable()
    {        
        Stat4_1UiFader.OnFadeInComplete += HandleStat4_1GazeComplete;
        Q4UiFader.OnFadeInReachThreshold += HandleQ4FadeInReachThreshold;
        passAwaySelectionSlider.OnBarFilled += HandlePassAwaySelection;
    }

    private void OnDisable()
    {        
        Stat4_1UiFader.OnFadeInComplete -= HandleStat4_1GazeComplete;
        Q4UiFader.OnFadeInReachThreshold -= HandleQ4FadeInReachThreshold;
        passAwaySelectionSlider.OnBarFilled -= HandlePassAwaySelection;
    }

    
    private void HandleStat4_1GazeComplete()
    {
        scene5Q3ClipSource.Stop();
    }

    private void HandleQ4FadeInReachThreshold()
    {
        scene5Q4ClipSource.Stop();
        scene5Q4LoopClipSource.Play();
    }

    private void HandlePassAwaySelection()
    {
        //StartCoroutine(PassAwayCoroutine());
        PassAwayCoroutine();
    }

    private void PassAwayCoroutine()
    {
        //yield return new WaitForSeconds(1f);
        //heartbeatAudio.Stop();
        scene5Q4LoopClipSource.Stop();
        Quaternion newHeartBeatSphereRotation = new Quaternion();
        newHeartBeatSphereRotation.eulerAngles = new Vector3(0, 140, 0);
        heartbeatSphere.rotation = newHeartBeatSphereRotation;
        heartbeatAnimationControl.StopAnimation(16);
        //StartCoroutine(FadeEffectUtils.FadeOut(heartbeatSphere.gameObject.GetComponent<Renderer>(), 10f));
        passAwayAudio.Play();
    }


    private void Awake()
    {
        IList<GuiModelBase> myGuiModels = new List<GuiModelBase>();

        
        /* adding text contents */

        DoubleTextStatement Stat2_2_0 = new DoubleTextStatement(Color.white,
            "- 60歲 -", "你開始邁向退休的年紀", 
            GuiPrefabUtils.DoubleTextFirstGazeDuration, GuiPrefabUtils.DoubleTextSecondGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Stat2_2_1 = new SingleTextStatement(Color.white,
            "女兒也已經30歲\n到了結婚的年齡", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Stat2_3 = new SingleTextStatement(Color.white,
            "看著她也擁有自己的家庭\n你感到放心安慰", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        DoubleChoiceQuestion Q2 = new DoubleChoiceQuestion(Color.white,
            "她要搬離你的家\n和她的丈夫一起居住了 ……", "無奈接受", "欣然接受", vrCamera, myGuiModels, SceneSwitchControl.Scene5Q2Name);

        SingleTextStatement Stat3_0 = new SingleTextStatement(Color.white,
            "這時你才發現，原來你不捨得", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Stat3_1 = new SingleTextStatement(Color.white,
            "她已經長大了，你無從改變 ……", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        DoubleTextStatement Stat3_2_0 = new DoubleTextStatement(Color.white,
            "- 82歲 -", "你患上末期癌症，需要長期進出醫院",
            GuiPrefabUtils.DoubleTextFirstGazeDuration, GuiPrefabUtils.DoubleTextSecondGazeDuration,
            vrCamera, myGuiModels);

        SingleTextStatement Stat3_2_1 = new SingleTextStatement(Color.white,
            "你回來了", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);        

        Stat3_2_1.AddPlayAudioOnUiFadeInComplete(GuiPrefabUtils.SceneSoundEffectVolume, false, hospitalCurtainClip);

        SingleTextStatement Stat3_3 = new SingleTextStatement(Color.white,
            "你年老乏力的身體\n就如嬰孩時期般軟弱無力", GuiPrefabUtils.SingleTextGazeDuration,
            vrCamera, myGuiModels);

        scene5Q3ClipSource = Stat3_3.AddPlayAudioOnUiFadeInComplete(GuiPrefabUtils.SceneSoundEffectVolume, true, scene5Q3Clip);

        SingleTextStatement Stat3_4 = new SingleTextStatement(Color.white,
            "當你看到你女兒、女婿、\n孫子、親友全都圍在你床邊\n文珊靠在你床邊，哭成淚人的樣子時 ……",
            6f, vrCamera, myGuiModels);

        SingleTextStatement Stat3_5 = new SingleTextStatement(Color.white,
            "你就意識到自己是差不多走到盡頭了", 4f, vrCamera, myGuiModels);

        SingleTextStatement Stat3_6 = new SingleTextStatement(Color.white,
            "你忽然想起過往很多和文珊的經歷片段", 4f, vrCamera, myGuiModels);

        SingleTextStatement Stat3_7 = new SingleTextStatement(Color.white,
            "第一次約會、第一次吵架、結婚、生小孩、\n一起為工作煩惱、一起為小孩擔憂、\n互相鼓勵、互相安慰 ……",
            6f, vrCamera, myGuiModels);

        DoubleChoiceQuestion Q3 = new DoubleChoiceQuestion(Color.white,
            "慢慢的\n你的臉頰也流下了兩行淚水 ……", "默然不語", "跟文珊說：\n「謝謝你，\n我愛你。」",
            vrCamera, myGuiModels, SceneSwitchControl.Scene5Q3Name);

        Vector3 pos2 = GuiPrefabUtils.GetSelectionSlider2Text(Q3.underlyingGameObj).gameObject.transform.position;
        GuiPrefabUtils.GetSelectionSlider2Text(Q3.underlyingGameObj).gameObject.transform.position = new Vector3(pos2.x, pos2.y + 0.2f, pos2.z);        

        SingleTextStatement Stat4_0 = new SingleTextStatement(Color.white,
            "這就是你的理想人生嗎？\n有時你會這樣問自己", 4f,
            vrCamera, myGuiModels);

        scene5Q4ClipSource = Stat4_0.AddPlayAudioOnUiFadeInReachThreshold(0.5f, true, scene5Q4Clip, 0f);

        SingleTextStatement Stat4_1 = new SingleTextStatement(Color.white,
            "漸漸的，你又開始聽到心臟微微的跳動\n感受到身體被一種暖流包裹", 4f,
            vrCamera, myGuiModels);

        Stat4_1UiFader = GuiPrefabUtils.GetUiFader(Stat4_1.underlyingGameObj);
        //heartbeatAudio = Stat4_1.AddPlayAudioOnUiFadeInComplete(GuiPrefabUtils.SceneSoundEffectVolume, true, heartbeatClip);
        Stat4_1.AddPlayAnimationOnUiFadeInComplete(heartbeatAnimationControl);

        SingleTextStatement Stat4_2 = new SingleTextStatement(Color.white,
            "生命，悄悄消逝 ……", 4f,
            vrCamera, myGuiModels);

        SingleChoiceQuestion Q4 = new SingleChoiceQuestion(Color.white, 
            "你願意離開這個世界\n結束這一趟人生旅程嗎？", "我願意", vrCamera,myGuiModels);

        Q4UiFader = GuiPrefabUtils.GetUiFader(Q4.underlyingGameObj);
        scene5Q4LoopClipSource = Q4.AddPlayAudioOnUiFadeInReachThreshold(GuiPrefabUtils.SceneSoundEffectVolume, true, scene5Q4LoopClip, 0f);
        passAwaySelectionSlider = GuiPrefabUtils.GetSelectionSlider(Q4.underlyingGameObj);
        Q4.SetOnFilledAudioClipForSlider(null);

        SingleTextStatement Stat4_A = new SingleTextStatement(Color.white,
            "「我也愛你。」\n文珊抹一抹眼淚，跟你說", 4f,
            vrCamera, myGuiModels);

        SingleTextStatement End_1 = new SingleTextStatement(Color.white,
            "人生 …… 總是經歷選擇、擁有與失去\n你未必可以完全掌控你的人生\n更無法回到過去再來一次",
            GuiPrefabUtils.LastSceneSingleTextGazeDuration, vrCamera, myGuiModels);

        //UIFader End_1UiFader = GuiPrefabUtils.GetUiFader(End_1.underlyingGameObj);
        //End_1UiFader.m_FadeSpeed = 0.2f;

        SingleTextStatement End_2 = new SingleTextStatement(Color.white,
            "但是 …… 以甚麼心態面對人生起跌\n如何與你覺得重要的人相處\n是可以由你來決定",
            GuiPrefabUtils.LastSceneSingleTextGazeDuration, vrCamera, myGuiModels);

        SingleTextStatement End_3 = new SingleTextStatement(Color.white,
            "人，只可活一次！",
            GuiPrefabUtils.LastSceneSingleTextGazeDuration, vrCamera, myGuiModels);

        SingleTextStatement End_4 = new SingleTextStatement(Color.white,
            "回到現實，你會如何繼續你的人生呢?",
            GuiPrefabUtils.LastSceneSingleTextGazeDuration, vrCamera, myGuiModels);

        SingleTextStatement End_5 = new SingleTextStatement(Color.white,
            "（請脫下眼鏡，遵循工作人員指示離開）",
            3600f, vrCamera, myGuiModels);

        //SingleTextStatement

        /* end of adding text contents */


        /* setting next stories or next scenes */

        Stat2_2_0.AddNextStory(Stat2_2_1);
        Stat2_2_1.AddNextStory(Stat2_3);
        Stat2_3.AddNextStory(Q2);
        Q2.AddNextStory(Stat3_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider1);
        Q2.AddNextStory(Stat3_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider2);
        Stat3_0.AddNextStory(Stat3_1);
        Stat3_1.AddNextStory(Stat3_2_0);
        Stat3_2_0.AddNextStory(Stat3_2_1);
        Stat3_2_1.AddNextStory(Stat3_3);
        Stat3_3.AddNextStory(Stat3_4);
        Stat3_4.AddNextStory(Stat3_5);
        Stat3_5.AddNextStory(Stat3_6);
        Stat3_6.AddNextStory(Stat3_7);
        Stat3_7.AddNextStory(Q3);
        Q3.AddNextStory(Stat4_0, DoubleChoiceQuestion.SelectionSlider1Or2.Slider1);
        Q3.AddNextStory(Stat4_A, DoubleChoiceQuestion.SelectionSlider1Or2.Slider2);
        Stat4_0.AddNextStory(Stat4_1);
        Stat4_1.AddNextStory(Stat4_2);
        Stat4_2.AddNextStory(Q4);
        Stat4_A.AddNextStory(Stat4_0);
        //Q4.AddNextScene(vrCamera.GetComponent<VRCameraFade>(),
        //    GuiPrefabUtils.CameraFadeDuration, SceneSwitchControl.Scene5dName);
        Q4.AddNextStory(End_1);
        End_1.AddNextStory(End_2);
        End_2.AddNextStory(End_3);
        End_3.AddNextStory(End_4);
        End_4.AddNextStory(End_5);

        /* end of setting next stories or next scenes */


        /* setting start gui */

        Stat2_2_0.SetAsStartGui(storyStartManager);

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