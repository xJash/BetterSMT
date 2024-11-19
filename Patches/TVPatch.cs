using BepInEx;
using UnityEngine;
using UnityEngine.Video;
using System.Collections.Generic;
using HarmonyLib;
using Mirror;
using static UnityEngine.UIElements.StylePropertyAnimationSystem;

namespace BetterSMT.Patches;

//public class SharedTVMod 
//{
//    private static VideoPlayer videoPlayer;
//    private static string currentVideoURL;
//    private static bool isHost;
//
//    private void Start(MasterLobbyData __instance)
//    {
//        GameObject tvObject = GameObject.Find("decorat3"); 
//        if (tvObject != null)
//        {
//            videoPlayer = tvObject.GetComponent<VideoPlayer>();
//            if (videoPlayer != null)
//            {
//                videoPlayer.loopPointReached += OnVideoEnd;
//            }
//        }
//
//        if (__instance.isHost)
//        {
//            Debug.LogWarning("Host initialized. Broadcasting video changes.");
//        }
//        else
//        {
//            Debug.LogWarning("Client initialized. Listening for video updates.");
//        }
//    }
//
//    private void OnDestroy()
//    {
//        if (videoPlayer != null)
//        {
//            videoPlayer.loopPointReached -= OnVideoEnd;
//        }
//    }
//
//    private void Update()
//    {
//        if (isHost && Input.GetKeyDown(KeyCode.V)) 
//        {
//            StartVideo("http://example.com/video.mp4"); 
//        }
//    }
//
//    private void StartVideo(string videoURL)
//    {
//        currentVideoURL = videoURL;
//        videoPlayer.url = videoURL;
//        videoPlayer.Play();
//
//        Debug.LogWarning($"Playing video: {videoURL}");
//        BroadcastVideoStart(videoURL);
//    }
//
//    private void BroadcastVideoStart(string videoURL)
//    {
//        // send videoURL to all clients
//    }
//
//    private void OnVideoEnd(VideoPlayer source)
//    {
//        Debug.LogWarning("Video ended. Stopping playback.");
//        videoPlayer.Stop();
//
//        if (isHost)
//        {
//            BroadcastVideoEnd();
//        }
//    }
//
//    private void BroadcastVideoEnd()
//    {
//        // Notify clients to stop playback
//        // Replace with your networking framework's API.
//        NetworkManager.SendToAll("TVVideoEnd");
//    }
//
//    private static void HandleVideoStart(string videoURL)
//    {
//        if (!isHost && videoPlayer != null)
//        {
//            currentVideoURL = videoURL;
//            videoPlayer.url = videoURL;
//            videoPlayer.Play();
//            Debug.LogWarning($"Received video start command: {videoURL}");
//        }
//    }
//
//    private static void HandleVideoEnd()
//    {
//        if (!isHost && videoPlayer != null)
//        {
//            videoPlayer.Stop(); 
//            Debug.LogWarning("Received video end command.");
//        }
//    }
//
//    [HarmonyPatch(typeof(NetworkManager), "OnMessageReceived")]
//    public class NetworkManagerPatch
//    {
//        public static void Prefix(string messageType, object messageData)
//        {
//            if (messageType == "TVVideoStart")
//            {
//                HandleVideoStart((string)messageData);
//            }
//            else if (messageType == "TVVideoEnd")
//            {
//                HandleVideoEnd();
//            }
//        }
//    }
//}
