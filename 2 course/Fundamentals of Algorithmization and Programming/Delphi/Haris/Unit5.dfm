object Form5: TForm5
  Left = 0
  Top = 0
  Caption = 'Font'
  ClientHeight = 107
  ClientWidth = 401
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  PixelsPerInch = 96
  TextHeight = 13
  object Button1: TButton
    Left = 310
    Top = 72
    Width = 75
    Height = 25
    Caption = 'Done'
    TabOrder = 0
    OnClick = Button1Click
  end
  object ComboBox2: TComboBox
    Left = 16
    Top = 24
    Width = 113
    Height = 21
    TabOrder = 1
    Text = 'Tracing'
    OnChange = ComboBox2Change
    Items.Strings = (
      'Common'
      'Bold'
      'Italic'
      'Bold-Italic'
      'Underlined')
  end
  object ComboBox3: TComboBox
    Left = 176
    Top = 24
    Width = 73
    Height = 21
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 2
    Text = 'Size'
    OnChange = ComboBox3Change
    Items.Strings = (
      '8'
      '10'
      '12'
      '18')
  end
  object ComboBox1: TComboBox
    Left = 296
    Top = 24
    Width = 89
    Height = 21
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 3
    Text = 'Color'
    OnChange = ComboBox1Change
    Items.Strings = (
      'Black'
      'Gray'
      'Green'
      'Yellow'
      'Red')
  end
end
