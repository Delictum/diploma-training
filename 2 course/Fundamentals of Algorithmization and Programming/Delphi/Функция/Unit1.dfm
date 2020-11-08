object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Function'
  ClientHeight = 298
  ClientWidth = 560
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object PaintBox1: TPaintBox
    Left = 32
    Top = 8
    Width = 500
    Height = 140
  end
  object RadioButton1: TRadioButton
    Left = 32
    Top = 218
    Width = 113
    Height = 17
    Caption = 'Sin'
    Checked = True
    TabOrder = 0
    TabStop = True
  end
  object RadioButton2: TRadioButton
    Left = 32
    Top = 249
    Width = 113
    Height = 17
    Caption = 'Cos'
    TabOrder = 1
  end
  object CheckBox1: TCheckBox
    Left = 32
    Top = 187
    Width = 97
    Height = 17
    Caption = 'All'
    TabOrder = 2
  end
  object Button1: TButton
    Left = 457
    Top = 183
    Width = 75
    Height = 25
    Caption = 'Start'
    TabOrder = 3
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 457
    Top = 214
    Width = 75
    Height = 25
    Caption = 'Pause'
    TabOrder = 4
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 457
    Top = 245
    Width = 75
    Height = 25
    Caption = 'Exit'
    TabOrder = 5
    OnClick = Button3Click
  end
  object TrackBar1: TTrackBar
    Left = 216
    Top = 245
    Width = 150
    Height = 45
    Max = 50
    Min = 1
    Position = 1
    TabOrder = 6
  end
end
