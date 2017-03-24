### ClientEngine [![Build Status](https://travis-ci.org/weitaoxiao/ClientEngine.svg)](https://travis-ci.org/weitaoxiao/ClientEngine)
---

这是一个C#皮肤组件 ,项目附带两个Demo, 你可以根据这两个例子量身定做你需要的UI皮肤


首先必须定义一个子类继承 TitleRender, 例如 :

```csharp
    public class CustomTitleRender : TitleRender
    {
    }

```

Then , the form is inherited UIForm, the following code:
```csharp
    public  class CustomForm : UIForm<DefaultFormRender, CustomTitleRender>
    {
    }

```

以上是一些参考代码，如有不明白，加入QQ群：302961959

##Power By 

![mahua](http://b310-img.qiniudn.com/web/logo.png)