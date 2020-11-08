object Form8: TForm8
  Left = 0
  Top = 0
  Caption = #1048#1079#1084#1077#1085#1077#1085#1080#1103
  ClientHeight = 524
  ClientWidth = 714
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 8
    Top = 19
    Width = 75
    Height = 13
    Caption = #1053#1077#1073#1077#1089#1085#1086#1077' '#1090#1077#1083#1086
  end
  object Label2: TLabel
    Left = 216
    Top = 19
    Width = 100
    Height = 13
    Caption = #1058#1080#1087' '#1085#1077#1073#1077#1089#1085#1086#1075#1086' '#1090#1077#1083#1072
  end
  object Label3: TLabel
    Left = 288
    Top = 45
    Width = 53
    Height = 13
    Caption = #1054#1087#1080#1089#1072#1085#1080#1077':'
  end
  object Label4: TLabel
    Left = 499
    Top = 19
    Width = 54
    Height = 13
    Caption = #1043#1072#1083#1072#1082#1090#1080#1082#1072
  end
  object Button1: TButton
    Left = 119
    Top = 249
    Width = 75
    Height = 25
    Caption = #1044#1086#1073#1072#1074#1080#1090#1100
    TabOrder = 0
    OnClick = Button1Click
  end
  object EditNebesTela: TDBEdit
    Left = 89
    Top = 16
    Width = 121
    Height = 21
    DataField = 'nebestela'
    DataSource = FormProg.DataSource1
    TabOrder = 1
  end
  object Memo1: TDBMemo
    Left = 8
    Top = 64
    Width = 697
    Height = 161
    DataField = 'Opisanie'
    DataSource = FormProg.DataSource1
    TabOrder = 2
  end
  object TypeNebesTela: TDBComboBox
    Left = 483
    Top = 462
    Width = 145
    Height = 21
    DataField = 'typenebestela'
    DataSource = FormProg.DataSource1
    TabOrder = 3
  end
  object Golak: TDBComboBox
    Left = 634
    Top = 462
    Width = 145
    Height = 21
    DataField = 'galak_name'
    DataSource = FormProg.DataSource1
    TabOrder = 4
  end
  object DBLCBTypeNebesTela: TDBLookupComboBox
    Left = 322
    Top = 16
    Width = 145
    Height = 21
    KeyField = 'typenebestela'
    ListField = 'typenebestela'
    ListSource = DataSource2
    TabOrder = 5
  end
  object DBLCBGolak: TDBLookupComboBox
    Left = 559
    Top = 16
    Width = 145
    Height = 21
    KeyField = 'galak_name'
    ListField = 'galak_name'
    ListSource = DataSource3
    TabOrder = 6
  end
  object Button2: TButton
    Left = 322
    Top = 249
    Width = 75
    Height = 25
    Caption = #1048#1079#1084#1077#1085#1080#1090#1100
    TabOrder = 7
    OnClick = Button2Click
  end
  object DBEdit1: TDBEdit
    Left = 8
    Top = 37
    Width = 25
    Height = 21
    DataField = 'nebessvaz_id'
    DataSource = FormProg.DataSource1
    TabOrder = 8
    Visible = False
  end
  object DBEdit2: TDBEdit
    Left = 39
    Top = 37
    Width = 25
    Height = 21
    DataField = 'typenebestela_ID'
    DataSource = DataSource2
    TabOrder = 9
    Visible = False
  end
  object DBEdit3: TDBEdit
    Left = 70
    Top = 37
    Width = 25
    Height = 21
    DataField = 'golak_id'
    DataSource = DataSource3
    TabOrder = 10
    Visible = False
  end
  object Button3: TButton
    Left = 519
    Top = 249
    Width = 75
    Height = 25
    Caption = #1059#1076#1072#1083#1080#1090#1100
    TabOrder = 11
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 473
    Top = 19
    Width = 20
    Height = 13
    Caption = '...'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'Tahoma'
    Font.Style = []
    ParentFont = False
    TabOrder = 12
    OnClick = Button4Click
  end
  object SQLQuery1: TSQLQuery
    Active = True
    MaxBlobSize = 1
    Params = <>
    SQL.Strings = (
      'SELECT * FROM typenebestela')
    SQLConnection = FormProg.SQLConnection1
    Left = 36
    Top = 318
  end
  object DataSource1: TDataSource
    DataSet = ClientDataSet1
    Left = 35
    Top = 464
  end
  object DataSetProvider1: TDataSetProvider
    DataSet = SQLQuery1
    Left = 36
    Top = 368
  end
  object ClientDataSet1: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider1'
    Left = 36
    Top = 416
  end
  object DataSource2: TDataSource
    DataSet = ClientDataSet2
    Left = 123
    Top = 464
  end
  object ClientDataSet2: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider2'
    Left = 124
    Top = 416
  end
  object DataSetProvider2: TDataSetProvider
    DataSet = SQLQuery2
    Left = 124
    Top = 368
  end
  object SQLQuery2: TSQLQuery
    Active = True
    MaxBlobSize = 1
    Params = <>
    SQL.Strings = (
      'SELECT * FROM typenebestela'
      '')
    SQLConnection = FormProg.SQLConnection1
    Left = 124
    Top = 318
  end
  object SQLQuery3: TSQLQuery
    Active = True
    MaxBlobSize = 1
    Params = <>
    SQL.Strings = (
      'SELECT * FROM golak')
    SQLConnection = FormProg.SQLConnection1
    Left = 212
    Top = 318
  end
  object DataSetProvider3: TDataSetProvider
    DataSet = SQLQuery3
    Left = 212
    Top = 368
  end
  object ClientDataSet3: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider3'
    Left = 212
    Top = 416
  end
  object DataSource3: TDataSource
    DataSet = ClientDataSet3
    Left = 211
    Top = 464
  end
end
