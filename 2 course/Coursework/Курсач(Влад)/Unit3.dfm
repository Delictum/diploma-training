object LogOut: TLogOut
  Left = 0
  Top = 0
  Caption = #1042#1093#1086#1076
  ClientHeight = 92
  ClientWidth = 353
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
  object BtnLED: TButton
    Left = 80
    Top = 62
    Width = 75
    Height = 25
    Caption = #1042#1093#1086#1076
    TabOrder = 2
    OnClick = BtnLEDClick
  end
  object Button1: TButton
    Left = 256
    Top = 8
    Width = 89
    Height = 21
    Caption = #1053#1086#1074#1099#1081
    TabOrder = 3
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 256
    Top = 35
    Width = 89
    Height = 21
    Caption = #1056#1077#1076#1072#1082#1090#1080#1088#1086#1074#1072#1090#1100
    TabOrder = 4
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 256
    Top = 62
    Width = 89
    Height = 21
    Caption = #1059#1076#1072#1083#1080#1090#1100
    TabOrder = 5
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 175
    Top = 62
    Width = 75
    Height = 25
    Caption = 'Helper'
    TabOrder = 6
    OnClick = Button4Click
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
  object DataSetProvider1: TDataSetProvider
    DataSet = SQLQuery1
    Left = 192
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
  object DataSource1: TDataSource
    DataSet = ClientDataSet1
    Left = 352
    Top = 230
  end
end
