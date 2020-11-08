object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Graphics editor'
  ClientHeight = 298
  ClientWidth = 365
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  PixelsPerInch = 96
  TextHeight = 13
  object Pic: TPaintBox
    Left = 0
    Top = 0
    Width = 365
    Height = 298
    Align = alClient
    OnMouseDown = PicMouseDown
    OnMouseMove = PicMouseMove
    OnMouseUp = PicMouseUp
    OnPaint = PicPaint
    ExplicitLeft = 232
    ExplicitTop = 112
    ExplicitWidth = 105
    ExplicitHeight = 105
  end
  object ComboBox1: TComboBox
    Left = 268
    Top = 8
    Width = 89
    Height = 21
    TabOrder = 0
    Text = 'Color'
    OnChange = ComboBox1Change
    Items.Strings = (
      'Black'
      'Gray'
      'Blue'
      'Red'
      'Green')
  end
  object ComboBox2: TComboBox
    Left = 268
    Top = 56
    Width = 89
    Height = 21
    TabOrder = 1
    Text = 'Width'
    OnChange = ComboBox2Change
    Items.Strings = (
      '1'
      '2'
      '3'
      '4'
      '5')
  end
end
