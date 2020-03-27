# Loader
   Cross platform library to change loader image.
   

You can integrate the loader in Xamarin Form application using following code:

Shared Code -

```c#
using Xamarians;

...

StackLayout loaderLayout = await Loader.RegisterLoader(this, Image name with extention, Message to show with loader);

...

loaderLayout.IsVisible = true; //This will present the loader layout.

...

loaderLayout.IsVisible = false; //This will hide the loader layout.
```

Android -

1. Add loader image in Assets folder.

2. Add dependency service as given below.

```c#
using Xamarians.Interfaces;

...

[assembly: Xamarin.Forms.Dependency(typeof(GifImageUrl))]

...

public class GifImageUrl : IGif
{
    public string GetGifImageUrl()
    {            
        return "file:///android_asset/";
    }
}
```

iOS -

1. Add loader image in the Resources folder.

2. Add dependency service as given below.

```c#
using Xamarians.Interfaces;

...

[assembly: Xamarin.Forms.Dependency(typeof(GifImageUrl))]

...

public class GifImageUrl : IGif
{
    public string GetGifImageUrl()
    {            
        return Foundation.NSBundle.MainBundle.BundlePath;
    }
}
```
