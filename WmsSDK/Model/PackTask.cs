using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WmsSDK.Model
{
    public class PackTask
    {

        [JsonProperty("id")]
        public long id { get; set; }


        [JsonProperty("packTaskCode")]
        public string PackTaskCode { get; set; }


        [JsonProperty("packTaskType")]
        public int PackTaskType { get; set; }

        [JsonProperty("status")]
        public int status { get; set; }

        [JsonProperty("skuCode")]
        public string skuCode { get; set; }

        [JsonProperty("goodsName")]
        public string goodsName { get; set; }

        [JsonProperty("orderNum")]
        public int orderNum { get; set; }

        [JsonProperty("progress")]
        public int progress { get; set; }

        [JsonProperty("orderCount")]
        public decimal orderCount { get; set; }

        [JsonProperty("partnerCode")]
        public string partnerCode { get; set; }

        [JsonProperty("partnerName")]
        public string partnerName { get; set; }

        [JsonProperty("warehouseCode")]
        public string warehouseCode { get; set; }

        [JsonProperty("regionCode")]
        public string regionCode { get; set; }

        [JsonProperty("originOrderNo")]
        public string originOrderNo { get; set; }

        [JsonProperty("customerCode")]
        public string customerCode { get; set; }

        [JsonProperty("orderDate")]
        public DateTime? orderDate { get; set; }

        [JsonProperty("deliveryDate")]
        public DateTime? deliveryDate { get; set; }

        [JsonProperty("operateTime")]
        public DateTime? operateTime { get; set; }

        [JsonProperty("createTime")]
        public DateTime? createTime { get; set; }

        [JsonProperty("createUser")]
        public string createUser { get; set; }

        [JsonProperty("uddateTime")]
        public DateTime? uddateTime { get; set; }

        [JsonProperty("updateUser")]
        public string updateUser { get; set; }

        [JsonProperty("yn")]
        public int yn { get; set; }
    }
}
