object Form6: TForm6
  Left = 0
  Top = 0
  Caption = #1056#1077#1075#1080#1089#1090#1088#1072#1094#1080#1103
  ClientHeight = 127
  ClientWidth = 280
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
    Left = 16
    Top = 16
    Width = 117
    Height = 13
    Caption = #1042#1074#1077#1076#1080#1090#1077' '#1087#1086#1083#1100#1079#1086#1074#1072#1090#1077#1083#1103
  end
  object Label2: TLabel
    Left = 16
    Top = 43
    Width = 82
    Height = 13
    Caption = #1042#1074#1077#1076#1080#1090#1077' '#1087#1072#1088#1086#1083#1100
  end
  object Label3: TLabel
    Left = 16
    Top = 70
    Width = 94
    Height = 13
    Caption = #1055#1086#1074#1090#1086#1088#1080#1090#1077' '#1087#1072#1088#1086#1083#1100
  end
  object EditNameLog: TEdit
    Left = 139
    Top = 8
    Width = 137
    Height = 21
    TabOrder = 0
  end
  object EditPasLog: TEdit
    Left = 139
    Top = 35
    Width = 137
    Height = 21
    PasswordChar = '*'
    TabOrder = 1
  end
  object EditRPasLog: TEdit
    Left = 139
    Top = 62
    Width = 137
    Height = 21
    PasswordChar = '*'
    TabOrder = 2
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
    Left = 356
    Top = 24
  end
  object SQLQuery1: TSQLQuery
    Active = True
    DataSource = DataSource1
    MaxBlobSize = 1
    Params = <>
    SQL.Strings = (
      'SELECT *  FROM Users WHERE ID > 1')
    SQLConnection = SQLConnection1
    Left = 356
    Top = 70
  end
  object ClientDataSet1: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider1'
    Left = 356
    Top = 118
  end
  object DataSetProvider1: TDataSetProvider
    DataSet = SQLQuery1
    Left = 356
    Top = 166
  end
  object DataSource1: TDataSource
    DataSet = ClientDataSet1
    Left = 356
    Top = 214
  end
end
