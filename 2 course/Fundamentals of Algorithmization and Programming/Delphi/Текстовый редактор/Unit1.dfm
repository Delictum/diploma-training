object Form1: TForm1
  Left = 0
  Top = 0
  Caption = #1058#1077#1082#1089#1090#1086#1074#1099#1081' '#1088#1077#1076#1072#1082#1090#1086#1088
  ClientHeight = 144
  ClientWidth = 192
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  Menu = MainMenu1
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object RichEdit1: TRichEdit
    Left = 0
    Top = 0
    Width = 192
    Height = 144
    Align = alClient
    Font.Charset = RUSSIAN_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    Lines.Strings = (
      '')
    ParentFont = False
    TabOrder = 0
    Zoom = 100
    ExplicitLeft = 192
    ExplicitTop = 120
    ExplicitWidth = 185
    ExplicitHeight = 89
  end
  object MainMenu1: TMainMenu
    Left = 32
    Top = 16
    object N1: TMenuItem
      Caption = #1060#1072#1081#1083
      object N2: TMenuItem
        Caption = #1054#1090#1082#1088#1099#1090#1100
        OnClick = N2Click
      end
      object N3: TMenuItem
        Caption = #1057#1086#1093#1088#1072#1085#1080#1090#1100
        OnClick = N3Click
      end
      object N4: TMenuItem
        Caption = #1042#1099#1093#1086#1076
        OnClick = N4Click
      end
    end
    object N5: TMenuItem
      Caption = #1055#1088#1072#1074#1082#1072
      object N6: TMenuItem
        Caption = #1064#1088#1080#1092#1090
        OnClick = N6Click
      end
      object N7: TMenuItem
        Caption = #1054#1095#1080#1089#1090#1080#1090#1100
        OnClick = N7Click
      end
      object N10: TMenuItem
        Caption = #1054#1090#1084#1077#1085#1080#1090#1100
        OnClick = N10Click
      end
    end
    object N8: TMenuItem
      Caption = #1054' '#1087#1088#1086#1075#1088#1072#1084#1084#1077
      object N9: TMenuItem
        Caption = #1054#1073' '#1072#1074#1090#1086#1088#1077
        OnClick = N9Click
      end
    end
  end
  object OpenDialog1: TOpenDialog
    DefaultExt = '*.rtf'
    Filter = #1060#1072#1081#1083' RTF|*.rtf'
    Left = 112
    Top = 16
  end
  object SaveDialog1: TSaveDialog
    DefaultExt = '*.rtf'
    Filter = #1060#1072#1081#1083' RTF|*.rtf'
    Left = 112
    Top = 80
  end
  object FontDialog1: TFontDialog
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    Left = 32
    Top = 80
  end
end
