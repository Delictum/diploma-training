object Form10: TForm10
  Left = 0
  Top = 0
  BorderIcons = []
  ClientHeight = 145
  ClientWidth = 240
  Color = clWhite
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  Visible = True
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 73
    Top = 24
    Width = 105
    Height = 13
    Caption = #1059#1075#1072#1076#1072#1081' '#1080#1089#1087#1086#1083#1085#1080#1090#1077#1083#1103
  end
  object Label2: TLabel
    Left = 51
    Top = 56
    Width = 136
    Height = 13
    Caption = #1042#1099#1087#1086#1083#1085#1080#1083' '#1043#1072#1085#1077#1074#1080#1095' '#1040#1085#1076#1088#1077#1081
  end
  object Label3: TLabel
    Left = 64
    Top = 94
    Width = 124
    Height = 13
    Caption = #1059#1095#1072#1097#1080#1081#1089#1103' 25 '#1055#1054' '#1075#1088#1091#1087#1087#1099
  end
  object ProgressBar1: TProgressBar
    Left = 48
    Top = 113
    Width = 150
    Height = 17
    TabOrder = 0
    Visible = False
  end
  object Timer1: TTimer
    OnTimer = Timer1Timer
    Left = 8
    Top = 8
  end
end
