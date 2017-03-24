### ClientEngine  [![Build Status](https://travis-ci.org/weitaoxiao/ClientEngine.svg)](https://travis-ci.org/weitaoxiao/ClientEngine)
---
[中文文档](README_cn.md)

This is a C # skin components , the project comes with two demo, you can modify the effect you want according to your actual needs


First you need to define a subclass inherits TitleRender, for example :

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

Is a simple to define a custom form , it's so cool,is it? 


##Power By 

![mahua](http://b310-img.qiniudn.com/web/logo.png)