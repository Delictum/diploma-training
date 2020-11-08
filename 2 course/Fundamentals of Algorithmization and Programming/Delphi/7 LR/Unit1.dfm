object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 412
  ClientWidth = 773
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object Memo2: TMemo
    Left = 8
    Top = 247
    Width = 185
    Height = 157
    Lines.Strings = (
      'Bugs')
    TabOrder = 0
  end
  object Button2: TButton
    Left = 256
    Top = 291
    Width = 75
    Height = 25
    Caption = 'Open'
    TabOrder = 1
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 256
    Top = 353
    Width = 75
    Height = 25
    Caption = 'Clear'
    TabOrder = 2
    OnClick = Button3Click
  end
  object Button5: TButton
    Left = 393
    Top = 353
    Width = 75
    Height = 25
    Caption = 'Sort'
    TabOrder = 3
    OnClick = Button5Click
  end
  object Button1: TButton
    Left = 393
    Top = 291
    Width = 75
    Height = 25
    Caption = 'Save'
    TabOrder = 4
    OnClick = Button1Click
  end
  object Memo1: TMemo
    Left = 535
    Top = 247
    Width = 185
    Height = 157
    Lines.Strings = (
      'List:')
    TabOrder = 5
  end
  object StringGrid1: TStringGrid
    Left = 8
    Top = 8
    Width = 753
    Height = 233
    ColCount = 7
    DefaultColWidth = 120
    DefaultRowHeight = 30
    FixedColor = clActiveCaption
    FixedRows = 0
    Options = [goFixedVertLine, goFixedHorzLine, goVertLine, goHorzLine, goRangeSelect, goEditing]
    TabOrder = 6
    OnKeyPress = StringGrid1KeyPress
    ColWidths = (
      120
      120
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
end
