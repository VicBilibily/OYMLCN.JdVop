using OYMLCN.JdVop.Models;

namespace OYMLCN.JdVop.Test
{
    static partial class TestHelper
	{
		/// <summary>
		///   普通实物商品SKU编码
		/// </summary>
		// Apple iPhone 12 mini (A2400) 64GB 蓝色 手机 支持移动联通电信5G
		public const string SkuNormal1 = "100009077455";
		internal const string SkuNormal1BrandName = "Apple";
		internal const decimal SkuNormal1Price = 5499M;

		/// <summary>
		///   普通实物商品SKU编码
		/// </summary>
		// 三星（SAMSUNG）55英寸 RU7520 4K超高清 杜比音效 HDR画质增强 教育资源智能液晶电视机UA55RU7520JXXZ
		public const string SkuNormal2 = "100006907658";
		internal const decimal SkuNormal2Price = 2499M;
		/// <summary>
		///   家电实物商品SKU编码
		/// </summary>
		// 海尔（Haier）滚筒洗衣机全自动 巴氏杀菌除菌率99% 10KG变频节能 EG10012B509G
		public const string SkuNormal3 = "100005668834";
		internal const decimal SkuNormal3Price = 2499M;
		/// <summary>
		///   超重实物商品SKU编码
		/// </summary>
		// 农夫山泉 饮用水 饮用天然水 透明装4L*6桶 整箱装 桶装水
		public const string SkuHeightWeight = "1305498";

		/// <summary>
		///   图书类型商品SKU编码
		/// </summary>
		// 世界简史
		public const string SkuBook = "12591950";
		internal const string SkuBookAuthor = "[英]威尔斯";
		internal const string SkuBookISBN = "9787516822869";

		/// <summary>
		///   音像类型商品SKU编码
		/// </summary>
		// 张学友：一生拥友（黑胶升级版 CD）
		public const string SkuVideo = "20061130";
		internal const string SkuVideoSinger = "张学友";

		/// <summary>
		///   包含赠品的SKU编码
		/// </summary>
		// 华为 HUAWEI P40 Pro 麒麟990 5G SoC芯片 5000万超感知徕卡四摄 50倍数字变焦 8GB+256GB零度白全网通5G手机
		public const string SkuHasGift = "100012015172";

		/// <summary>
		///   京东地址编码（广东-佛山市-顺德区-均安镇）
		/// </summary>
		public static JDAddress JDArress = new JDAddress()
		{
			ProvinceId = 19,
			Province = "广东",
			CityId = 1666,
			City = "佛山市",
			CountyId = 1669,
			County = "顺德区",
			TownId = 52082,
			Town = "均安镇",
		};
		internal const string JDAddressTest = "顺德区均安镇天连小学";


		public const string OrderSku1 = "3547614"; // 得力（deli）新国标安全插座 插排/插线板/接线板/排插/拖线板 总控开关 儿童保护门 8组合孔5米 18239
		public const decimal OrderSku1Price = 59.90M;
		public const string OrderSku2 = "3121499"; // 得力（deli）新国标安全插座 插排/插线板/接线板/排插/拖线板 总控开关 儿童保护门 5组合孔3米 18204
		public const decimal OrderSku2Price = 34.90M;
		public const string OrderSku3 = "100001133811"; // 得力（deli）USB智能插座 插排/插线板/接线板/排插/拖线板 3USB接口+4孔 全长3米带保护门 18282-03
		public const decimal OrderSku3Price = 51.90M;
		public const string OrderSku4 = "66690099103"; // 得力（deli）18313-02防滑插座/插排（4位 2米）颜色随机
		public const decimal OrderSku4Price = 36.00M;

		public const long JdOrderNo_Test = 133728691636; // 普通测试订单

	}
}
