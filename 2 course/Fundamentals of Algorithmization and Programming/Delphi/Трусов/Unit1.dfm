object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 481
  ClientWidth = 663
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object DBGrid1: TDBGrid
    Left = 0
    Top = 124
    Width = 664
    Height = 349
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
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Fam'
        Width = 150
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Im'
        Width = 150
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Ot'
        Width = 200
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'Ocenka'
        Visible = True
      end>
  end
  object ComboBox2: TComboBox
    Left = 33
    Top = 71
    Width = 145
    Height = 21
    TabOrder = 1
    Text = #1055#1086' '#1091#1073#1099#1074#1072#1085#1080#1102
    OnChange = ComboBox2Change
    Items.Strings = (
      #1055#1086' '#1092#1072#1084#1080#1083#1080#1080
      #1055#1086' '#1086#1094#1077#1085#1082#1077)
  end
  object ComboBox1: TComboBox
    Left = 232
    Top = 71
    Width = 145
    Height = 21
    TabOrder = 2
    Text = #1055#1086' '#1074#1086#1079#1088#1072#1089#1090#1072#1085#1080#1102
    OnChange = ComboBox1Change
    Items.Strings = (
      #1055#1086' '#1092#1072#1084#1080#1083#1080#1080
      #1055#1086' '#1086#1094#1077#1085#1082#1077)
  end
  object Edit1: TEdit
    Left = 424
    Top = 71
    Width = 63
    Height = 21
    TabOrder = 3
  end
  object Button1: TButton
    Left = 499
    Top = 69
    Width = 75
    Height = 25
    Caption = #1057#1088#1077#1076#1085#1080#1081' '#1073#1072#1083#1083
    TabOrder = 4
    OnClick = Button1Click
  end
  object Button4: TButton
    Left = 580
    Top = 69
    Width = 75
    Height = 25
    Caption = 'Excel'
    TabOrder = 5
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
      'MaxBlobSize=-1'
      'DriverName=MySQL'
      'HostName=127.0.0.1'
      'Database=Laba8'
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
    Left = 40
    Top = 15
  end
  object SQLQuery1: TSQLQuery
    Active = True
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'SELECT * FROM Stud')
    SQLConnection = SQLConnection1
    Left = 120
    Top = 15
  end
  object DataSetProvider1: TDataSetProvider
    DataSet = SQLQuery1
    Left = 208
    Top = 15
  end
  object ClientDataSet1: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider1'
    Left = 304
    Top = 15
  end
  object DataSource1: TDataSource
    DataSet = ClientDataSet1
    Left = 392
    Top = 15
  end
end
