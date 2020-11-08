object FormProg: TFormProg
  Left = 0
  Top = 0
  ActiveControl = DBGrid1
  Caption = #1043#1083#1072#1074#1085#1086#1077' '#1084#1077#1085#1102
  ClientHeight = 519
  ClientWidth = 818
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
  object DBGrid1: TDBGrid
    Left = 0
    Top = 48
    Width = 345
    Height = 305
    DataSource = DataSource1
    ReadOnly = True
    TabOrder = 0
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    Columns = <
      item
        Expanded = False
        FieldName = 'nebestela'
        Title.Caption = #1053#1077#1073#1077#1089#1085#1086#1077' '#1090#1077#1083#1086
        Width = 100
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'typenebestela'
        Title.Caption = #1058#1080#1087' '#1085#1077#1073#1077#1089#1085#1086#1075#1086' '#1090#1077#1083#1072
        Width = 108
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'galak_name'
        Title.Caption = #1043#1072#1083#1072#1082#1090#1080#1082#1072' '
        Width = 100
        Visible = True
      end>
  end
  object DBMemo1: TDBMemo
    Left = 343
    Top = 48
    Width = 306
    Height = 305
    DataField = 'Opisanie'
    DataSource = DataSource1
    ReadOnly = True
    TabOrder = 1
  end
  object Helper: TButton
    Left = 567
    Top = 8
    Width = 75
    Height = 25
    Caption = #1055#1086#1084#1086#1097#1100
    TabOrder = 2
    OnClick = HelperClick
  end
  object Button1: TButton
    Left = 104
    Top = 8
    Width = 75
    Height = 25
    Caption = #1058#1077#1089#1090
    TabOrder = 3
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 8
    Top = 8
    Width = 75
    Height = 25
    Caption = #1058#1077#1086#1088#1080#1103
    TabOrder = 4
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 200
    Top = 8
    Width = 75
    Height = 25
    Caption = #1048#1079#1084#1077#1085#1080#1090#1100
    TabOrder = 5
    Visible = False
    OnClick = Button3Click
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
    Left = 696
    Top = 216
  end
  object SQLQuery1: TSQLQuery
    Active = True
    DataSource = DataSource1
    MaxBlobSize = 1
    Params = <>
    SQL.Strings = (
      
        'SELECT nebessvaz_id, golak.golak_id, typenebestela.typenebestela' +
        '_ID, Opisanie, nebessvaz.nebestela,typenebestela.typenebestela, ' +
        'golak.galak_name FROM  nebessvaz,typenebestela,golak WHERE golak' +
        '.golak_id = nebessvaz.golak_id '
      'AND typenebestela.typenebestela_id = nebessvaz.typenebestela_id;')
    SQLConnection = SQLConnection1
    Left = 696
    Top = 280
  end
  object DataSource1: TDataSource
    DataSet = ClientDataSet1
    Left = 696
    Top = 456
  end
  object ClientDataSet1: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider1'
    Left = 696
    Top = 336
  end
  object DataSetProvider1: TDataSetProvider
    DataSet = SQLQuery1
    Left = 696
    Top = 392
  end
end
