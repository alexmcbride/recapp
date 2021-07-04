using iRacingSdkWrapper.Broadcast;
using iRSDKSharp;
using System;

namespace iRacingSdkWrapper
{
    public interface ISdkWrapper
    {
        CameraControl Camera { get; }
        ChatControl Chat { get; }
        int ConnectSleepTime { get; set; }
        int DriverId { get; }
        SdkWrapper.EventRaiseTypes EventRaiseType { get; set; }
        bool IsConnected { get; }
        bool IsRunning { get; }
        PitCommandControl PitCommands { get; }
        ReplayControl Replay { get; }
        iRacingSDK Sdk { get; }
        TelemetryRecordingControl TelemetryRecording { get; }
        double TelemetryUpdateFrequency { get; set; }
        TextureControl Textures { get; }

        event EventHandler Connected;
        event EventHandler Disconnected;
        event EventHandler<SdkWrapper.SessionInfoUpdatedEventArgs> SessionInfoUpdated;
        event EventHandler<SdkWrapper.TelemetryUpdatedEventArgs> TelemetryUpdated;

        object GetData(string headerName);
        TelemetryValue<T> GetTelemetryValue<T>(string name);
        void RequestSessionInfoUpdate();
        void Start();
        void Stop();
    }
}