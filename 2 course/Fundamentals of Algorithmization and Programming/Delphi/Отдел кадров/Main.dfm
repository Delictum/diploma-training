﻿object FName: TFName
  Left = 0
  Top = 0
  Caption = #1054#1090#1076#1077#1083' '#1082#1072#1076#1088#1086#1074
  ClientHeight = 503
  ClientWidth = 917
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesigned
  PixelsPerInch = 96
  TextHeight = 13
  object Splitter1: TSplitter
    Left = 0
    Top = 428
    Width = 917
    Height = 4
    Cursor = crVSplit
    Align = alBottom
  end
  object Panel1: TPanel
    Left = 0
    Top = 57
    Width = 917
    Height = 371
    Align = alClient
    TabOrder = 0
    object DBGrid2: TDBGrid
      Left = 1
      Top = 1
      Width = 915
      Height = 369
      Align = alClient
      DataSource = DSLichData
      ReadOnly = True
      TabOrder = 0
      TitleFont.Charset = DEFAULT_CHARSET
      TitleFont.Color = clWindowText
      TitleFont.Height = -11
      TitleFont.Name = 'Tahoma'
      TitleFont.Style = []
      OnDblClick = DBGrid2DblClick
    end
  end
  object Panel2: TPanel
    Left = 0
    Top = 0
    Width = 917
    Height = 57
    Align = alTop
    TabOrder = 1
    object Bevel1: TBevel
      Left = 287
      Top = 0
      Width = 2
      Height = 57
    end
    object Label1: TLabel
      Left = 295
      Top = 12
      Width = 92
      Height = 13
      Caption = #1055#1086#1080#1089#1082' '#1087#1086' '#1092#1072#1084#1080#1083#1080#1080
    end
    object Bevel2: TBevel
      Left = 529
      Top = 0
      Width = 2
      Height = 57
    end
    object RadioButton1: TRadioButton
      Left = 16
      Top = 21
      Width = 57
      Height = 17
      Caption = #1040#1076#1088#1077#1089
      Checked = True
      TabOrder = 0
      TabStop = True
      OnClick = RadioButton1Click
    end
    object RadioButton2: TRadioButton
      Left = 103
      Top = 21
      Width = 74
      Height = 17
      Caption = #1058#1077#1083#1077#1092#1086#1085#1099
      TabOrder = 1
      OnClick = RadioButton2Click
    end
    object RadioButton3: TRadioButton
      Left = 208
      Top = 21
      Width = 81
      Height = 17
      Caption = #1044#1086#1083#1078#1085#1086#1089#1090#1100
      TabOrder = 2
      OnClick = RadioButton3Click
    end
    object Edit1: TEdit
      Left = 295
      Top = 31
      Width = 121
      Height = 21
      TabOrder = 3
    end
    object Button1: TButton
      Left = 422
      Top = 26
      Width = 75
      Height = 25
      Caption = #1053#1072#1081#1090#1080
      TabOrder = 4
    end
    object Button2: TButton
      Left = 608
      Top = 26
      Width = 91
      Height = 25
      Caption = #1056#1077#1076#1072#1082#1090#1080#1088#1086#1074#1072#1085#1080#1077
      TabOrder = 5
      OnClick = Button2Click
    end
    object Button3: TButton
      Left = 752
      Top = 26
      Width = 105
      Height = 25
      Caption = #1053#1086#1074#1099#1081' '#1089#1086#1090#1088#1091#1076#1085#1080#1082
      TabOrder = 6
      OnClick = Button3Click
    end
  end
  object Panel3: TPanel
    Left = 0
    Top = 432
    Width = 917
    Height = 71
    Align = alBottom
    TabOrder = 2
    object DBGrid1: TDBGrid
      Left = 1
      Top = 1
      Width = 915
      Height = 69
      Align = alClient
      DataSource = DSAdress
      ReadOnly = True
      TabOrder = 0
      TitleFont.Charset = DEFAULT_CHARSET
      TitleFont.Color = clWindowText
      TitleFont.Height = -11
      TitleFont.Name = 'Tahoma'
      TitleFont.Style = []
    end
  end
  object ADOConnection1: TADOConnection
    Connected = True
    ConnectionString = 
      'Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\25 '#1055#1054#1048#1058'\'#1054#1040#1080#1055'\Del' +
      'phi\'#1054#1090#1076#1077#1083' '#1082#1072#1076#1088#1086#1074'\ok.mdb;Persist Security Info=False'
    LoginPrompt = False
    Mode = cmShareDenyNone
    Provider = 'Microsoft.Jet.OLEDB.4.0'
    Left = 624
    Top = 216
  end
  object TLichData: TADOTable
    Active = True
    Connection = ADOConnection1
    CursorType = ctStatic
    TableName = 'LichData'
    Left = 688
    Top = 136
    object TLichDataКлюч: TAutoIncField
      FieldName = #1050#1083#1102#1095
      ReadOnly = True
      Visible = False
    end
    object TLichDataФамилия: TWideStringField
      DisplayWidth = 20
      FieldName = #1060#1072#1084#1080#1083#1080#1103
      Size = 25
    end
    object TLichDataИмя: TWideStringField
      DisplayWidth = 14
      FieldName = #1048#1084#1103
      Size = 25
    end
    object TLichDataОтчество: TWideStringField
      DisplayWidth = 19
      FieldName = #1054#1090#1095#1077#1089#1090#1074#1086
      Size = 25
    end
    object TLichDataПол: TWideStringField
      DisplayWidth = 5
      FieldName = #1055#1086#1083
      Size = 3
    end
    object TLichDataСем_Полож: TBooleanField
      DisplayWidth = 12
      FieldName = #1057#1077#1084'_'#1055#1086#1083#1086#1078
      DisplayValues = #1046#1077#1085#1072#1090';'#1061#1086#1083#1086#1089#1090
    end
    object TLichDataДетей: TWordField
      DisplayWidth = 9
      FieldName = #1044#1077#1090#1077#1081
    end
    object TLichDataДата_Рожд: TDateTimeField
      DisplayWidth = 22
      FieldName = #1044#1072#1090#1072'_'#1056#1086#1078#1076
    end
    object TLichDataДата_Пост: TDateTimeField
      DisplayWidth = 22
      FieldName = #1044#1072#1090#1072'_'#1055#1086#1089#1090
    end
    object TLichDataСтаж: TWordField
      DisplayWidth = 12
      FieldName = #1057#1090#1072#1078
    end
    object TLichDataОбразование: TWideStringField
      DisplayWidth = 14
      FieldName = #1054#1073#1088#1072#1079#1086#1074#1072#1085#1080#1077
      Size = 30
    end
    object TLichDataВоеннообязанный: TBooleanField
      DisplayWidth = 18
      FieldName = #1042#1086#1077#1085#1085#1086#1086#1073#1103#1079#1072#1085#1085#1099#1081
      DisplayValues = #1044#1072';'#1053#1077#1090
    end
  end
  object TDoljnost: TADOTable
    Active = True
    Connection = ADOConnection1
    CursorType = ctStatic
    IndexFieldNames = #1044#1086#1083#1078#1085#1086#1089#1090#1100
    MasterFields = #1050#1083#1102#1095
    MasterSource = DSLichData
    TableName = 'Doljnost'
    Left = 688
    Top = 184
    object TDoljnostСотрудник: TIntegerField
      FieldName = #1057#1086#1090#1088#1091#1076#1085#1080#1082
      Visible = False
    end
    object TDoljnostОтдел: TWideStringField
      FieldName = #1054#1090#1076#1077#1083
      Size = 15
    end
    object TDoljnostДолжность: TWideStringField
      FieldName = #1044#1086#1083#1078#1085#1086#1089#1090#1100
    end
  end
  object TTelphones: TADOTable
    Active = True
    Connection = ADOConnection1
    CursorType = ctStatic
    IndexFieldNames = #1058#1077#1083#1077#1092#1086#1085
    MasterFields = #1050#1083#1102#1095
    MasterSource = DSLichData
    TableName = 'Telephones'
    Left = 688
    Top = 232
    object TTelphonesСотрудник: TIntegerField
      FieldName = #1057#1086#1090#1088#1091#1076#1085#1080#1082
    end
    object TTelphonesТелефон: TWideStringField
      FieldName = #1058#1077#1083#1077#1092#1086#1085
      EditMask = '!\(999\)000-0000;1;_'
      Size = 17
    end
    object TTelphonesПримечание: TWideStringField
      FieldName = #1055#1088#1080#1084#1077#1095#1072#1085#1080#1077
      Size = 10
    end
  end
  object TAdress: TADOTable
    Active = True
    Connection = ADOConnection1
    CursorType = ctStatic
    IndexFieldNames = #1057#1086#1090#1088#1091#1076#1085#1080#1082
    MasterFields = #1050#1083#1102#1095
    MasterSource = DSLichData
    TableName = 'Adres'
    Left = 688
    Top = 280
    object TAdressСотрудник: TIntegerField
      FieldName = #1057#1086#1090#1088#1091#1076#1085#1080#1082
    end
    object TAdressСтрана: TWideStringField
      FieldName = #1057#1090#1088#1072#1085#1072
      Size = 15
    end
    object TAdressГород: TWideStringField
      FieldName = #1043#1086#1088#1086#1076
    end
    object TAdressДом_Адрес: TWideStringField
      FieldName = #1044#1086#1084'_'#1040#1076#1088#1077#1089
      Size = 100
    end
  end
  object DSLichData: TDataSource
    DataSet = TLichData
    Left = 768
    Top = 136
  end
  object DSDoljnost: TDataSource
    DataSet = TDoljnost
    Left = 768
    Top = 184
  end
  object DSTelephones: TDataSource
    DataSet = TTelphones
    Left = 768
    Top = 232
  end
  object DSAdress: TDataSource
    DataSet = TAdress
    Left = 768
    Top = 280
  end
end
