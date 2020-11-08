object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Sign In'
  ClientHeight = 172
  ClientWidth = 307
  Color = clGradientInactiveCaption
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
    Left = 52
    Top = 65
    Width = 25
    Height = 13
    Caption = 'Login'
  end
  object Label2: TLabel
    Left = 52
    Top = 92
    Width = 46
    Height = 13
    Caption = 'Password'
  end
  object Label3: TLabel
    Left = 104
    Top = 32
    Width = 121
    Height = 13
    Caption = 'Enter login and password'
  end
  object Label4: TLabel
    Left = 8
    Top = 7
    Width = 108
    Height = 19
    Cursor = crArrow
    Caption = 'Hello, stranger!'
    Color = clAqua
    Font.Charset = RUSSIAN_CHARSET
    Font.Color = clGray
    Font.Height = -16
    Font.Name = 'Yu Gothic'
    Font.Style = [fsItalic]
    ParentColor = False
    ParentFont = False
  end
  object Edit1: TEdit
    Left = 104
    Top = 62
    Width = 121
    Height = 21
    TabOrder = 0
  end
  object Edit2: TEdit
    Left = 104
    Top = 89
    Width = 121
    Height = 21
    PasswordChar = '*'
    TabOrder = 1
  end
  object Button1: TButton
    Left = 126
    Top = 116
    Width = 75
    Height = 25
    Caption = 'Log In'
    TabOrder = 2
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 23
    Top = 116
    Width = 75
    Height = 25
    Caption = 'Registration'
    TabOrder = 3
    OnClick = Button2Click
  end
  object ProgressBar1: TProgressBar
    Left = 23
    Top = 147
    Width = 263
    Height = 17
    TabOrder = 4
  end
  object Timer1: TTimer
    Enabled = False
    OnTimer = Timer1Timer
    Left = 248
    Top = 104
  end
end
