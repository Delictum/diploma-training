object FormBegin: TFormBegin
  Left = 0
  Top = 0
  Caption = #1057#1090#1072#1088#1090
  ClientHeight = 95
  ClientWidth = 168
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
  object Label1: TLabel
    Left = 32
    Top = 16
    Width = 96
    Height = 13
    Caption = #1042#1099#1073#1077#1088#1080#1090#1077' '#1074#1086#1087#1088#1086#1089#1099
  end
  object Ok: TButton
    Left = 64
    Top = 62
    Width = 39
    Height = 25
    Caption = 'Ok'
    TabOrder = 0
    OnClick = OkClick
  end
  object DBLCBLevel: TDBLookupComboBox
    Left = 9
    Top = 35
    Width = 145
    Height = 21
    KeyField = 'LevelName'
    ListField = 'LevelName'
    ListSource = DataSource1
    TabOrder = 1
  end
  object Button1: TButton
    Left = 132
    Top = 15
    Width = 22
    Height = 17
    Caption = '...'
    TabOrder = 2
    Visible = False
    OnClick = Button1Click
  end
  object DBEdit1: TDBEdit
    Left = 8
    Top = 13
    Width = 18
    Height = 21
    DataField = 'LevelID'
    DataSource = DataSource1
    TabOrder = 3
    Visible = False
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
      'SELECT *  FROM Level')
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
  object DataSource2: TDataSource
    DataSet = ClientDataSet2
    Left = 352
    Top = 182
  end
  object ClientDataSet2: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider2'
    Left = 280
    Top = 182
  end
  object DataSetProvider2: TDataSetProvider
    DataSet = SQLQuery2
    Left = 192
    Top = 182
  end
  object SQLQuery2: TSQLQuery
    Active = True
    MaxBlobSize = 1
    Params = <>
    SQL.Strings = (
      'SELECT *  FROM Level')
    SQLConnection = SQLConnection2
    Left = 112
    Top = 182
  end
  object SQLConnection2: TSQLConnection
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
    Top = 182
  end
end
