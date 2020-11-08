object FormNew: TFormNew
  Left = 0
  Top = 0
  Caption = 'FormNew'
  ClientHeight = 156
  ClientWidth = 337
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Bevel1: TBevel
    Left = 168
    Top = 0
    Width = 2
    Height = 160
  end
  object DBEdit1: TDBEdit
    Left = 8
    Top = 34
    Width = 121
    Height = 21
    DataField = 'typenebestela'
    DataSource = FormProg.DataSource1
    TabOrder = 0
  end
  object DBEdit2: TDBEdit
    Left = 208
    Top = 34
    Width = 121
    Height = 21
    BiDiMode = bdRightToLeft
    DataField = 'galak_name'
    DataSource = FormProg.DataSource1
    ParentBiDiMode = False
    TabOrder = 1
  end
  object Button1: TButton
    Left = 32
    Top = 61
    Width = 75
    Height = 25
    Caption = #1044#1086#1073#1072#1074#1080#1090#1100
    TabOrder = 2
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 24
    Top = 92
    Width = 89
    Height = 25
    Caption = #1056#1077#1076#1072#1082#1090#1080#1088#1086#1074#1072#1090#1100
    TabOrder = 3
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 32
    Top = 123
    Width = 75
    Height = 25
    Caption = #1059#1076#1072#1083#1080#1090#1100
    TabOrder = 4
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 232
    Top = 61
    Width = 75
    Height = 25
    Caption = #1044#1086#1073#1072#1074#1080#1090#1100
    TabOrder = 5
    OnClick = Button4Click
  end
  object Button5: TButton
    Left = 224
    Top = 92
    Width = 89
    Height = 25
    Caption = #1056#1077#1076#1072#1082#1090#1080#1088#1086#1074#1072#1090#1100
    TabOrder = 6
    OnClick = Button5Click
  end
  object Button6: TButton
    Left = 232
    Top = 123
    Width = 75
    Height = 25
    Caption = #1059#1076#1072#1083#1080#1090#1100
    TabOrder = 7
    OnClick = Button6Click
  end
  object DBLCBTypeNebesTela: TDBLookupComboBox
    Left = 8
    Top = 7
    Width = 145
    Height = 21
    KeyField = 'typenebestela'
    ListField = 'typenebestela'
    ListSource = Form8.DataSource2
    TabOrder = 8
  end
  object DBLCBGolak: TDBLookupComboBox
    Left = 184
    Top = 7
    Width = 145
    Height = 21
    BiDiMode = bdRightToLeft
    KeyField = 'galak_name'
    ListField = 'galak_name'
    ListSource = Form8.DataSource3
    ParentBiDiMode = False
    TabOrder = 9
  end
end
