object Form5: TForm5
  Left = 0
  Top = 0
  Caption = #1056#1077#1076#1072#1082#1090#1080#1088#1086#1074#1072#1085#1080#1077
  ClientHeight = 173
  ClientWidth = 633
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  OnClose = FormClose
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 351
    Top = 8
    Width = 117
    Height = 13
    Caption = #1042#1074#1077#1076#1080#1090#1077' '#1087#1086#1083#1100#1079#1086#1074#1072#1090#1077#1083#1103
  end
  object Label2: TLabel
    Left = 351
    Top = 38
    Width = 82
    Height = 13
    Caption = #1042#1074#1077#1076#1080#1090#1077' '#1087#1072#1088#1086#1083#1100
  end
  object DBGrid1: TDBGrid
    Left = 8
    Top = 8
    Width = 337
    Height = 161
    DataSource = DataSource1
    TabOrder = 0
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    Columns = <
      item
        Expanded = False
        FieldName = 'ID'
        Visible = False
      end
      item
        Expanded = False
        FieldName = 'Name'
        Title.Caption = #1055#1086#1083#1100#1079#1086#1074#1072#1090#1077#1083#1100
        Width = 200
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Password'
        Title.Caption = #1055#1072#1088#1086#1083#1100
        Visible = True
      end>
  end
  object Button1: TButton
    Left = 455
    Top = 70
    Width = 75
    Height = 25
    Caption = #1059#1076#1072#1083#1080#1090#1100
    TabOrder = 1
    OnClick = Button1Click
  end
  object DBEdit1: TDBEdit
    Left = 368
    Top = 125
    Width = 17
    Height = 21
    DataField = 'ID'
    DataSource = DataSource1
    TabOrder = 2
    Visible = False
  end
  object Button2: TButton
    Left = 368
    Top = 70
    Width = 75
    Height = 25
    Caption = #1048#1079#1084#1077#1085#1080#1090#1100
    TabOrder = 3
    OnClick = Button2Click
  end
  object EditPasLog: TEdit
    Left = 474
    Top = 35
    Width = 145
    Height = 21
    TabOrder = 4
  end
  object EditNameLog: TEdit
    Left = 474
    Top = 8
    Width = 145
    Height = 21
    TabOrder = 5
  end
  object Button3: TButton
    Left = 550
    Top = 70
    Width = 75
    Height = 25
    Caption = #1050' '#1087#1088#1086#1075#1088#1072#1084#1084#1077
    TabOrder = 6
    OnClick = Button3Click
  end
  object SQLQuery1: TSQLQuery
    Active = True
    DataSource = DataSource1
    MaxBlobSize = 1
    Params = <>
    SQL.Strings = (
      'SELECT *  FROM Users WHERE ID > 1')
    SQLConnection = SQLConnection1
    Left = 740
    Top = 62
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
      'Password=mysql'
      'MaxBlobSize=-1'
      'DriverName=MySQL'
      'HostName=127.0.0.1'
      'Database=kursv'
      'User_Name=mysql'
      'BlobSize=-1'
      'ErrorResourceFile='
      'LocaleCode=0000'
      'Compressed=False'
      'Encrypted=False'
      'ConnectTimeout=60'
      'ServerCharSet=cp1251')
    Connected = True
    Left = 740
    Top = 16
  end
  object ClientDataSet1: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider1'
    Left = 740
    Top = 110
  end
  object DataSetProvider1: TDataSetProvider
    DataSet = SQLQuery1
    Left = 740
    Top = 158
  end
  object DataSource1: TDataSource
    DataSet = ClientDataSet1
    Left = 741
    Top = 206
  end
  object SQLConnection2: TSQLConnection
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
      'Password=mysql'
      'MaxBlobSize=-1'
      'DriverName=MySQL'
      'HostName=127.0.0.1'
      'Database=kursv'
      'User_Name=mysql'
      'BlobSize=-1'
      'ErrorResourceFile='
      'LocaleCode=0000'
      'Compressed=False'
      'Encrypted=False'
      'ConnectTimeout=60'
      'ServerCharSet=cp1251')
    Connected = True
    Left = 660
    Top = 16
  end
  object SQLQuery2: TSQLQuery
    Active = True
    DataSource = DataSource2
    MaxBlobSize = 1
    Params = <>
    SQL.Strings = (
      'SELECT *  FROM Users WHERE ID > 1')
    SQLConnection = SQLConnection2
    Left = 660
    Top = 62
  end
  object ClientDataSet2: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider2'
    Left = 660
    Top = 110
  end
  object DataSetProvider2: TDataSetProvider
    DataSet = SQLQuery2
    Left = 660
    Top = 158
  end
  object DataSource2: TDataSource
    DataSet = ClientDataSet2
    Left = 661
    Top = 206
  end
end
