object FormMain: TFormMain
  Left = 0
  Top = 0
  Caption = #1055#1088#1072#1079#1076#1085#1080#1082#1080
  ClientHeight = 839
  ClientWidth = 912
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
  object DBMemo1: TDBMemo
    Left = 8
    Top = 254
    Width = 896
    Height = 531
    DataField = 'Description'
    DataSource = DataSource1
    TabOrder = 0
  end
  object Button1: TButton
    Left = 800
    Top = 154
    Width = 104
    Height = 25
    Caption = #1044#1086#1073#1072#1074#1083#1077#1085#1080#1077
    TabOrder = 1
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 800
    Top = 185
    Width = 104
    Height = 25
    Caption = #1056#1077#1076#1072#1082#1090#1080#1088#1086#1074#1072#1090#1100
    TabOrder = 2
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 800
    Top = 216
    Width = 104
    Height = 25
    Caption = #1059#1076#1072#1083#1080#1090#1100
    TabOrder = 3
    OnClick = Button3Click
  end
  object Button4: TButton
    Left = 800
    Top = 8
    Width = 104
    Height = 25
    Caption = #1055#1086#1084#1086#1097#1100
    TabOrder = 4
    OnClick = Button4Click
  end
  object Button6: TButton
    Left = 800
    Top = 39
    Width = 104
    Height = 25
    Caption = #1054#1073#1085#1086#1074#1080#1090#1100' '#1076#1072#1085#1085#1099#1077
    TabOrder = 5
    OnClick = Button6Click
  end
  object DBGrid1: TDBGrid
    Left = 8
    Top = 8
    Width = 765
    Height = 233
    DataSource = DataSource1
    TabOrder = 6
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
        Title.Caption = #1053#1072#1088#1086#1076
        Width = 250
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Description'
        Visible = False
      end
      item
        Expanded = False
        FieldName = 'Name_1'
        Title.Caption = #1055#1088#1072#1079#1076#1085#1080#1082
        Width = 350
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Month'
        Title.Caption = #1052#1077#1089#1103#1094
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Day'
        Title.Caption = #1044#1077#1085#1100
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
      'MaxBlobSize=-1'
      'DriverName=MySQL'
      'HostName=127.0.0.1'
      'Database=Holidays'
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
    Left = 456
    Top = 800
  end
  object SQLQuery1: TSQLQuery
    Active = True
    MaxBlobSize = 1
    Params = <>
    SQL.Strings = (
      
        'SELECT Date.ID, Holiday.ID, People.Name, Description, Holiday.Na' +
        'me, Month, Day FROM Holiday, Date, People WHERE ID_Date=Date.ID ' +
        'AND ID_People=People.ID')
    SQLConnection = SQLConnection1
    Left = 24
    Top = 800
  end
  object DataSetProvider1: TDataSetProvider
    DataSet = SQLQuery1
    Left = 104
    Top = 800
  end
  object DataSource1: TDataSource
    DataSet = ClientDataSet1
    Left = 272
    Top = 800
  end
  object ClientDataSet1: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider1'
    Left = 192
    Top = 800
  end
  object SQLQuery2: TSQLQuery
    Active = True
    MaxBlobSize = 1
    Params = <>
    SQL.Strings = (
      
        'SELECT Holiday.ID, People.Name, Description, Holiday.Name, Month' +
        ', Day FROM Holiday, Date, People WHERE ID_Date=Date.ID AND ID_Pe' +
        'ople=People.ID')
    SQLConnection = SQLConnection1
    Left = 552
    Top = 800
  end
  object DataSetProvider2: TDataSetProvider
    DataSet = SQLQuery2
    Left = 632
    Top = 800
  end
  object ClientDataSet2: TClientDataSet
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider2'
    Left = 720
    Top = 800
  end
  object DataSource2: TDataSource
    DataSet = ClientDataSet2
    Left = 800
    Top = 800
  end
end
