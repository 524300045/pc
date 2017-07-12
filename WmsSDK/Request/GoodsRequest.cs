using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WmsSDK.Response;

namespace WmsSDK.Request
{
    public class GoodsRequest : IWMSRequest<GoodsResponse>
    {
        public string GetAPIPath()
        {
            return "/goods/getGoodsList";
        }

          [JsonProperty("skuCode")]
        public String skuCode;

          [JsonProperty("goodsName")]
          public String goodsName;


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


    }
}
