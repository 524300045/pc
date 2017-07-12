using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WmsSDK.Model
{
     public class Goods
    {
        /** 主键id */
           [JsonProperty("id")]
        private long id;
        /** 商品编码 */
           [JsonProperty("skuCode")]
        private String skuCode;
        /** 客户编码 */
           [JsonProperty("customerCode")]
        private String customerCode;
        /** 商品名称 */
           [JsonProperty("goodsName")]
        private String goodsName;
        /** 最小分类编码 */
           [JsonProperty("categoryCode")]
        private String categoryCode;
        /** 最小分类名称 */
           [JsonProperty("categoryName")]
        private String categoryName;
        /** 规格型号 */
           [JsonProperty("goodsModel")]
        private String goodsModel;
        /** 等级 */
           [JsonProperty("goodsGrade")]
        private decimal goodsGrade;
        /** 品牌 */
           [JsonProperty("goodsBrand")]
        private int goodsBrand;
        /** 产地 */
           [JsonProperty("packTaskDetailId")]
        private String madeIn;
        /** 重量 */
           [JsonProperty("weight")]
        private decimal weight;
        /** 长 */
           [JsonProperty("packLong")]
        private decimal packLong;
        /** 宽 */
           [JsonProperty("packWide")]
        private decimal packWide;
        /** 高 */
           [JsonProperty("packHigh")]
        private decimal packHigh;
        /** 建议采购单价 */
          [JsonProperty("suggestPrice")]
        private decimal suggestPrice;
        /** 特殊要求 */
           [JsonProperty("specialAsk")]
        private int specialAsk;
        /** 包规（数量） */
           [JsonProperty("modelNum")]
        private decimal modelNum;
        /** 计价单位（斤、两） */
           [JsonProperty("goodsUnit")]
        private String goodsUnit;
        /** 物理单位（包、箱、瓶） */
           [JsonProperty("physicsUnit")]
        private String physicsUnit;
        /** 包装冗余上线 */
           [JsonProperty("upLimit")]
        private int upLimit;
        /** 包装冗余下线 */
           [JsonProperty("downLimit")]
        private int downLimit;
        /** 是否生鲜 1：是 0：否 */
           [JsonProperty("isFresh")]
        private int isFresh;
        /** 是否称重 1：是 0：否 */
           [JsonProperty("weighed")]
        private int weighed;
        /** 是否预加工 1：是 0：否 */
           [JsonProperty("isPreprocess")]
        private int isPreprocess;
        /** 参考成本 */
           [JsonProperty("referenceCost")]
        private String referenceCost;
        /** abc分类 */
           [JsonProperty("abcClass")]
        private String abcClass;
        /** 启用日期 */
           [JsonProperty("enableDate")]
        private DateTime enableDate;
        /** 启用停用标识:1：是 0：否 */
           [JsonProperty("enabled")]
        private int enabled;
        /** 国标码 */
           [JsonProperty("gbCode")]
        private String gbCode;
        /** 创建时间 */
           [JsonProperty("createTime")]
        private DateTime createTime;
        /** 创建人 */
           [JsonProperty("createUser")]
        private String createUser;
        /** 更新时间 */
           [JsonProperty("updateTime")]
        private DateTime updateTime;
        /** 更新人 */
           [JsonProperty("updateUser")]
        private String updateUser;
        /** 是否有效 */
           [JsonProperty("yn")]
        private int yn; 
    }
}
