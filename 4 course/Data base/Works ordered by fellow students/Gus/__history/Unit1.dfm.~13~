object Form1: TForm1
  Left = 0
  Top = 0
  ClientHeight = 700
  ClientWidth = 1110
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label2: TLabel
    Left = 8
    Top = 407
    Width = 30
    Height = 13
    Caption = #1055#1086#1080#1089#1082
  end
  object DBGrid1: TDBGrid
    Left = 8
    Top = 8
    Width = 815
    Height = 273
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
        FieldName = 'id'
        Visible = False
      end
      item
        Expanded = False
        FieldName = 'datePayments'
        Width = 80
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'name'
        Width = 150
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'numberPayments'
        Width = 50
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'fullName'
        Width = 200
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'adress'
        Width = 215
        Visible = True
      end
      item
        Expanded = False
        FieldName = 'sum'
        Width = 50
        Visible = True
      end>
  end
  object Edit1: TEdit
    Left = 239
    Top = 287
    Width = 66
    Height = 21
    TabOrder = 1
  end
  object Edit2: TEdit
    Left = 311
    Top = 287
    Width = 194
    Height = 21
    TabOrder = 2
  end
  object Edit3: TEdit
    Left = 511
    Top = 287
    Width = 231
    Height = 21
    TabOrder = 3
  end
  object Button1: TButton
    Left = 8
    Top = 314
    Width = 89
    Height = 21
    Caption = #1044#1086#1073#1072#1074#1080#1090#1100
    TabOrder = 4
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 8
    Top = 341
    Width = 90
    Height = 21
    Caption = #1056#1077#1076#1072#1082#1090#1080#1088#1086#1074#1072#1090#1100
    TabOrder = 5
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 8
    Top = 368
    Width = 89
    Height = 21
    Caption = #1059#1076#1072#1083#1080#1090#1100
    TabOrder = 6
    OnClick = Button3Click
  end
  object DBEdit1: TDBEdit
    Left = 72
    Top = 640
    Width = 33
    Height = 21
    DataField = 'id'
    DataSource = DataSource1
    TabOrder = 7
    Visible = False
  end
  object Button4: TButton
    Left = 748
    Top = 402
    Width = 75
    Height = 25
    Caption = 'Locate'
    TabOrder = 8
    OnClick = Button4Click
  end
  object Button5: TButton
    Left = 484
    Top = 402
    Width = 75
    Height = 25
    Caption = 'Lookup'
    TabOrder = 9
    OnClick = Button5Click
  end
  object Button6: TButton
    Left = 360
    Top = 341
    Width = 89
    Height = 21
    Caption = 'Excel'
    TabOrder = 10
    OnClick = Button6Click
  end
  object Edit4: TEdit
    Left = 301
    Top = 404
    Width = 177
    Height = 21
    TabOrder = 11
  end
  object Edit5: TEdit
    Left = 565
    Top = 404
    Width = 177
    Height = 21
    TabOrder = 12
  end
  object DBLookupListBox1: TDBLookupListBox
    Left = 103
    Top = 314
    Width = 202
    Height = 82
    KeyField = 'name'
    ListField = 'name'
    ListSource = DataSource2
    TabOrder = 13
  end
  object Edit6: TEdit
    Left = 44
    Top = 404
    Width = 251
    Height = 21
    TabOrder = 14
    OnKeyPress = Edit6KeyPress
  end
  object DBGrid2: TDBGrid
    Left = 600
    Top = 314
    Width = 223
    Height = 82
    DataSource = DataSource2
    TabOrder = 15
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    Columns = <
      item
        Expanded = False
        FieldName = 'name'
        Visible = True
      end>
  end
  object DateTimePicker1: TDateTimePicker
    Left = 8
    Top = 287
    Width = 89
    Height = 21
    Date = 43399.990633206020000000
    Time = 43399.990633206020000000
    TabOrder = 16
  end
  object Edit7: TEdit
    Left = 748
    Top = 287
    Width = 75
    Height = 21
    TabOrder = 17
  end
  object DBLookupComboBox1: TDBLookupComboBox
    Left = 103
    Top = 287
    Width = 130
    Height = 21
    KeyField = 'name'
    ListField = 'name'
    ListSource = DataSource2
    TabOrder = 18
  end
  object Button8: TButton
    Left = 470
    Top = 341
    Width = 89
    Height = 21
    Caption = 'HeaderExcel'
    TabOrder = 19
    OnClick = Button8Click
  end
  object DBChart1: TDBChart
    Left = 8
    Top = 431
    Width = 815
    Height = 259
    Title.Text.Strings = (
      'TDBChart')
    TabOrder = 20
    DefaultCanvas = 'TGDIPlusCanvas'
    ColorPaletteIndex = 13
    object Series1: TBarSeries
      DataSource = SQLQuery3
      XLabelsSource = 'name'
      XValues.Name = 'X'
      XValues.Order = loAscending
      XValues.ValueSource = 'id'
      YValues.Name = 'Bar'
      YValues.Order = loNone
      YValues.ValueSource = 'sum'
    end
  end
  object DBGrid4: TDBGrid
    Left = 829
    Top = 314
    Width = 123
    Height = 378
    DataSource = DataSource6
    TabOrder = 21
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    Columns = <
      item
        Expanded = False
        FieldName = 'datePayments'
        Visible = True
      end>
  end
  object DBGrid3: TDBGrid
    Left = 829
    Top = 15
    Width = 273
    Height = 293
    DataSource = DataSource5
    TabOrder = 22
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    Columns = <
      item
        Expanded = False
        FieldName = #1055#1086#1082#1091#1087#1082#1072
        Visible = True
      end
      item
        Expanded = False
        FieldName = #1055#1088#1086#1076#1072#1078#1072
        Visible = True
      end
      item
        Expanded = False
        FieldName = #1053#1072#1080#1084#1077#1085#1086#1074#1072#1085#1080#1077
        Visible = True
      end>
  end
  object DBGrid5: TDBGrid
    Left = 958
    Top = 314
    Width = 144
    Height = 378
    DataSource = DataSource7
    TabOrder = 23
    TitleFont.Charset = DEFAULT_CHARSET
    TitleFont.Color = clWindowText
    TitleFont.Height = -11
    TitleFont.Name = 'Tahoma'
    TitleFont.Style = []
    Columns = <
      item
        Expanded = False
        FieldName = 'name'
        Visible = True
      end>
  end
  object Button7: TButton
    Left = 424
    Top = 373
    Width = 66
    Height = 25
    Caption = 'Refresh'
    TabOrder = 24
    OnClick = Button7Click
  end
  object SQLConnection1: TSQLConnection
    ConnectionName = 'MySQLConnection'
    DriverName = 'MySQL'
    LoginPrompt = False
    Params.Strings = (
      'DriverUnit=Data.DBXMySQL'
      
        'DriverPackageLoader=TDBXDynalinkDriverLoader,DbxCommonDriver250.' +
        'bpl'
      
        'DriverAssemblyLoader=Borland.Data.TDBXDynalinkDriverLoader,Borla' +
        'nd.Data.DbxCommonDriver,Version=24.0.0.0,Culture=neutral,PublicK' +
        'eyToken=91d62ebb5b0d1b1b'
      
        'MetaDataPackageLoader=TDBXMySqlMetaDataCommandFactory,DbxMySQLDr' +
        'iver250.bpl'
      
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
      'Database=communalpayments'
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
    Left = 72
    Top = 584
  end
  object SQLQuery1: TSQLQuery
    Active = True
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      
        'SELECT monthcommunalpayments.id, monthcommunalpayments.datePayme' +
        'nts, namepayments.name, monthcommunalpayments.numberPayments,'
      
        'monthcommunalpayments.fullName, monthcommunalpayments.adress, mo' +
        'nthcommunalpayments.sum'
      'FROM monthcommunalpayments'
      
        'INNER JOIN namepayments ON monthcommunalpayments.namePayments=na' +
        'mepayments.id;')
    SQLConnection = SQLConnection1
    Left = 168
    Top = 584
  end
  object ClientDataSet1: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider1'
    Left = 344
    Top = 584
  end
  object DataSetProvider1: TDataSetProvider
    DataSet = SQLQuery1
    Left = 256
    Top = 584
  end
  object DataSource1: TDataSource
    DataSet = ClientDataSet1
    OnDataChange = DataSource1DataChange
    Left = 424
    Top = 584
  end
  object SQLQuery2: TSQLQuery
    Active = True
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      'SELECT name  FROM namepayments')
    SQLConnection = SQLConnection1
    Left = 168
    Top = 632
  end
  object DataSetProvider2: TDataSetProvider
    DataSet = SQLQuery2
    Left = 256
    Top = 632
  end
  object ClientDataSet2: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider2'
    Left = 344
    Top = 632
  end
  object DataSource2: TDataSource
    DataSet = ClientDataSet2
    Left = 424
    Top = 632
  end
  object SQLQuery3: TSQLQuery
    Active = True
    MaxBlobSize = -1
    Params = <>
    SQL.Strings = (
      
        'SELECT monthcommunalpayments.id, monthcommunalpayments.datePayme' +
        'nts, namepayments.name, monthcommunalpayments.numberPayments,'
      
        'monthcommunalpayments.fullName, monthcommunalpayments.adress, mo' +
        'nthcommunalpayments.sum'
      'FROM monthcommunalpayments'
      
        'INNER JOIN namepayments ON monthcommunalpayments.namePayments=na' +
        'mepayments.id;')
    SQLConnection = SQLConnection1
    Left = 520
    Top = 584
  end
  object DataSetProvider3: TDataSetProvider
    DataSet = SQLQuery3
    Left = 608
    Top = 584
  end
  object ClientDataSet3: TClientDataSet
    Active = True
    Aggregates = <>
    Params = <>
    ProviderName = 'DataSetProvider3'
    Left = 696
    Top = 584
  end
  object DataSource3: TDataSource
    DataSet = ClientDataSet3
    OnDataChange = DataSource1DataChange
    Left = 771
    Top = 584
  end
  object FDConnection1: TFDConnection
    Params.Strings = (
      'Database=communalpayments'
      'User_Name=mysql'
      'Password=mysql'
      'Server=127.0.0.1'
      'DriverID=MySQL')
    Connected = True
    LoginPrompt = False
    Left = 872
    Top = 528
  end
  object FDQuery1: TFDQuery
    Active = True
    Connection = FDConnection1
    SQL.Strings = (
      'SELECT datePayments  FROM monthcommunalpayments')
    Left = 960
    Top = 528
  end
  object DataSource6: TDataSource
    DataSet = FDQuery1
    Left = 1040
    Top = 528
  end
  object MySQLDatabase1: TMySQLDatabase
    Connected = True
    DatabaseName = 'communalpayments'
    UserName = 'mysql'
    UserPassword = 'mysql'
    Host = '127.0.0.1'
    ConnectOptions = [coCompress]
    ConnectionCharacterSet = 'cp1251'
    Params.Strings = (
      'Port=3306'
      'TIMEOUT=30'
      'DatabaseName=communalpayments'
      'UID=mysql'
      'PWD=mysql'
      'Host=127.0.0.1')
    DatasetOptions = []
    Left = 872
    Top = 624
  end
  object ADOConnection1: TADOConnection
    Connected = True
    ConnectionString = 
      'Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\25 Information T' +
      'echnology Software\4 course\Data base\18.mdb;Persist Security In' +
      'fo=False'
    LoginPrompt = False
    Mode = cmShareDenyNone
    Provider = 'Microsoft.Jet.OLEDB.4.0'
    Left = 872
    Top = 576
  end
  object ADOQuery1: TADOQuery
    Active = True
    Connection = ADOConnection1
    CursorType = ctStatic
    Parameters = <>
    SQL.Strings = (
      
        'SELECT ['#1050#1091#1088#1089' '#1086#1073#1084#1077#1085#1072'].'#1055#1086#1082#1091#1087#1082#1072', ['#1050#1091#1088#1089' '#1086#1073#1084#1077#1085#1072'].'#1055#1088#1086#1076#1072#1078#1072', '#1043#1086#1088#1086#1076#1072'.'#1053#1072#1080#1084 +
        #1077#1085#1086#1074#1072#1085#1080#1077
      
        'FROM '#1043#1086#1088#1086#1076#1072' INNER JOIN ['#1050#1091#1088#1089' '#1086#1073#1084#1077#1085#1072'] ON '#1043#1086#1088#1086#1076#1072'.['#1050#1086#1076'_'#1075#1086#1088#1086#1076#1072'] = ['#1050 +
        #1091#1088#1089' '#1086#1073#1084#1077#1085#1072'].['#1050#1086#1076'_'#1075#1086#1088#1086#1076#1072']'
      'WHERE ((('#1043#1086#1088#1086#1076#1072'.'#1053#1072#1080#1084#1077#1085#1086#1074#1072#1085#1080#1077')="'#1052#1080#1085#1089#1082'"));')
    Left = 960
    Top = 576
  end
  object DataSource5: TDataSource
    DataSet = ADOQuery1
    Left = 1040
    Top = 576
  end
  object DataSource7: TDataSource
    DataSet = MySQLQuery1
    Left = 1040
    Top = 624
  end
  object MySQLQuery1: TMySQLQuery
    Database = MySQLDatabase1
    Active = True
    SQL.Strings = (
      'SELECT name FROM namepayments')
    Left = 960
    Top = 624
  end
  object OpenDialog1: TOpenDialog
    Left = 552
    Top = 352
  end
end
