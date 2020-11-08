object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 370
  ClientWidth = 678
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Button4: TButton
    Left = 507
    Top = 54
    Width = 75
    Height = 25
    Caption = 'Excel'
    TabOrder = 0
    OnClick = Button4Click
  end
  object ComboBox1: TComboBox
    Left = 189
    Top = 56
    Width = 145
    Height = 21
    TabOrder = 1
    Text = #1055#1086' '#1074#1086#1079#1088#1072#1089#1090#1072#1085#1080#1102
    OnChange = ComboBox1Change
    Items.Strings = (
      #1055#1086' '#1090#1080#1087#1091
      #1055#1086' '#1074#1088#1077#1084#1077#1085#1080)
  end
  object ComboBox2: TComboBox
    Left = 8
    Top = 56
    Width = 145
    Height = 21
    TabOrder = 2
    Text = #1055#1086' '#1091#1073#1099#1074#1072#1085#1080#1102
    OnChange = ComboBox2Change
    Items.Strings = (
      #1055#1086' '#1090#1080#1087#1091
      #1055#1086' '#1074#1088#1077#1084#1077#1085#1080)
  end
  object DBGrid1: TDBGrid
    Left = 8
    Top = 96
    Width = 673
    Height = 269
    DataSource = DataSource1
    TabOrder = 3
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    Columns = <
      item
        Expanded = False
        FieldName = 'ID'
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Number'
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Type'
        Width = 200
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Naznachenie'
        Width = 200
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Time'
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
      'Database=LR_8'
      'User_Name=pol3'
      'ServerCharSet=cp1251'
      'BlobSize=-1'
      'ErrorResourceFile='
      'LocaleCode=0000'
      'Compressed=False'
      'Encrypted=False'
      'ConnectTimeout=60'
      'Password=1')
    Connected = True
    Left = 21
    Top = 8
  end
  object SQLQuery1: TSQLQuery
    Active = True
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'SELECT * FROM Air')
    SQLConnection = SQLConnection1
    Left = 101
    Top = 8
  end
  object DataSetProvider1: TDataSetProvider
    DataSet = SQLQuery1
    Left = 189
    Top = 8
  end
  object ClientDataSet1: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider1'
    Left = 285
    Top = 8
  end
  object DataSource1: TDataSource
    DataSet = ClientDataSet1
    Left = 373
    Top = 8
  end
end
