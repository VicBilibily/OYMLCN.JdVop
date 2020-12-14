<h1 align="center"> 大客户开放平台VOP实物接口 </h1><div align="center">

![Language](https://img.shields.io/github/languages/top/VicBilibily/OYMLCN.JdVop?label=C%239.0&style=flat-square) 
[![nuget](https://img.shields.io/nuget/v/OYMLCN.JdVop.svg?style=flat-square)](https://www.nuget.org/packages/OYMLCN.JdVop) 
[![stats](https://img.shields.io/nuget/dt/OYMLCN.JdVop.svg?style=flat-square)](https://www.nuget.org/stats/packages/OYMLCN.JdVop?groupby=Version) 
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/VicBilibily/OYMLCN.JdVop/blob/main/LICENSE)

</div>

### 大客户开放平台VOP实物接口
* 开发语言：C#9.0
* 文档版本：2.0.5

#### 接口命名规则
1. 接口根据请求地址的末尾调用名称命名，全部公开接口均以以异步方式调用，方法名称 `Async` 结尾。
2. 接口调用除订单下单接口提交内容较多拆分为多个实体参数，其他均按文档是否非空设置调用接口参数。

#### 开始使用

1. 在项目中通过 `NuGet` 安装 `OYMLCN.JdVop` 程序包。
2. 引用命名空间 `OYMLCN.JdVop`（可选）。
3. 调用对应接口 `OYMLCN.JdVop.JdVopApi.xxxAsync()`。

#### 使用说明

1. 直接调用静态接口方法：`OYMLCN.JdVop.JdVopApi.xxxAsync(token, params ....)`。
``` csharp
var res = await JdVopApi.Oauth2AccessTokenAsync(TestHelper.VopClient);
var rsp = await JdVopApi.GetProvinceAsync(res.Result);
```
2. 实例化 `JdVopApi` 后调用实例内方法，实例下的接口方法无需传递`token`，默认使用实例化时提供的`token`。
``` csharp
var res = await JdVopApi.Oauth2AccessTokenAsync(TestHelper.VopClient);
var api = new JdVopApi(res.Result);
var rsp = await api.GetProvinceAsync();
```

#### 实现模块
- [x] 授权API接口
- [x] 地址api接口
- [x] 商品API接口
- [x] 价格API接口
- [x] 订单API接口
- [x] 支付API接口
- [ ] 售后API接口
- [ ] 发票API接口
- [ ] 信息推送api接口

#### 模块接口

| 接口名称 | 实现接口 |
| :---   | :--- |
| 2、授权API接口 |  |
| 2.3 获取Access Token | Oauth2AccessTokenAsync |
| 2.4 刷新 Access Token | Oauth2RefreshATokenAsync |
| 3、地址api接口 |  |
| 3.1 查询一级地址 | GetProvinceAsync |
| 3.2 查询二级地址 | GetCityAsync |
| 3.3 查询三级地址 | GetCountyAsync |
| 3.4 查询四级地址 | GetTownAsync |
| 3.5 验证地址有效性 | CheckAreaAsync |
| 3.6 地址详情转换京东地址编码 | GetJDAddressFromAddressAsync |
| 4、商品API接口 |  |
| 4.1 查询商品池编号 | GetPageNumAsync |
| 4.2 查询池内商品编号 | GetSkuByPageAsync |
| 4.3 查询商品详情 | GetDetailAsync |
| 4.4 查询商品图片 | SkuImageAsync |
| 4.5 查询商品上下架状态 | SkuStateAsync |
| 4.6 验证商品可售性 | ProductCheckAsync |
| 4.7 查询商品区域购买限制 | CheckAreaLimitAsync |
| 4.8 查询赠品信息 | GetSkuGiftAsync |
| 4.9 查询商品延保 | GetYanbaoSkuAsync |
| 4.10 验证货到付款 | GetIsCodAsync |
| 4.11 批量验证货到付款 | GetBatchIsCodAsync |
| 4.12 搜索商品 | SearchAsync |
| 4.13 查询同类商品 | GetSimilarSkuAsync |
| 4.14 查询分类信息 | GetCategoryAsync |
| 4.15 查询商品状态验证统一接口信息 | TotalCheckAsync |
| 5、价格API接口 |  |
| 5.1 查询商品售卖价 | GetSellPriceAsync |
| 6、库存API接口 |  |
| 6.1 查询商品库存 | GetNewStockByIdAsync |
| 7、订单API接口 |  |
| 7.1 查询运费 | GetFreightAsync |
| 7.2 查询预约日历 | PromiseCalendarAsync |
| 7.3 提交订单 | SubmitOrderAsync |
| 7.4 反查订单 | SelectJdOrderIdByThirdOrderAsync |
| 7.5 确认预占库存订单 | ConfirmOrderAsync |
| 7.6 取消未确认订单 | OrderCancelAsync |
| 7.7 查询订单详情 | SelectJdOrderAsync |
| 7.8 查询配送信息 | OrderTrackAsync |
| 7.9 确认收货 | ConfirmReceivedAsync |
| 7.10 更新采购单号 | SaveOrUpdatePoNoAsync |
| 7.11 查询新建订单列表 | CheckNewOrderAsync |
| 7.12 查询妥投订单列表 | CheckDlokOrderAsync |
| 7.13 查询拒收订单列表 | CheckRefuseOrderAsync |
| 7.14 查询完成订单列表 | CheckCompleteOrderAsync |
| 7.15 查询配送预计送达时间 | GetPromiseTipsAsync |
| 7.16 批量确认收货接口 | BatchConfirmReceivedAsync |
| 8、支付API接口 |  |
| 8.1 查询余额 | GetUnionBalanceAsync |
| 8.2 查询余额变动明细 | GetBalanceDetailAsync |
| 8.3 发起支付接口 | DoPayAsync |
| 9、售后API接口 | Pending |
| 10、发票API接口 | Pending |
| 11、信息推送api接口 | Developing |


#### 单元测试
1. 在测试项目的用户机密信息中添加配置信息。
```
"VopClient": {
  "ClientId": "",
  "ClientSecret": "",
  "UserName": "",
  "Password": ""
}
```
2. 修改 `TestHelper.Config.cs` 中的测试配置后按需执行单元测试方法。