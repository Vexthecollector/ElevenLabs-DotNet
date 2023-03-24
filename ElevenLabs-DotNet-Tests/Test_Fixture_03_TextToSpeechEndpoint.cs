﻿// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace ElevenLabs.Voice.Tests
{
    internal class Test_Fixture_03_TextToSpeechEndpoint
    {
        [Test]
        public async Task Test_01_TextToSpeech()
        {
            var api = new ElevenLabsClient(ElevenLabsAuthentication.LoadFromEnv());
            Assert.NotNull(api.TextToSpeechEndpoint);
            var voice = (await api.VoicesEndpoint.GetAllVoicesAsync()).FirstOrDefault();
            Assert.NotNull(voice);
            var defaultVoiceSettings = await api.VoicesEndpoint.GetDefaultVoiceSettingsAsync();
            var clipPath = await api.TextToSpeechEndpoint.TextToSpeechAsync("The quick brown fox jumps over the lazy dog.", voice, defaultVoiceSettings);
            Assert.NotNull(clipPath);
            Console.WriteLine(clipPath);
        }
    }
}