object Form3: TForm3
  Left = 0
  Top = 0
  Caption = 'Registration'
  ClientHeight = 190
  ClientWidth = 291
  Color = clInactiveCaption
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 15
    Top = 43
    Width = 67
    Height = 13
    Caption = 'Create a login'
  end
  object Label2: TLabel
    Left = 15
    Top = 94
    Width = 91
    Height = 13
    Caption = 'Create a password'
  end
  object Edit1: TEdit
    Left = 112
    Top = 40
    Width = 121
    Height = 21
    TabOrder = 0
  end
  object Edit2: TEdit
    Left = 112
    Top = 91
    Width = 121
    Height = 21
    PasswordChar = '*'
    TabOrder = 1
  end
  object Button1: TButton
    Left = 136
    Top = 136
    Width = 75
    Height = 25
    Caption = 'Registr'
    TabOrder = 2
    OnClick = Button1Click
  end
end
