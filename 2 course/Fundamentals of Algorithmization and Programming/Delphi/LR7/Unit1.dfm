object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 503
  ClientWidth = 769
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
    TabOrder = 0
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
  object Memo2: TMemo
    Left = 8
    Top = 247
    Width = 185
    Height = 157
    Lines.Strings = (
      'Bugs')
    TabOrder = 1
  end
  object Button2: TButton
    Left = 256
    Top = 291
    Width = 75
    Height = 25
    Caption = 'Open'
    TabOrder = 2
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 256
    Top = 353
    Width = 75
    Height = 25
    Caption = 'Clear'
    TabOrder = 3
    OnClick = Button3Click
  end
  object Button5: TButton
    Left = 441
    Top = 353
    Width = 75
    Height = 25
    Caption = 'Sort'
    TabOrder = 4
    OnClick = Button5Click
  end
  object Button1: TButton
    Left = 441
    Top = 291
    Width = 75
    Height = 25
    Caption = 'Save'
    TabOrder = 5
    OnClick = Button1Click
  end
  object Memo1: TMemo
    Left = 576
    Top = 247
    Width = 185
    Height = 157
    Lines.Strings = (
      'List:')
    TabOrder = 6
  end
  object Edit1: TEdit
    Left = 336
    Top = 293
    Width = 99
    Height = 21
    ReadOnly = True
    TabOrder = 7
  end
  object Button4: TButton
    Left = 344
    Top = 353
    Width = 83
    Height = 25
    Caption = 'New cell'
    TabOrder = 8
    OnClick = Button4Click
  end
  object OpenDialog1: TOpenDialog
    Left = 32
    Top = 424
  end
end
