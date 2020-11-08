object Form5: TForm5
  Left = 0
  Top = 0
  Caption = #1050#1086#1088#1088#1077#1082#1090#1080#1074#1099
  ClientHeight = 741
  ClientWidth = 757
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  PixelsPerInch = 96
  TextHeight = 13
  object DBEdit1: TDBEdit
    Left = 439
    Top = 8
    Width = 121
    Height = 21
    DataField = 'Dinozavr'
    DataSource = FormDinozavr.DataSource1
    TabOrder = 0
  end
  object DBEdit2: TDBEdit
    Left = 8
    Top = 8
    Width = 121
    Height = 21
    DataField = 'Eda'
    DataSource = FormDinozavr.DataSource1
    TabOrder = 1
  end
  object DBEdit3: TDBEdit
    Left = 152
    Top = 8
    Width = 121
    Height = 21
    DataField = 'Otryd'
    DataSource = FormDinozavr.DataSource1
    TabOrder = 2
  end
  object Edit4: TEdit
    Left = 439
    Top = 48
    Width = 121
    Height = 21
    TabOrder = 3
  end
  object Memo1: TMemo
    Left = 8
    Top = 112
    Width = 552
    Height = 249
    TabOrder = 4
  end
  object Button1: TButton
    Left = 8
    Top = 376
    Width = 89
    Height = 25
    Caption = #1044#1086#1073#1072#1074#1080#1090#1100
    TabOrder = 5
    OnClick = Button1Click
  end
  object DBComboBox1: TDBComboBox
    Left = 296
    Top = 8
    Width = 121
    Height = 21
    DataField = 'Period'
    DataSource = FormDinozavr.DataSource1
    TabOrder = 6
  end
  object DBLCB1: TDBLookupComboBox
    Left = 8
    Top = 48
    Width = 121
    Height = 21
    KeyField = 'Eda'
    ListField = 'Eda'
    ListSource = DataSource2
    TabOrder = 7
  end
  object DBLCB2: TDBLookupComboBox
    Left = 152
    Top = 48
    Width = 121
    Height = 21
    KeyField = 'Otryd'
    ListField = 'Otryd'
    ListSource = DataSource3
    TabOrder = 8
  end
  object DBLCB3: TDBLookupComboBox
    Left = 296
    Top = 48
    Width = 121
    Height = 21
    KeyField = 'Period'
    ListField = 'Period'
    ListSource = DataSource4
    TabOrder = 9
  end
  object Button2: TButton
    Left = 128
    Top = 376
    Width = 89
    Height = 25
    Caption = #1059#1076#1072#1083#1080#1090#1100
    TabOrder = 10
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 248
    Top = 376
    Width = 89
    Height = 25
    Caption = #1056#1077#1076#1072#1082#1090#1080#1088#1086#1074#1072#1090#1100
    TabOrder = 11
    OnClick = Button3Click
  end
  object DataSource1: TDataSource
    DataSet = ClientDataSet1
    Left = 624
    Top = 398
  end
  object ClientDataSet1: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider1'
    Left = 544
    Top = 398
  end
  object DataSetProvider1: TDataSetProvider
    DataSet = SQLQuery1
    Left = 456
    Top = 398
  end
  object SQLQuery1: TSQLQuery
    Active = True
    MaxBlobSize = 1
    Params = <>
    SQL.Strings = (
      
        'SELECT Dinozavr_Main.ID, Eda, Otryd, Period, Dinozavr, Text FROM' +
        ' Dinozavr_Main, Period, Otryd, Eda WHERE Dinozavr_Main.ID_Eda = ' +
        'Eda.ID AND Dinozavr_Main.ID_Otryd = Otryd.ID AND Dinozavr_Main.I' +
        'D_Period = Period.ID')
    SQLConnection = SQLConnection1
    Left = 376
    Top = 398
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
      'Database=Dinosaurs'
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
    Left = 296
    Top = 398
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
      'Database=Dinosaurs'
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
    Left = 40
    Top = 526
  end
  object SQLQuery2: TSQLQuery
    Active = True
    MaxBlobSize = 1
    Params = <>
    SQL.Strings = (
      'SELECT * FROM Eda')
    SQLConnection = SQLConnection2
    Left = 120
    Top = 526
  end
  object DataSetProvider2: TDataSetProvider
    DataSet = SQLQuery2
    Left = 200
    Top = 526
  end
  object ClientDataSet2: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider2'
    Left = 288
    Top = 526
  end
  object DataSource2: TDataSource
    DataSet = ClientDataSet2
    Left = 368
    Top = 526
  end
  object SQLQuery3: TSQLQuery
    Active = True
    MaxBlobSize = 1
    Params = <>
    SQL.Strings = (
      'SELECT * FROM Otryd')
    SQLConnection = SQLConnection3
    Left = 120
    Top = 582
  end
  object DataSource3: TDataSource
    DataSet = ClientDataSet3
    Left = 368
    Top = 582
  end
  object ClientDataSet3: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider3'
    Left = 288
    Top = 582
  end
  object DataSetProvider3: TDataSetProvider
    DataSet = SQLQuery3
    Left = 200
    Top = 582
  end
  object SQLConnection3: TSQLConnection
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
      'Database=Dinosaurs'
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
    Left = 40
    Top = 582
  end
  object SQLQuery4: TSQLQuery
    Active = True
    MaxBlobSize = 1
    Params = <>
    SQL.Strings = (
      'SELECT * FROM Period')
    SQLConnection = SQLConnection4
    Left = 120
    Top = 638
  end
  object DataSource4: TDataSource
    DataSet = ClientDataSet4
    Left = 368
    Top = 638
  end
  object ClientDataSet4: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider4'
    Left = 288
    Top = 638
  end
  object DataSetProvider4: TDataSetProvider
    DataSet = SQLQuery4
    Left = 200
    Top = 638
  end
  object SQLConnection4: TSQLConnection
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
      'Database=Dinosaurs'
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
    Left = 40
    Top = 638
  end
end
