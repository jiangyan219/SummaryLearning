------该项目Demo创建于2018年02月26日
主要目的是为了学习WPF中，关于资源样式、风格的设计和引用；

设计步骤：
1.首先创建一个WPF项目，然后添加MVVM引用，用nuget添加，这个过程中可能会报错，注意引用稳定版本的mvvm动态库；
2.创建一个公共引用的类库，然后在里面的添加一个放置各种资源文件(xaml)的文件夹，这里的目的很明确，
  为了实现 项目 - 跟 - 资源样式 的分离，即为了解耦，因为将来你可能还会创建多个项目，每个项目都会引用到资源样式，
  如果每个项目中都独自分别各自添加一套资源样式，那么这种相同资源重复存在于每个项目中，显然是浪费的，不符合程序
  设计中的 避免重复原则(DRY),为了解决这一问题，方法呢就是 将资源样式文件 统一放到一个公共文件夹中，这样每个项目都可以引用它们，
  然而，就目前为止，我单独创建一个文件件，希望放置几个样式资源文件，然后再让其他项目文件引用它们，却并没有找个一个可行的方法，
  于是，只能创建一个公共类库了，在公共类库中再添加一个文件夹（包含很多资源样式文件）的方法了，因为该方法至少是可行的。
3.关于资源样式文件，详细见Base.xaml、Button.xaml、Style.xaml文件，里面有很多注意事项要留意
4.在项目中如何引用呢？方法就是通过在项目的App.xaml文件中，配置资源字典ResourceDictionary，并采用合并字典的方式来处理，这样
  就可以同时引用很多资源跟样式了，注意引用的技巧，比如<ResourceDictionary Source="/WPF.Style;component/Default/Style.xaml"></ResourceDictionary>

  通过以上4步，就基本上可以实现资源样式的解耦引用了。

几个注意事项：
1.在MainWindow.xaml文件中，我放置了连个按钮，一个是Button.xaml风格、一个是Style风格，我们可以看到Button.xaml风格没有做任何处理，就变风格样式了，
  而Style风格中却有一句引用静态资源样式的语句Style="{StaticResource CommonButtonStyle}"，这里要说明两点：
  a.如果Style风格不加Style="{StaticResource CommonButtonStyle}"这一句，那么它风格必然跟Button.xaml风格一样，这是由于TargetType="{x:Type Button}"的缘故；
  b.这是由于在Style.xaml资源文件中，加了关键字key -   x:Key="CommonButtonStyle"，如果没有这个key值限制，那么button控件的样式就两个了，
    该用哪个就会乱掉，当然这个项目中它默认调用的Button.xaml资源样式里的方格。

  通过a、b两个小的注意事项，我们就能非常轻松的事项给整个项目某个控件，比如Button控件，定义一个新风格，又可以通过 静态资源样式 引用，在某些个别的地方，
  给特定的Button通过添加Style="{StaticResource CommonButtonStyle}"来实现切换特定风格。