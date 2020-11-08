object Form5: TForm5
  Left = 0
  Top = 0
  Caption = #1044#1086#1073#1072#1074#1080#1090#1100
  ClientHeight = 365
  ClientWidth = 502
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Button1: TButton
    Left = 192
    Top = 328
    Width = 75
    Height = 25
    Caption = #1044#1086#1073#1072#1074#1080#1090#1100
    TabOrder = 0
    OnClick = Button1Click
  end
  object Memo1: TMemo
    Left = 8
    Top = 8
    Width = 486
    Height = 314
    TabOrder = 1
  end
  object DBEdit1: TDBEdit
    Left = 477
    Top = 328
    Width = 17
    Height = 21
    DataField = 'id'
    DataSource = DataSource2
    TabOrder = 2
  end
  object SQLConnection1: TSQLConnection
    ConnectionName = 'MySQLConnection'
    DriverName = 'MySQL'
    LoginPrompt = False
    Params.Strings = (
      'DriverUnit=Data.DBXMySQL'
      
        'DriverPackageLoader=TDBXDynalinkDriverLoader,DbxCommonDriver240.' +
        'bpl'
      
        'DriverAssemblyLoader=Borland.Data.TDBXDynalinkDriverLoader,Borla' +
        'nd.Data.DbxCommonDriver,Version=24.0.0.0,Culture=neutral,PublicK' +
        'eyToken=91d62ebb5b0d1b1b'
      
        'MetaDataPackageLoader=TDBXMySqlMetaDataCommandFactory,DbxMySQLDr' +
        'iver240.bpl'
      
        'MetaDataAssemblyLoader=Borland.Data.TDBXMySqlMetaDataCommandFact' +
        'ory,Borland.Data.DbxMySQLDriver,Version=24.0.0.0,Culture=neutral' +
        ',PublicKeyToken=91d62ebb5b0d1b1b'
      'GetDriverFunc=getSQLDriverMYSQL'
      'LibraryName=dbxmys.dll'
      'LibraryNameOsx=libsqlmys.dylib'
      'VendorLib=LIBMYSQL.dll'
      'VendorLibWin64=libmysql.dll'
      'VendorLibOsx=libmysqlclient.dylib'
      'MaxBlobSize=-1'
      'DriverName=MySQL'
      'HostName=127.0.0.1'
      'Database=kursach'
      'User_Name=mysql'
      'Password=mysql'
      'ServerCharSet=cp1251'
      'BlobSize=-1'
      'ErrorResourceFile='
      'LocaleCode=0000'
      'Compressed=False'
      'Encrypted=False'
      'ConnectTimeout=60')
    Connected = True
    Left = 56
    Top = 296
  end
  object SQLQuery1: TSQLQuery
    Active = True
    DataSource = DataSource1
    MaxBlobSize = 1
    Params = <>
    SQL.Strings = (
      'select '#1087#1072#1088#1072#1075#1088#1072#1092' from paragraf')
    SQLConnection = SQLConnection1
    Left = 120
    Top = 296
  end
  object DataSource1: TDataSource
    Left = 184
    Top = 296
  end
  object DataSetProvider1: TDataSetProvider
    DataSet = SQLQuery1
    Left = 328
    Top = 296
  end
  object ClientDataSet1: TClientDataSet
    Active = True
    Aggregates = <>
    MasterSource = DataSource1
    PacketRecords = 0
    Params = <>
    ProviderName = 'DataSetProvider1'
    Left = 256
    Top = 296
  end
  object SQLConnection2: TSQLConnection
    DriverName = 'MySQL'
    LoginPrompt = False
    Params.Strings = (
      'DriverUnit=Data.DBXMySQL'
      
        'DriverPackageLoader=TDBXDynalinkDriverLoader,DbxCommonDriver240.' +
        'bpl'
      
        'DriverAssemblyLoader=Borland.Data.TDBXDynalinkDriverLoader,Borla' +
        'nd.Data.DbxCommonDriver,Version=24.0.0.0,Culture=neutral,PublicK' +
        'eyToken=91d62ebb5b0d1b1b'
      
        'MetaDataPackageLoader=TDBXMySqlMetaDataCommandFactory,DbxMySQLDr' +
        'iver240.bpl'
      
        'MetaDataAssemblyLoader=Borland.Data.TDBXMySqlMetaDataCommandFact' +
        'ory,Borland.Data.DbxMySQLDriver,Version=24.0.0.0,Culture=neutral' +
        ',PublicKeyToken=91d62ebb5b0d1b1b'
      'GetDriverFunc=getSQLDriverMYSQL'
      'LibraryName=dbxmys.dll'
      'LibraryNameOsx=libsqlmys.dylib'
      'VendorLib=LIBMYSQL.dll'
      'VendorLibWin64=libmysql.dll'
      'VendorLibOsx=libmysqlclient.dylib'
      'HostName=127.0.0.1'
      'Database=kursach'
      'User_Name=mysql'
      'Password=mysql'
      'MaxBlobSize=-1'
      'LocaleCode=0000'
      'Compressed=False'
      'Encrypted=False'
      'BlobSize=-1'
      'ErrorResourceFile='
      'ServerCharSet=cp1251')
    Connected = True
    Left = 32
    Top = 16
  end
  object SQLQuery2: TSQLQuery
    Active = True
    MaxBlobSize = 1
    Params = <>
    SQL.Strings = (
      'SELECT * FROM paragraf')
    SQLConnection = SQLConnection2
    Left = 128
    Top = 16
  end
  object DataSetProvider2: TDataSetProvider
    DataSet = SQLQuery2
    Left = 216
    Top = 16
  end
  object ClientDataSet2: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider2'
    Left = 312
    Top = 16
  end
  object DataSource2: TDataSource
    DataSet = ClientDataSet2
    Left = 400
    Top = 16
  end
end
