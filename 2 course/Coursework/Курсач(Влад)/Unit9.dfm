object FormEnd: TFormEnd
  Left = 0
  Top = 0
  Caption = #1050#1086#1085#1077#1094' '#1080#1075#1088#1099
  ClientHeight = 202
  ClientWidth = 436
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  Position = poDesktopCenter
  OnClose = FormClose
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 136
    Top = 8
    Width = 62
    Height = 13
    Caption = #1042#1099' '#1085#1072#1073#1088#1072#1083#1080' '
  end
  object Button1: TButton
    Left = 192
    Top = 169
    Width = 75
    Height = 25
    Caption = #1047#1072#1085#1086#1074#1086
    TabOrder = 0
    OnClick = Button1Click
  end
  object DBGrid1: TDBGrid
    Left = 64
    Top = 27
    Width = 329
    Height = 120
    DataSource = DataSource1
    TabOrder = 1
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
        Title.Caption = #1048#1075#1088#1086#1082
        Width = 200
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Password'
        Visible = False
      end
      item
        Expanded = False
        FieldName = 'Score'
        Title.Caption = #1054#1095#1082#1080
        Width = 95
        Visible = True
      end>
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
    Top = 254
  end
  object SQLQuery1: TSQLQuery
    Active = True
    MaxBlobSize = 1
    Params = <>
    SQL.Strings = (
      'SELECT *  FROM Users ORDER BY Name ')
    SQLConnection = SQLConnection1
    Left = 112
    Top = 254
  end
  object DataSetProvider1: TDataSetProvider
    DataSet = SQLQuery1
    Left = 192
    Top = 254
  end
  object ClientDataSet1: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider1'
    Left = 280
    Top = 254
  end
  object DataSource1: TDataSource
    DataSet = ClientDataSet1
    Left = 352
    Top = 254
  end
end
