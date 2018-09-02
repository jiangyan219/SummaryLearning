  创建于20180226 在AE240调度项目中，测试界面中使用了此技术
  学习自https://www.cnblogs.com/khler/archive/2008/07/04/1235619.html

  注意事项，几个重点：
  1.由于GridSplitter默认Grid.Row=“0”、Grid.Column=“0”，那么它将与Label占用同一列，GridSplitter宽为5像素，它将覆盖Label 5像素。
  2.几个比较的地方
    <GridSplitter Width="5"></GridSplitter> 默认格式是 竖立、靠右边
	<GridSplitter Height="5" HorizontalAlignment="Stretch" VerticalAlignment="Bottom"></GridSplitter> 横着的、底部

  3.交叉分割没有学习到