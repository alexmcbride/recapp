using iRacingSdkWrapper;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace RecapApp
{
    public class RecapService
    {
        private readonly ISdkWrapper sdk;
        private readonly IDeserializer deserializer;

        public SessionInfo SessionInfo { get; private set; }

        public RecapService() : this(new SdkWrapper()) { }

        public RecapService(ISdkWrapper sdk)
        {
            this.sdk = sdk;
            this.sdk.TelemetryUpdateFrequency = 1; // once per second
            this.sdk.EventRaiseType = SdkWrapper.EventRaiseTypes.CurrentThread;
            this.sdk.SessionInfoUpdated += OnSessionInfoUpdated;

            deserializer = new DeserializerBuilder().IgnoreUnmatchedProperties().Build();
        }

        private void OnSessionInfoUpdated(object sender, SdkWrapper.SessionInfoUpdatedEventArgs e)
        {
            SessionInfo = deserializer.Deserialize<SessionInfo>(e.SessionInfo.RawYaml);
        }

        public void Start()
        {
            sdk.Start();
        }
    }
}
