using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmsSDK.Response;

namespace WmsSDK.Request
{
    public class PackTaskRequest : IWMSRequest<PackTaskResponse>
    {
        public string GetAPIPath()
        {
            return "/packTask/getPackTaskList";
        }

        /// <summary>
        /// 页码
        /// </summary>
        [JsonProperty("pageIndex")]
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页显示数量
        /// </summary>
        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("deliveryDate")]
        public DateTime? deliveryDate { get; set; }

        [JsonProperty("skuCode")]
        public string skuCode { get; set; }


        [JsonProperty("status")]
        public int status { get; set; }


    }
}
