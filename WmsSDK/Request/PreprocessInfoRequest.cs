using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmsSDK.Model;
using WmsSDK.Response;

namespace WmsSDK.Request
{
    public class PreprocessInfoRequest : IWMSRequest<PreprocessInfoAddResponse>
    {
        public string GetAPIPath()
        {
            return "/preprocessInfo/batchAdd";
        }

        public List<PreprocessInfoAdd> request { get; set; }

             [JsonProperty("warehouseId")]
        public string wareHouseId { get; set; }
    }

    public class PreprocessInfoQueryRequest : IWMSRequest<PreprocessInfoResponse>
    {
        public string GetAPIPath()
        {
            return "/preprocessInfo/getList";
        }


          [JsonProperty("preprocessCode")]
        public string preprocessCode { get; set; }
   
    }

}
