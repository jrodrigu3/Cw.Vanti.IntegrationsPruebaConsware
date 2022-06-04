﻿namespace Cw.Vanti.Integrations.DtoModel
{
    using System.Text.Json.Serialization;

    public class JwtAuthResult
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refreshToken")]
        public RefreshToken RefreshToken { get; set; }
    }
}
