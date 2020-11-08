object LogReg: TLogReg
  Left = 0
  Top = 0
  Caption = #1042#1093#1086#1076
  ClientHeight = 121
  ClientWidth = 259
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  OnClose = FormClose
  PixelsPerInch = 96
  TextHeight = 13
  object EditNameLog: TEdit
    Left = 8
    Top = 8
    Width = 241
    Height = 21
    TabOrder = 0
    Text = #1042#1074#1077#1076#1080#1090#1077' '#1087#1086#1083#1100#1079#1086#1074#1072#1090#1077#1083#1103
    OnClick = EditNameLogClick
  end
  object EditPasLog: TEdit
    Left = 8
    Top = 35
    Width = 241
    Height = 21
    TabOrder = 1
    Text = #1042#1074#1077#1076#1080#1090#1077' '#1087#1072#1088#1086#1083#1100
    OnClick = EditPasLogClick
  end
  object EditRPasLog: TEdit
    Left = 8
    Top = 62
    Width = 241
    Height = 21
    TabOrder = 2
    Text = #1055#1086#1074#1090#1086#1088#1080#1090#1077' '#1087#1072#1088#1086#1083#1100
    OnClick = EditRPasLogClick
  end
  object BtnReg: TButton
    Left = 8
    Top = 89
    Width = 121
    Height = 25
    Caption = #1047#1072#1088#1077#1075#1080#1089#1090#1088#1080#1088#1086#1074#1072#1090#1100#1089#1103
    TabOrder = 3
    OnClick = BtnRegClick
  end
  object BtnBack: TButton
    Left = 175
    Top = 89
    Width = 75
    Height = 25
    Caption = #1053#1072#1079#1072#1076
    TabOrder = 4
    OnClick = BtnBackClick
  end
  object DataSource1: TDataSource
    DataSet = ClientDataSet1
    Left = 352
    Top = 230
  end
  object ClientDataSet1: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider1'
    Left = 280
    Top = 230
  end
  object DataSetProvider1: TDataSetProvider
    DataSet = SQLQuery1
    Left = 192
    Top = 230
  end
  object SQLQuery1: TSQLQuery
    Active = True
    MaxBlobSize = 1
    Params = <>
    SQL.Strings = (
      'SELECT *  FROM Users')
    SQLConnection = SQLConnection1
    Left = 112
    Top = 230
  end
  object SQLConnection1: TSQLConnection
    ConnectionName = 'MySQLConnection'
    DriverName = 'MySQL'
    LoginPrompt = False
    Params.Strings = (
      'DriverUnit=DBXMySQL'
      
        'DriverPackageLoader=TDBXDynalinkDriverLoader,DbxCommonDriver140.' +
        'bpl'
      
        'DriverAssemblyLoader=Borland.Data.TDBXDynalinkDriverLoader,Borla' +
        'nd.Data.DbxCommonDriver,Version=14.0.0.0,Culture=neutral,PublicK' +
        'eyToken=91d62ebb5b0d1b1b'
      
        'MetaDataPackageLoader=TDBXMySqlMetaDataCommandFactory,DbxMySQLDr' +
        'iver140.bpl'
      
        'MetaDataAssemblyLoader=Borland.Data.TDBXMySqlMetaDataCommandFact' +
        'ory,Borland.Data.DbxMySQLDriver,Version=14.0.0.0,Culture=neutral' +
        ',PublicKeyToken=91d62ebb5b0d1b1b'
      'GetDriverFunc=getSQLDriverMYSQL'
      'LibraryName=dbxmys.dll'
      'LibraryNameOsx=libsqlmys.dylib'
      'VendorLib=LIBMYSQL.dll'
      'VendorLibWin64=libmysql.dll'
      'VendorLibOsx=libmysqlclient.dylib'
      'DriverName=MySQL'
      'HostName=127.0.0.1'
      'Database=MillionerGame'
      'User_Name=mysql'
      'Password=mysql'
      'ServerCharSet=cp1251'
      'BlobSize=-1'
      'ErrorResourceFile='
      'LocaleCode=0000'
      'Compressed=False'
      'Encrypted=False'
      'ConnectTimeout=60'
      'MaxBlobSize=-1')
    Connected = True
    Left = 32
    Top = 230
  end
end
