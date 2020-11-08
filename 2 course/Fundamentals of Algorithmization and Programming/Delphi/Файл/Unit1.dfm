object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 298
  ClientWidth = 744
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object StringGrid1: TStringGrid
    Left = 8
    Top = 8
    Width = 481
    Height = 180
    TabOrder = 0
    OnKeyPress = StringGrid1KeyPress
    ColWidths = (
      64
      81
      81
      126
      120)
  end
  object Memo1: TMemo
    Left = 524
    Top = 8
    Width = 185
    Height = 282
    Lines.Strings = (
      'List:')
    TabOrder = 1
  end
  object Button1: TButton
    Left = 390
    Top = 203
    Width = 75
    Height = 25
    Caption = 'Save'
    TabOrder = 2
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 253
    Top = 203
    Width = 75
    Height = 25
    Caption = 'Open'
    TabOrder = 3
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 253
    Top = 265
    Width = 75
    Height = 25
    Caption = 'Clear'
    TabOrder = 4
    OnClick = Button3Click
  end
  object Button5: TButton
    Left = 390
    Top = 265
    Width = 75
    Height = 25
    Caption = 'Sort'
    TabOrder = 5
    OnClick = Button5Click
  end
  object Memo2: TMemo
    Left = 8
    Top = 201
    Width = 185
    Height = 89
    Lines.Strings = (
      'Bugs')
    TabOrder = 6
  end
end
