object Form2: TForm2
  Left = 0
  Top = 0
  Caption = #1040#1056#1052
  ClientHeight = 448
  ClientWidth = 798
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
    Left = 18
    Top = 8
    Width = 753
    Height = 233
    DefaultColWidth = 120
    DefaultRowHeight = 30
    FixedColor = clActiveCaption
    FixedRows = 0
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 0
    OnKeyPress = StringGrid1KeyPress
    ColWidths = (
      120
      120
      120
      120
      120)
    RowHeights = (
      30
      30
      30
      30
      30)
  end
  object Button1: TButton
    Left = 24
    Top = 285
    Width = 75
    Height = 25
    Caption = #1057#1086#1093#1088#1072#1085#1080#1090#1100
    TabOrder = 1
    OnClick = Button1Click
  end
  object Memo1: TMemo
    Left = 424
    Top = 247
    Width = 353
    Height = 193
    ScrollBars = ssVertical
    TabOrder = 2
  end
  object Button2: TButton
    Left = 24
    Top = 247
    Width = 75
    Height = 25
    Caption = #1054#1090#1082#1088#1099#1090#1100
    TabOrder = 3
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 24
    Top = 327
    Width = 75
    Height = 25
    Caption = #1054#1095#1080#1089#1090#1080#1090#1100
    TabOrder = 4
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 24
    Top = 405
    Width = 75
    Height = 25
    Caption = '+'#1057#1090#1088#1086#1082#1072
    TabOrder = 5
    OnClick = Button4Click
  end
  object Button5: TButton
    Left = 18
    Top = 365
    Width = 89
    Height = 25
    Caption = #1057#1086#1088#1090#1080#1088#1086#1074#1082#1072
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = [fsBold]
    ParentFont = False
    TabOrder = 6
    OnClick = Button5Click
  end
  object Memo2: TMemo
    Left = 128
    Top = 247
    Width = 273
    Height = 193
    ScrollBars = ssVertical
    TabOrder = 7
  end
  object Button6: TButton
    Left = 129
    Top = 424
    Width = 16
    Height = 15
    TabOrder = 8
    OnClick = Button6Click
  end
end
