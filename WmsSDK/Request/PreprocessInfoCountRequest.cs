﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmsSDK.Response;

namespace WmsSDK.Request
{
    public class PreprocessInfoCountRequest : IWMSRequest<PreprocessInfoCountResponse>
    {
        public string GetAPIPath()
        {
            return "/preprocessInfo/getPreprocessInfoCount";
        }

              [JsonProperty("skuCode")]
        public string skuCode { get; set; }

              [JsonProperty("status")]
        public int status { get; set; }

    }
}
