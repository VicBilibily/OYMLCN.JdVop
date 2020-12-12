using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OYMLCN.JdVop.Models
{
    /// <summary>
    ///   京东实物商品
    /// </summary>
    public class ProductDetail
    {
        /// <summary>
        ///   售卖单位
        /// </summary>
        public string SaleUnit { get; set; }
        /// <summary>
        ///   重量
        /// </summary>
        public string Weight { get; set; }
        /// <summary>
        ///   产地
        /// </summary>
        public string ProductArea { get; set; }
        /// <summary>
        ///   包装清单
        /// </summary>
        public string WareQD { get; set; }
        /// <summary>
        ///   主图
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        ///   规格参数
        /// </summary>
        public string Param { get; set; }
        /// <summary>
        ///   主站上下架状态 (1上架  0下架)
        /// </summary>
        public int State { get; set; }
        /// <summary>
        ///   商品编号
        /// </summary>
        public long SKU { get; set; }
        /// <summary>
        ///   品牌名称
        /// </summary>
        public string BrandName { get; set; }
        /// <summary>
        ///   UPC码
        /// </summary>
        public string UPC { get; set; }
        /// <summary>
        ///   分类 示例"670;729;4837"
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        ///   商品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///   商品详情页大字段
        /// </summary>
        public string Introduction { get; set; }


        /// <summary>
        ///   类型(空为实物，book为图书，video为音像)
        /// </summary>
        public string SkuType { get; set; }
        /// <summary>
        ///   图书数据类型标识
        /// </summary>
        public bool IsBook { get; protected set; }
        /// <summary>
        ///   音像数据类型标识
        /// </summary>
        public bool IsVideo { get; protected set; }
        /// <summary>
        ///   图书数据类型
        /// </summary>
        public ProductBook AsBook() => this as ProductBook;
        /// <summary>
        ///   音像数据类型
        /// </summary>
        /// <returns></returns>
        public ProductVideo AsVideo() => this as ProductVideo;

        /// <summary>
        ///   扩展查询数据
        /// </summary>
        public Dictionary<string,string> ExtData { get; set; }
    }

    /// <summary>
    ///   京东图书商品
    /// </summary>
    public class ProductBook : ProductDetail
    {
        /// <summary>
        ///   京东图书商品
        /// </summary>
        public ProductBook() => base.IsBook = true;


        /// <summary>
        ///   品牌
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        ///   印张
        /// </summary>
        public string Sheet { get; set; }
        /// <summary>
        ///   相关产品
        /// </summary>
        public string RelatedProducts { get; set; }
        /// <summary>
        ///   ISBN
        /// </summary>
        public string ISBN { get; set; }
        /// <summary>
        ///   编者
        /// </summary>
        public string Editer { get; set; }
        /// <summary>
        ///   印次
        /// </summary>
        public string PrintNo { get; set; }
        /// <summary>
        ///   作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        ///   套装数量
        /// </summary>
        public string PackNum { get; set; }
        /// <summary>
        ///   内容描述
        /// </summary>
        public string ContentDesc { get; set; }
        /// <summary>
        ///   印刷时间
        /// </summary>
        public string PrintTime { get; set; }
        /// <summary>
        ///   用纸
        /// </summary>
        public string Papers { get; set; }
        /// <summary>
        ///   包装(装帧)
        /// </summary>
        public string Package { get; set; }
        /// <summary>
        ///   校对
        /// </summary>
        public string Proofreader { get; set; }
        /// <summary>
        ///   编辑推荐
        /// </summary>
        public string EditerDesc { get; set; }
        /// <summary>
        ///   精彩书摘
        /// </summary>
        public string BookAbstract { get; set; }
        /// <summary>
        ///   目录
        /// </summary>
        public string Catalogue { get; set; }
        /// <summary>
        ///   出版时间
        /// </summary>
        public string PublishTime { get; set; }
        /// <summary>
        ///   页数
        /// </summary>
        public string Pages { get; set; }
        /// <summary>
        ///   作者简介
        /// </summary>
        public string AuthorDesc { get; set; }
        /// <summary>
        ///   图片
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        ///   译者
        /// </summary>
        public string Transfer { get; set; }
        /// <summary>
        ///   绘者
        /// </summary>
        public string Drawer { get; set; }
        /// <summary>
        ///   图书语言
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        ///   版次
        /// </summary>
        public string BatchNo { get; set; }
        /// <summary>
        ///   精彩书评
        /// </summary>
        public string Comments { get; set; }

    }
    /// <summary>
    ///   京东音像商品
    /// </summary>
    public class ProductVideo : ProductDetail
    {
        /// <summary>
        ///   京东音像商品
        /// </summary>
        public ProductVideo() => base.IsVideo = true;


        /// <summary>
        ///   出版社
        /// </summary>
        public string Press { get; set; }
        /// <summary>
        ///   外文名
        /// </summary>
        public string Foreignname { get; set; }
        /// <summary>
        ///   品牌
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        ///   格式
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        ///   演奏者
        /// </summary>
        public string Performer { get; set; }
        /// <summary>
        ///   碟数
        /// </summary>
        public string Soundtrack { get; set; }
        /// <summary>
        ///   演员
        /// </summary>
        public string Actor { get; set; }
        /// <summary>
        ///   地区
        /// </summary>
        public string Dregion { get; set; }
        /// <summary>
        ///   解说者
        /// </summary>
        public string Voiceover { get; set; }
        /// <summary>
        ///   导演
        /// </summary>
        public string Director { get; set; }
        /// <summary>
        ///   内容物
        /// </summary>
        [JsonPropertyName("box_Contents")]
        public string BoxContents { get; set; }
        /// <summary>
        ///   字幕语言
        /// </summary>
        [JsonPropertyName("Language_Subtitled")]
        public string LanguageSubtitled { get; set; }
        /// <summary>
        ///   介质
        /// </summary>
        public string Media { get; set; }
        /// <summary>
        ///   屏幕比例
        /// </summary>
        [JsonPropertyName("Screen_Ratio")]
        public string ScreenRatio { get; set; }
        /// <summary>
        ///   封面图
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        ///   集数
        /// </summary>
        public string Episode { get; set; }
        /// <summary>
        ///   文像进字
        /// </summary>
        [JsonPropertyName("Mvd_Wxjz")]
        public string MvdWxjz { get; set; }
        /// <summary>
        ///   发行公司
        /// </summary>
        [JsonPropertyName("Publishing_Company")]
        public string PublishingCompany { get; set; }
        /// <summary>
        ///   ISRC
        /// </summary>
        public string ISRC { get; set; }
        /// <summary>
        ///   演唱者
        /// </summary>
        public string Singer { get; set; }
        /// <summary>
        ///   发音语言
        /// </summary>
        [JsonPropertyName("Language_Pronunciation")]
        public string LanguagePronunciation { get; set; }
        /// <summary>
        ///   出品公司
        /// </summary>
        [JsonPropertyName("Production_Company")]
        public string ProductionCompany { get; set; }
        /// <summary>
        ///   音频格式(中文)
        /// </summary>
        [JsonPropertyName("Audio_Encoding_Chinese")]
        public string AudioEncodingChinese { get; set; }
        /// <summary>
        ///   作词
        /// </summary>
        public string Authors { get; set; }
        /// <summary>
        ///   内容描述
        /// </summary>
        public string ContentDesc { get; set; }
        /// <summary>
        ///   又名
        /// </summary>
        public string Aka { get; set; }
        /// <summary>
        ///   区码
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        ///   版权提供
        /// </summary>
        public string Copyright { get; set; }
        /// <summary>
        ///   包装
        /// </summary>
        public string Package { get; set; }
        /// <summary>
        ///   编辑推荐
        /// </summary>
        public string EditerDesc { get; set; }
        /// <summary>
        ///   作曲
        /// </summary>
        public string Compose { get; set; }
        /// <summary>
        ///   编剧
        /// </summary>
        public string Screenwriter { get; set; }
        /// <summary>
        ///   目录
        /// </summary>
        public string Catalogue { get; set; }
        /// <summary>
        ///   配音语言
        /// </summary>
        [JsonPropertyName("Language_Dubbed")]
        public string LanguageDubbed { get; set; }
        /// <summary>
        ///   指南？
        /// </summary>
        public string Manual { get; set; }
        /// <summary>
        ///   片长
        /// </summary>
        public string Length { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("material_Description")]
        public string MaterialDescription { get; set; }
        /// <summary>
        ///   上映日期
        /// </summary>
        public string ReleaseDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Comments { get; set; }
    }
}
