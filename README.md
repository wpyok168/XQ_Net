# XQ_Net_SDK
先驱C# SDK

XQ.Net.SDK来自https://gitee.com/heerkaisair/XQ.Net

FZMsTool是简单Demo，可删除

使用说明：

   创建自己的项目，如FZMsTool，并引用XQ.Net.SDK--->在XQ_Net项目中引用自己创建的项目--->在自己的项目创建类实现XQ.Net.SDK接口（Interface），如RecPrivateMsg--->在XQ_Net项目RegisterCore注册

XQ_Net项目\Core\LoadLib类中可以配置插件说明XQ_Create,配置项目中的appInfo.name注意保持和程序集名称一致，否则先驱无法正常加载插件

  XQ_Net是启动项目，从github下载后，请重新NuGet相关引用



